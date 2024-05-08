using Help.EndPoints.API.ServiceConfigurations;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
