using Base_Framework.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.AccountAgg.DTOs.Assistant
{
    public class CreateAssistantDTO
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
    }
}
