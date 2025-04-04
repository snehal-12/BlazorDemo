using BlazorDemoApp.Components;
using BlazorDemoApp.StateStore;
using Blazorise;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorise(Options=> { Options.Immediate=true; })
    .AddFontAwesomeIcons();

//builder.Services.AddTransient<SessionStorage>();
builder.Services.AddScoped<ContainerStorage>();
builder.Services.AddScoped<MadisonOnlineServerStore>();
builder.Services.AddScoped<HuntsvilleOnlineServerStore>();
builder.Services.AddScoped<DecaturOnlineServerStore>();
builder.Services.AddScoped<GadsdenOnlineServerStore>();
builder.Services.AddScoped<SelmaOnlineServerStore>();
builder.Services.AddScoped<MobileOnlineServerStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
