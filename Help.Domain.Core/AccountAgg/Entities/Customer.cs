﻿using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Customer : User
    {
        public Customer(string fullName, string userName, string password, string? email, string mobile, int roleId, int addressId) : base(fullName, userName, password, email, mobile, roleId)
        {
            IsActive = false;
            AddressId = addressId;

        }

     
        public Int64? CardNumber { get; private set; }
        public string? Bio { get; private set; }
        public DateTime? Birthday { get; private set; }
        public int AddressId { get; private set; } 
        public bool IsActive { get; private set; }

        #region Navigation Properties

        public CustomerPicture Profile { get; private set; }
        public List<HelpRequest> HelpRequests { get; private set; }
        public List<Skill>? Skills { get; private set; }
        public List<Proposal> Proposals { get; private set; }
        public Wallet Wallet { get; private set; }
        public Address Address { get; set; }
        public List<Vote> Votes { get; set; }

        #endregion

        public void Edit(string fullName, string? email, Int64? cardNumber, string? bio, DateTime? birthday, string mobile)
        {
            FullName = fullName;
            Email = email;
            CardNumber = cardNumber;
            Birthday = birthday;
            Bio = bio;
            IsActive = false;
            FullName = fullName;
            Mobile = mobile;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }



    }
}
