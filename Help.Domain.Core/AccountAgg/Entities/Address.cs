using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Address : BaseEntity
    {
        public Address(string description, long cityId, string streetName, int alleyNumber)
        {
            Description = description;
            CityId = cityId;
            StreetName = streetName;
            AlleyNumber = alleyNumber;
        }

        public string Description { get; private set; }
        public long CityId { get; private set; }
        public string StreetName { get; private set; }
        public int AlleyNumber { get; private set; }

        #region Navigation Properties

        public City City { get; private set; }
        public Customer Customer { get; set; }

        #endregion

        public void Edit(string description, long cityId, string streetName, int alleyNumber)
        {
            Description = description;
            CityId = cityId;
            StreetName = streetName;
            AlleyNumber = alleyNumber;
        }
    }
}
