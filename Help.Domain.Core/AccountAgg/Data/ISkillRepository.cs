using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Skill;
using Help.Domain.Core.AccountAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task Create(CreateSkillDTO command, CancellationToken cancellationToken);
        Task<List<SkillDTO>> GetAllByCustomerId(int customerId, CancellationToken cancellationToken);
    }
}
