using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TM.Application.EmployeeManagement.Implementations;
using TM.Application.EmployeeManagement.Interfaces;
using TM.Model.Business.EmployeeManagement;
using TM.Helper.Helper;
using WebApplication2.Service;
using TM.Model.Business;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //DataContext dataContext = new DataContext();
        private readonly IEmployeeManagementApplication employeeManagementApplication;
        public EmployeeController(IConfiguration _configuration, IEmployeeManagementApplication employeeManagementApplication)
        {
            Configuration = _configuration;
            this.employeeManagementApplication = employeeManagementApplication;
        }
        private static IConfiguration Configuration;

        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";

        [Authorize]
        [Route("api/GetEmployeeDetails")]
        [HttpGet]
        public async Task<List<EmployeeDetails>> Get()
        {
            List<EmployeeDetails> employeeDetails = await employeeManagementApplication.GetEmployeeDetails();
            return employeeDetails;
        }

        [Route("api/GetUserMessageDetails")]
        [HttpGet]
        public async Task<List<UserMessage>> GetUserMessageDetails()
        {
            List<UserMessage> userMessages = await employeeManagementApplication.GetUserMessageDetails();
            return userMessages;
        }

        [Authorize]
        [Route("api/GetRoleDetails")]
        [HttpGet]
        public async Task<List<RoleInformation>> GetRoleDetails()
        {
            List<RoleInformation> roleDetails = await employeeManagementApplication.GetRoleDetails();
            return roleDetails;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/CreateEmployee")]
        [HttpPost]
        public async Task<EmpLeaveResponse> Post([FromBody] EmployeeDetails students)
        {
            EmpLeaveResponse response = null;
            int affectedRows = 0;
            using (var connection = new SqlConnection(str1))
            {
                EmployeeDetails objstd = new EmployeeDetails();

                try
                {

                    connection.Open();
                    string strQuery = string.Empty;
                    strQuery = @"SELECT username FROM TBL_EMPLOYEE_DTL WHERE username='" + students.username + "'";
                    int count = connection.Query<EmployeeDetails>(strQuery).Count();
                    if (count == 0) 
                    {
                        string encryptedVal = EncryptDecrypt.EncryptString(students.password, ApplicationSettings.Current.Key);
                        affectedRows = connection.Execute(@"Insert into TBL_EMPLOYEE_DTL(Id, Name,SchoolId,Grade,username,password,RoleId) values ('" + students.id + "','" + students.name + "','" + students.schoolId + "','" + students.grade + "','" + students.username + "','" + encryptedVal + "','"+ students.roleId+ "')");
                        //affectedRows = +1;
                    }
                    else
                    {
                        response = new EmpLeaveResponse
                        {
                            Response = true,
                            Message = "UserName Already Exist in the System.",
                            isSuccess = false
                        };
                        return response;
                    }
                    connection.Close();


                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
            if (affectedRows == 1)
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Your leave request is sucessfully submitted",
                    isSuccess = true
                };
            }
            else
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Facing the issue while inserting.",
                    isSuccess = false
                };
            }
            return response;

        }

        // PUT api/<SQL_UserManagementController1cs>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [Route("api/DeleteRecord")]
        [HttpDelete]
        public async Task<EmpLeaveResponse> Delete(int empId)
        {
            EmpLeaveResponse response = null;
            response= await employeeManagementApplication.Deleterecord(empId);
            return response;
        }

        [Route("api/Authentication")]
        [HttpPost]
        public async Task<EmpLeaveResponse> Authentication([FromBody] LoginViewModel student)
        {
            EmpLeaveResponse response = null;
            UserService a = new UserService(Configuration);
            bool Result = a.Authenticate(student);
            if (Result == false)
            {
                response = new EmpLeaveResponse
                {
                    Response = false,
                    Message = "Invalid Credentials."
                };

                return response;
            }
           
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,student.username),
            };
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            string tokenval = new JwtSecurityTokenHandler().WriteToken(token);


            response = new EmpLeaveResponse
            {
                Response = true,
                Message = tokenval
            };
            return response;
        }



    }
}
