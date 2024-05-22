using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.AccountAgg.DTOs.Admin
{
    public class CreateAdminDTO
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UserName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public int EmployeeID { get; set; }
        public string DateOfEmployeement { get;  set; }
        public string TerminationDateContract { get;  set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
