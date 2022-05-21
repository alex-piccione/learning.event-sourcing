using BlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("web api",
    client => client.BaseAddress = new Uri("http://localhost:51010")
);
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<SettingsService>();

var app = builder.Build();

var webApiUrl = app.Configuration["web api url"];

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
