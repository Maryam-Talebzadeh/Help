using Help.Domain.Core.ServiceAgg.Entities;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Customer : User
    {
        public Customer(string fullName, string userName, string password, string email, Int64 cardNumber, string phoneNumber, string? bio, long pictureId, DateTime birthday, long addressId) : base(fullName, userName, password, email)
        {
            CardNumber = cardNumber;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            AddressId = addressId;
            PictureId = pictureId;
            Bio = bio;
            Score = 0;
            IsActive = false;
            IsExpert = false;
        }

     
        public Int64 CardNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Bio { get; private set; }
        public long PictureId { get; private set; }
        public DateTime Birthday { get; private set; }
        public Int16 Score { get; private set; }
        public long AddressId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsExpert { get; private set; }

        #region Navigation Properties

        public CustomerPicture Profile { get; private set; }
        public List<HelpRequest> HelpRequests { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Proposal> Proposals { get; private set; }
        public Wallet Wallet { get; private set; }
        public List<CustomerRole> CustomerRoles { get; private set; }

        #endregion

        public void Edit(Int64 cardNumber, string phoneNumber, string? bio, DateTime birthday)
        {
            CardNumber = cardNumber;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Bio = bio;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void ExpertIt(List<Skill> skills) 
        {
            IsExpert = true;
            Skills = skills;
        }

    }
}
