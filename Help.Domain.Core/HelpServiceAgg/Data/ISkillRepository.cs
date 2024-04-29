﻿using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Skill;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ISkillRepository : IRepository<Skill>
    {
        void Create(CreateSkillDTO command);
        void Edit(EditSkillDTO command);
        EditSkillDTO GetDetails(long id);
        List<SkillDTO> Search(SearchSkillDTO searchModel);
    }
}