

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Assistant : User
    {
        public Assistant(int employeeID, DateTime terminationDateContract, string fullName, string userName, string password, string? email, string mobile, int roleId) : base(fullName, userName, password, email, mobile, roleId)
        {
            DateOfEmployeement = DateTime.Now;
            EmployeeID = employeeID;
            TerminationDateContract = terminationDateContract;
        }

        public int EmployeeID { get; private set; }
        public DateTime DateOfEmployeement { get; private set; }
        public DateTime TerminationDateContract { get; private set; }

        public void Edit(int employeeID, DateTime terminationDateContract, string fullName, string userName, string? email, string mobile)
        {
            FullName = fullName;
            Email = email;
            EmployeeID = employeeID;
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            TerminationDateContract = terminationDateContract;
        }
    }
}
