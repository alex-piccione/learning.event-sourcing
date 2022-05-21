using BlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var webApiUrl = configuration["web api url"];

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("web api",
    client => client.BaseAddress = new Uri(webApiUrl)
);
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<SettingsService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
