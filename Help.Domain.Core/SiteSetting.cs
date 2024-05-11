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
            SeqApiKey = configuration["Seq:ApiKey"].ToString();
            SeqApiKey = configuration["Seq:ServerAddress"].ToString();
        }

        public string HelpConnectionString { get; private set; }
        public string RedisConnectionString { get; private set; }
        public string SeqApiKey { get; private set; }
        public string SeqServerAddress { get; private set; }
        public string HelpServiceCategoriesCacheKey { get; private set; }
        public string HelpServicesCacheKey { get; private set; }
    }
}
