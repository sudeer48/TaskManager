using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace TM.Application.EmployeeManagement.Interfaces
{
    public interface IEmployeeManagementApplication
    {
        Task<List<Student>> GetEmployeeDetails();
    }
}
