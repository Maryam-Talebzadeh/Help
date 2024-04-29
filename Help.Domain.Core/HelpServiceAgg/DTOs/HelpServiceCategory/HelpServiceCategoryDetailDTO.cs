using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class HelpServiceCategoryDetailDTO : EditHelpServiceCategoryDTO
    {
        public List<HelpServiceCategoryDTO> Children { get; set; }
    }
}
