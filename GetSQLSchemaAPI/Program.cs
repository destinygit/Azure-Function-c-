using GetSQLSchemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using GetSQLSchemaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable CS8604 // Possible null reference argument.
//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
#pragma warning restore CS8604 // Possible null reference argument.
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());



// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("WorldWideImpoters");
builder.Services.AddDbContext<azwideworldimportersdataDBContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
