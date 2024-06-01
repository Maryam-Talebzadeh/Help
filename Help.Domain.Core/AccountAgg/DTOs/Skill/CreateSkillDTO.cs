using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.AccountAgg.DTOs.Skill
{
    public class CreateSkillDTO
    {
        public int CustomerId { get; set; }
        public int HelpServiceId { get; set; }
    }
}
