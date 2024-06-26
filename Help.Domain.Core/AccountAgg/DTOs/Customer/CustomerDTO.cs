﻿

using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.WalletAgg.DTOs.Wallet;

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public CustomerPictureDTO Picture { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string CreationDate { get; set; } 
    }
}
