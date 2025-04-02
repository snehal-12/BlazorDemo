using BlazorDemoApp.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorDemoApp.StateStore
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage protectedSessionStorage;

        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            this.protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server> GetServerAsync() //get value stored in browser session storage
        {
            var result = await this.protectedSessionStorage.GetAsync<Server>("server");
            if(result.Success) 
                return result.Value;
            else return null;
        }

        public async Task SetServerAsync(Server? server) //store value in browser session storage
        {
            await this.protectedSessionStorage.SetAsync("server", server);
        }

    }
}
