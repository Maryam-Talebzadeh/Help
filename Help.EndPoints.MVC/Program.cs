using Help.Domain.Core;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using HelpConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

// Add services to the container.

var siteSetting = new SiteSetting(builder.Configuration);
builder.Services.AddSingleton(siteSetting);



#region DBContext

builder.Services.AddDbContext<HelpContext>(options =>
        options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HelpiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
#endregion

#region CachingService

builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connectionString = siteSetting.RedisConnectionString;

    redisOptions.Configuration = connectionString;
    redisOptions.ConfigurationOptions = new()
    {
        Password = string.Empty,
        DefaultDatabase = 0,
        ConnectTimeout = 30000
    };

});

#endregion

#region Logging Services

builder.Services.AddLogging(loggerBuilder =>
{
    loggerBuilder.AddSeq(siteSetting.SeqServerAddress, siteSetting.SeqApiKey);
});

#endregion

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
