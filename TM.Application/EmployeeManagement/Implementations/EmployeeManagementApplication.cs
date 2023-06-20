using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.EmployeeManagement.Interfaces;
using TM.Database.Repository.EmployeeManagement;
using TM.Domain.EmployeeManagement.Interfaces;
using TM.Model.Business;
using TM.Model.Business.EmployeeManagement;


namespace TM.Application.EmployeeManagement.Implementations
{
    public class EmployeeManagementApplication : IEmployeeManagementApplication
    {
        private readonly IEmployeeManagementDomain employeeManagementDomain;

        public EmployeeManagementApplication(IEmployeeManagementDomain employeeManagementDomain)
        {
            this.employeeManagementDomain = employeeManagementDomain;
        }
        public async Task<List<EmployeeDetails>> GetEmployeeDetails()
        {
            List<EmployeeDetails> employeeDetails = await employeeManagementDomain.GetEmployeeDetails();
            return employeeDetails;
        }

        public async Task<List<RoleInformation>> GetRoleDetails()
        {
            List<RoleInformation> roleDetails = await employeeManagementDomain.GetRoleDetails();
            return roleDetails;
        }

        public async Task<EmpLeaveResponse> Deleterecord(int empId)
        {
            EmpLeaveResponse response = await employeeManagementDomain.Deleterecord(empId);           
            return response;
        }

        public async Task<List<UserMessage>> GetUserMessageDetails()
        {
            List<UserMessage> userMessages = await employeeManagementDomain.GetUserMessageDetails();
            return userMessages;
        }
    }
}
