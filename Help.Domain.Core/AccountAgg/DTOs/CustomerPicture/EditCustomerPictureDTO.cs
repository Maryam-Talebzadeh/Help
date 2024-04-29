using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.AccountAgg.DTOs.CustomerPicture
{
   public class EditCustomerPictureDTO : CreateCustomerPictureDTO
    {
        public long Id { get; set; }
    }
}
