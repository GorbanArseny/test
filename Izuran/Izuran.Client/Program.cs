using Blazored.SessionStorage;
using Izuran.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddFluentUIComponents();
builder.Services.AddScoped(sp => new HttpClient
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
}); 
builder.Services.AddBlazoredSessionStorage();//авторизация
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
