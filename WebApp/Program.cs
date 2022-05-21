using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;


// Breackpoints are not hit
// Console.WriteLine has no effect

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var webApiUrl = new ConfigurationManager()["Web API URL"];

// broser Console shows an error because the URL is null.
// without breakpoin an exception handling is impossible to develop the application... switch to React.

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(webApiUrl) });

await builder.Build().RunAsync();

