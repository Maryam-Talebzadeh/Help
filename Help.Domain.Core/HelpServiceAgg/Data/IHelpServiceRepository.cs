using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServiceRepository : IRepository<HelpService>
    {
        void Create(CreateHelpServiceDTO command);
        void Edit(EditHelpServiceDTO command);
        EditHelpServiceDTO GetDetails(long id);
        List<HelpServiceDTO> Search(SearchHelpServiceDTO searchModel);
        List<HelpServiceDTO> GetAllRemoved();
    }
}
