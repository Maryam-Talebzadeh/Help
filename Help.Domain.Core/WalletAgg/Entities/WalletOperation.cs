﻿using Base_Framework.Domain.Core.Entities;


namespace Help.Domain.Core.WalletAgg.Entities
{
    public class WalletOperation : BaseEntity
    {
        public WalletOperation(double amount, int walletId, byte typeId)
        {
            Amount = amount;
            IsPaid = false;
            WalletId = walletId;
            TypeId = typeId;
            IsCanceled = false;
        }

        public double Amount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsCanceled { get; private set; }
        public int WalletId { get; private set; }
        public byte TypeId { get; private set; }

        #region Navigation Properties

        public Wallet Wallet { get; private set; }
        public OperationType Type { get; private set; }

        #endregion

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void Finalize()
        {
            IsPaid = true;
        }
    }
}
