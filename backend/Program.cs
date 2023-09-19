// Azure App Configuration using statements
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using shared.Helpers;
using shared.services;
using Shortener;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Microsoft Azure App Configuration (secrets)
// dotnet user-secrets init
// dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"
// string appConnectionString = builder.Configuration.GetConnectionString("AppConfig");

//Microsoft Azure App Configuration (environment variables - MACOS)
// export AppConfigurationEndpoint=MyValue

if (builder.Environment.IsDevelopment())
{
    var path = Path.Combine(Directory.GetCurrentDirectory(), ".env");
    Environmentmaster.LoadEnvironmentVariables(path);
}

string appConfigurationEndpoint = Environment.GetEnvironmentVariable("AppConfigurationEndpoint") ?? string.Empty;
builder.Configuration.AddAzureAppConfiguration(appConfigurationEndpoint);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("shortapi:endpoints"));

//Shared [Azure Storage tables
var storageUrl = builder.Configuration.GetValue<string>("shortapi:endpoints:tablestorage");
builder.Services.AddSingleton<IUrlService>(service => new UrlService(storageUrl, "WEBSITEURLS"));

var app = builder.Build();

// Ensures swagger definition is always available regardless of environment
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
