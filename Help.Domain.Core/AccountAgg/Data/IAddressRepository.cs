using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IAddressRepository: IRepository<Address>
    {
        int Create(CreateAddressDTO command);
        void Edit(EditAddressDTO command);
    }
}
