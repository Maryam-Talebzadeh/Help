﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class EditHelpServiceCategoryDTO : CreateChildHelpServiceCategoryDTO
    {
        public long Id { get; set; }
    }
}
