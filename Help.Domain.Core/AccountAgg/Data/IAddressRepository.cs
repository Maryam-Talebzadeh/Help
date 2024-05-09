using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<int> Create(CreateAddressDTO command, CancellationToken cancellationToken);
        Task Edit(EditAddressDTO command, CancellationToken cancellationToken);
    }
}
