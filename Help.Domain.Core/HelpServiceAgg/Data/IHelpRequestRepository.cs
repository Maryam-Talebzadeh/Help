using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpRequestRepository : IRepository<HelpRequest>
    {
        void Create(CreateHelpRequestDTO command);
        void Edit(EditHelpRequestDTO command);
        HelpRequestDetailDTO GetDetails(long id);
        List<HelpRequestDTO> Search(SearchHelpRequestDTO searchModel);
    }
}
