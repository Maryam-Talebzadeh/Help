﻿using Microsoft.Extensions.Configuration;

namespace Help.Domain.Core
{
    public class SiteSetting
    {
        public SiteSetting(IConfiguration configuration)
        {
            HelpConnectionString = configuration.GetConnectionString("HelpConnectionString");
            RedisConnectionString = configuration.GetConnectionString("RedisConnectionString");
            HelpServiceCategoriesCacheKey = configuration["CacheKeys:HelpServiceCategories"].ToString();
            HelpServicePicturessCacheKey = configuration["CacheKeys:HelpServicePictures"].ToString();
            HelpServicesCacheKey = configuration["CacheKeys:HelpServices"].ToString();
            SeqApiKey = configuration["Seq:ApiKey"].ToString();
            SeqServerAddress = configuration["Seq:ServerAddress"].ToString();
        }

        public string HelpConnectionString { get; private set; }
        public string RedisConnectionString { get; private set; }
        public string SeqApiKey { get; private set; }
        public string SeqServerAddress { get; private set; }
        public string HelpServiceCategoriesCacheKey { get; private set; }
        public string HelpServicesCacheKey { get; private set; }
        public string HelpServicePicturessCacheKey { get; private set; }

    }
}
