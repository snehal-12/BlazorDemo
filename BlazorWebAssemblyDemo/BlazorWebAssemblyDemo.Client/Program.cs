using BlazorWebAssemblyDemo.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Register IHttpClientfactory and configure a named client
builder.Services.AddHttpClient("ServersApi", client =>
{
    client.BaseAddress = new Uri("https://blazorwebassemblydemo-2efec-default-rtdb.firebaseio.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersApiRepository>();

await builder.Build().RunAsync();
