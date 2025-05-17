using CXManagement.Presentation;
using CXManagement.Presentation.Presenters;
using CXManagement.Presentation.Services.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7019") // <-- API server URL
});

builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<ApplicationPresenter>();

await builder.Build().RunAsync();
