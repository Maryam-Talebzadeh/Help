using Base_Framework.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UserName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = ValidationMessages.WrongRePassword)]
        public string RePassword { get; set; }
        public string? Email { get; set; }
        public Int64? CardNumber { get; set; }
        public string? Bio { get; set; }
        public string? CreationDate { get; set; }
        public string? Birthday { get; set; }
        public int AddressId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }
        public int RoleId { get;  set; }
    }
}
