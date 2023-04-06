using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.EmployeeManagement.Interfaces;
using TM.Domain.EmployeeManagement.Interfaces;
using WebApplication2.Entities;

namespace TM.Application.EmployeeManagement.Implementations
{
    public class EmployeeManagementApplication : IEmployeeManagementApplication
    {
        private readonly IEmployeeManagementDomain employeeManagementDomain;

        public EmployeeManagementApplication(IEmployeeManagementDomain employeeManagementDomain)
        {
            this.employeeManagementDomain = employeeManagementDomain;
        }
        public async Task<List<Student>> GetEmployeeDetails()
        {
            List<Student> employeeDetails = await employeeManagementDomain.GetEmployeeDetails();
            return employeeDetails;
        }
    }
}
