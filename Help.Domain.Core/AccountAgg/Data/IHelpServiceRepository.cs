﻿using Help.Domain.Core.AccountAgg.DTOs.HelpService;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IHelpServiceRepository
    {
        List<HelpServiceDTO> GetAll();
        void Create(CreateHelpServiceDTO command);
        void Edit(EditHelpServiceDTO command);
        EditHelpServiceDTO GetDetails(long id);
        List<HelpServiceDTO> Search(SearchHelpServiceDTO searchModel);
    }
}
