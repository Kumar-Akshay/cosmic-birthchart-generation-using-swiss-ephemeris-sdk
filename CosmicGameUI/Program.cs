using Blazored.LocalStorage;
using CosmicGameUI.Auth;
using CosmicGameUI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<CosmicGameUI.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API base URL from config
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:54991";

// HTTP client that auto-attaches JWT Bearer token
builder.Services.AddScoped<JwtAuthorizationHandler>();
builder.Services.AddHttpClient("CosmicAPI", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("CosmicAPI"));

// Auth
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CosmicAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Domain services
builder.Services.AddScoped<IChartHolderApiService, ChartHolderApiService>();
builder.Services.AddScoped<IAstroChartApiService, AstroChartApiService>();

// MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
