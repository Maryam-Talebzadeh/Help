﻿using Base_Framework.Domain.Core.Entities;


namespace Help.Domain.Core.AccountAgg.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string userName, string password, string email)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public string FullName { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string Email { get; internal set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
