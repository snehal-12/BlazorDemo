using BlazorDemoApp.Models;

namespace BlazorDemoApp.Repository
{
    public static class ServerRepo
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server {  Id = 1, Name = "Server 1", City = "Madison" },
            new Server {  Id = 2, Name = "Server 2", City = "Madison" },
            new Server {  Id = 3, Name = "Server 3", City = "Madison" },
            new Server {  Id = 4, Name = "Server 4", City = "Madison" },
            new Server {  Id = 5, Name = "Server 5", City = "Decatur" },
            new Server {  Id = 6, Name = "Server 6", City = "Decatur" },
            new Server {  Id = 7, Name = "Server 7", City = "Decatur" },
            new Server {  Id = 8, Name = "Server 8", City = "Gadsden" },
            new Server {  Id = 9, Name = "Server 9", City = "Gadsden" },
            new Server {  Id = 10, Name = "Server 10", City = "Huntsville" },
            new Server {  Id = 11, Name = "Server 11", City = "Huntsville" },
            new Server {  Id = 12, Name = "Server 12", City = "Selma" },
            new Server {  Id = 13, Name = "Server 13", City = "Selma" },
            new Server {  Id = 14, Name = "Server 14", City = "Mobile" },
            new Server {  Id = 15, Name = "Server 15", City = "Mobile" },
        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.Id);
            server.Id = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServres() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.Id == id);
            if (server != null)
            {
                return new Server
                {
                    Id = server.Id,
                    Name = server.Name,
                    City = server.City,
                    IsActive = server.IsActive
                };
            }

            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.Id) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.Id == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsActive = server.IsActive;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.Id == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
