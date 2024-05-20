

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Admin : User
    {
        public Admin(int employeeID, DateTime terminationDateContract, string fullName, string userName, string password, string email, string mobile, int roleId) : base(fullName, userName, password, email, mobile, roleId)
        {
            DateOfEmployeement = DateTime.Now;
            EmployeeID = employeeID;
            TerminationDateContract = terminationDateContract;
        }

        public int EmployeeID { get; private set; }
        public DateTime DateOfEmployeement { get; private set; }
        public DateTime TerminationDateContract { get; private set; }
    }
}
