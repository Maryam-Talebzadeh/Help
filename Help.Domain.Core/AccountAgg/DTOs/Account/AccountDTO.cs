﻿namespace Help.Domain.Core.AccountAgg.DTOs.Account
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
    }
}
