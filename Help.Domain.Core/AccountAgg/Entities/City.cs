using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class City : BaseEntity
    {
        public City(string name, string provinceName, string code)
        {
            Name = name;
            ProvinceName = provinceName;
            Code = code;
        }

        public string Name { get; private set; }
        public string ProvinceName { get; private set; }
        public string Code { get; private set; }

        #region Navigation Properties

        public List<Address> Addresses { get; private set; }

        #endregion

        public void Edit(string name, string provinceName, string code)
        {
            Name = name;
            ProvinceName = provinceName;
            Code = code;
        }
    }
}
