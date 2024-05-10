using Help.EndPoints.MVC.ServiceConfigurations;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

// Add services to the container.

#region Custom Services

LocalServiceConfigurations.Configure(builder.Services, builder.Configuration.GetConnectionString("HelpConnectionString"));

#endregion

#region CachingService

builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connectionString = builder.Configuration
    .GetConnectionString("Redis");

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
    loggerBuilder.AddSeq("http://localhost:5341", "VhKsy1B9lJDwxHVohwst");
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
