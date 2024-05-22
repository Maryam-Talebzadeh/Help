using Base_Framework.Domain.Core.Entities;


namespace Help.Domain.Core.AccountAgg.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string userName, string password, string? email, string mobile, int roleId)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
            Mobile = mobile;
            RoleId = roleId;
        }

        public string FullName { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string Email { get; internal set; }
        public string Mobile { get; internal set; }
        public int RoleId { get; internal set; }
        public Role Role { get; internal set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
