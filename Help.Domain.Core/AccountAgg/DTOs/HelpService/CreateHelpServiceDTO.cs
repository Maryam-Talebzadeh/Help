﻿

namespace Help.Domain.Core.AccountAgg.DTOs.HelpService
{
    public class CreateHelpServiceDTO
    {
        public string Title { get; set; }
        public string Description { get;  set; }
        public string Slug { get;  set; }
        public string Tags { get;  set; }
    }
}