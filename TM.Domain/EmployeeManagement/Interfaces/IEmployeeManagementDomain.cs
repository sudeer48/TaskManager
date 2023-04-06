using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace TM.Domain.EmployeeManagement.Interfaces
{
    public interface IEmployeeManagementDomain
    {
        Task<List<Student>> GetEmployeeDetails();
    }
}
