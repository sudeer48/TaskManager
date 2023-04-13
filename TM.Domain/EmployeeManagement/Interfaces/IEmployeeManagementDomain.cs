using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Model.Business.EmployeeManagement;

namespace TM.Domain.EmployeeManagement.Interfaces
{
    public interface IEmployeeManagementDomain
    {
        Task<List<EmployeeDetails>> GetEmployeeDetails();
        Task<List<RoleInformation>> GetRoleDetails();
        Task<EmpLeaveResponse> Deleterecord(EmployeeDetails employeeDetails);
    }
}
