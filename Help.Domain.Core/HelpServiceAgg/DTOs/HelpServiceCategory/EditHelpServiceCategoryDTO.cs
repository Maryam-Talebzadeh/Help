using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class EditHelpServiceCategoryDTO : CreateChildHelpServiceCategoryDTO
    {
        public int Id { get; set; }
    }
}
