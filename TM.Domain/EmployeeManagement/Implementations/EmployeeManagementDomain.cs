using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Database.Repository.EmployeeManagement;
using TM.Domain.EmployeeManagement.Interfaces;
using WebApplication2.Entities;

namespace TM.Domain.EmployeeManagement.Implementations
{
    public class EmployeeManagementDomain : IEmployeeManagementDomain
    {
        private readonly IConfiguration configuration;

        public EmployeeManagementDomain(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<Student>> GetEmployeeDetails()
        {
            List<Student> empDetails = null;
            using (EmployeeManagementRepository empManagementRepository = new(configuration))
            {
                empDetails = await empManagementRepository.GetEmployeeDetails();
            }
            return empDetails;
        }
    }
}
