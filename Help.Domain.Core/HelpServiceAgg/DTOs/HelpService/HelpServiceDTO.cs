﻿using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpService
{
    public class HelpServiceDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public List<IdTitleCategoryDTO> Categories { get; set; }
    }
}