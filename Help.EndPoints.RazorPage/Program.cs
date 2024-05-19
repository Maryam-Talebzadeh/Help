using Base_Framework.LogError;
using Help.Domain.Core;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using HelpConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton(new SiteSetting(builder.Configuration));

#region DBContext

builder.Services.AddDbContext<HelpContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HelpConnectionString")));
#endregion

#region Logging Services

builder.Services.AddLogging(loggerBuilder =>
{
    loggerBuilder.AddSeq(builder.Configuration["Seq:ServerAddress"], builder.Configuration["Seq:ApiKey"]);
});

#endregion

#region CachingService

var multiplexer = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnectionString"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connectionString =builder.Configuration.GetConnectionString("RedisConnectionString");

    redisOptions.Configuration = connectionString;
    redisOptions.ConfigurationOptions = new()
    {
        Password = string.Empty,
        DefaultDatabase = 0,
        ConnectTimeout = 30000,
        AbortOnConnectFail = false
    };

    redisOptions.ConfigurationOptions.EndPoints.Add(connectionString);

});


#endregion

#region Custom Services
var host = new WebHostBuilder();
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<OperationResultLogging>>();
Bootstrapper.Configure(builder.Services,logger);

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
