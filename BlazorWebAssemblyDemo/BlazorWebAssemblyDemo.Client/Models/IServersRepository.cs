
namespace BlazorWebAssemblyDemo.Client.Models
{
    public interface IServersRepository
    {
        Task AddServerAsync(Server server);
        Task DeleteServerAsync(int serverId);
        Task<Server?> GetServerByIdAsync(int serverId);
        Task<List<Server>> GetServersAsync();
        Task UpdateServerAsync(int serverID, Server server);
        
    }
}