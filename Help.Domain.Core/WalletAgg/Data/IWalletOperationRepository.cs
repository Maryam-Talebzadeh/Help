﻿using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.WalletAgg.DTOs.WalletOperation;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.WalletAgg.Data
{
    public interface IWalletOperationRepository : IRepository<WalletOperation>
    {
        void Create(CreateWalleOperationtDTO command);
        List<WalletOperationDTO> GetBy(long walletId);
        public void Cancel(long id);
        public void finalize(long id);
    }
}
