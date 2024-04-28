

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Admin : User
    {
        public Admin(string fullName, string userName, string password, string email, int personalCode) : base(fullName, userName, password, email)
        {
            PersonalCode = personalCode;
        }

        public int PersonalCode { get; private set; }
    }
}
