namespace BlazorWebAssemblyDemo.Client.Models
{
    public class ServersRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server { ServerId = 1, Name = "Server 1", City = "Madison" },
            new Server { ServerId = 2, Name = "Server 2", City = "Madison" },
            new Server { ServerId = 3, Name = "Server 3", City = "Madison" },
            new Server { ServerId = 4, Name = "Server 4", City = "Madison" },
            new Server { ServerId = 5, Name = "Server 5", City = "Decatur" },
            new Server { ServerId = 6, Name = "Server 6", City = "Decatur" },
            new Server { ServerId = 7, Name = "Server 7", City = "Decatur" },
            new Server { ServerId = 8, Name = "Server 8", City = "Gadsden" },
            new Server { ServerId = 9, Name = "Server 9", City = "Gadsden" },
            new Server { ServerId = 10, Name = "Server 10", City = "Huntsville" },
            new Server { ServerId = 11, Name = "Server 11", City = "Huntsville" },
            new Server { ServerId = 12, Name = "Server 12", City = "Selma" },
            new Server { ServerId = 13, Name = "Server 13", City = "Selma" },
            new Server { ServerId = 14, Name = "Server 14", City = "Mobile" },
            new Server { ServerId = 15, Name = "Server 15", City = "Mobile" },
        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerId);
            server.ServerId = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId ==serverId);
            if (server != null)
            {
                return new Server
                {
                   ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }

            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);
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
