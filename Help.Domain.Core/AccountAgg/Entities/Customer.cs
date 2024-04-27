using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string fullName, string userName, string password , Int64 cardNumber, string phoneNumber, string? bio, long pictureId, DateTime birthday, long addressId)
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
            FullName = fullName;
            UserName = userName;
            Password = password;
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Int64 CardNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Bio { get; private set; }
        public long PictureId { get; private set; }
        public DateTime Birthday { get; private set; }
        public Int16 Score { get; private set; }
        public long AddressId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsExpert { get; private set; }

        public void Edit(string fullName, string userName, Int64 cardNumber, string phoneNumber, string? bio, DateTime birthday)
        {
            CardNumber = cardNumber;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Bio = bio;
            FullName = fullName;
            UserName = userName;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void ExpertIt() // input : list<Skill>
        {
            IsExpert = true;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
