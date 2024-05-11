using Microsoft.Extensions.Configuration;

namespace Help.Domain.Core
{
    public class SiteSetting
    {
        public SiteSetting(IConfiguration configuration)
        {
            HelpConnectionString = configuration.GetConnectionString("HelpConnectionString");
            RedisConnectionString = configuration.GetConnectionString("RedisConnectionString");
            HelpServiceCategoriesCacheKey = configuration["CacheKeys:helpServiceCategories"].ToString();
            HelpServicesCacheKey = configuration["CacheKeys:helpServices"].ToString();
            RedisApiKey = configuration["Redis:ApiKey"].ToString();
            RedisApiKey = configuration["Redis:ServerAddress"].ToString();
        }

        public string HelpConnectionString { get; private set; }
        public string RedisConnectionString { get; private set; }
        public string RedisApiKey { get; private set; }
        public string RedisServerAddress { get; private set; }
        public string HelpServiceCategoriesCacheKey { get; private set; }
        public string HelpServicesCacheKey { get; private set; }
    }
}
