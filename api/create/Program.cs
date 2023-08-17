// Azure App Configuration using statements
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using shared.services;
using Shortener;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Microost Azure App Configuration
// dotnet user-secrets init
// dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"
string appConnectionString = builder.Configuration.GetConnectionString("AppConfig");
builder.Configuration.AddAzureAppConfiguration(appConnectionString);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("UrlShort:Settings"));

//Shared [Azure Storage tables]
var storageUrl = builder.Configuration.GetValue<string>("UrlShort:Settings:Storage001");
builder.Services.AddSingleton<IUrlService>(service => new UrlService(storageUrl,"globalurls"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
