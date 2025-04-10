using Newtonsoft.Json;
using System.Text;

namespace BlazorWebAssemblyDemo.Client.Models
{
    public class ServersApiRepository : IServersRepository
    {
        private const string apiName = "ServersApi";
        private readonly IHttpClientFactory httpClientFactory;

        public ServersApiRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Server?> GetServerByIdAsync(int serverId)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            var response = await httpClient.GetAsync($"servers/{serverId}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Server>(content);
        }

        public async Task<List<Server>> GetServersAsync()
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            var response = await httpClient.GetAsync("servers.json"); // Firebase requires url to have .json 
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content) && content != "null")
            {
                return JsonConvert.DeserializeObject<List<Server>>(content) ?? new List<Server>();
            }
            return new List<Server>();
        }

        public async Task AddServerAsync(Server server)
        {
            server.ServerId = await GetNextServerIdAsync();
            var httpClient = httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server),Encoding.UTF8,"application/json");
            var response= await httpClient.PutAsync($"servers/{server.ServerId}.json", content); //PUT instead of POST for Firebase
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServerAsync(int serverID,Server server)
        {
            if(serverID!= server.ServerId)
                return;

            var httpClient = httpClientFactory.CreateClient(apiName);
            var content= new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8,"application/json");

            var response = await httpClient.PatchAsync($"servers/{server.ServerId}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerAsync(int serverId)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            await httpClient.DeleteAsync($"servers/{serverId}.json");
        }
        

        //Since Firebase does not auto increment Id
        private async Task<int> GetNextServerIdAsync()
        {
            var servers = await GetServersAsync();
            if (servers != null && servers.Any())
                return servers.Where(x=>x!=null).Max(x => x.ServerId) + 1;
            return 1;
        }
       
    }
}
