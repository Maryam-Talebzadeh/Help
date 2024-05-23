using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpService
{
    public class HelpServiceDetailDTO : EditHelpServiceDTO
    {
        public List<HelpRequestDTO> HelpRequests { get; set; }
    }
}
