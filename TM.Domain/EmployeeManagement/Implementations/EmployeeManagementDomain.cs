﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Database.Repository.EmployeeManagement;
using TM.Domain.EmployeeManagement.Interfaces;
using TM.Model.Business;
using TM.Model.Business.EmployeeManagement;


namespace TM.Domain.EmployeeManagement.Implementations
{
    public class EmployeeManagementDomain : IEmployeeManagementDomain
    {
        private readonly IConfiguration configuration;

        public EmployeeManagementDomain(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<EmployeeDetails>> GetEmployeeDetails()
        {
            List<EmployeeDetails> empDetails = null;
            using (EmployeeManagementRepository empManagementRepository = new(configuration))
            {
                empDetails = await empManagementRepository.GetEmployeeDetails();
            }
            return empDetails;
        }

        public async Task<List<UserMessage>> GetUserMessageDetails()
        {
            List<UserMessage> userMessages = null;
            using (EmployeeManagementRepository empManagementRepository = new(configuration))
            {
                userMessages = await empManagementRepository.GetUserMessageDetails();
            }
            return userMessages;
        }
        public async Task<List<RoleInformation>> GetRoleDetails()
        {
            List<RoleInformation> roleDetails = null;
            using (EmployeeManagementRepository empManagementRepository = new(configuration))
            {
                roleDetails = await empManagementRepository.GetRoleDetails();
            }
            return roleDetails;
        }

        public async Task<EmpLeaveResponse> Deleterecord(int empId)
        {
            EmpLeaveResponse response = null;
            using (EmployeeManagementRepository empManagementRepository = new(configuration))
            {
                response = await empManagementRepository.DeleteRecord(empId);
            }
            return response;
        }
    }
}
