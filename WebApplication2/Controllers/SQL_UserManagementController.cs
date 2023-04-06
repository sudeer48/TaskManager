using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Service;
using TM.Application.EmployeeManagement.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SQL_UserManagementController : ControllerBase
    {
        DataContext dataContext = new DataContext();
        private readonly IEmployeeManagementApplication employeeManagementApplication;
        public SQL_UserManagementController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        private static IConfiguration Configuration;

        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";

        // GET: api/<SQL_UserManagementController1cs>
        [Authorize]
        [Route("api/GetEmployeeDetails")]
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            List<Student> employeeDetails = await EmployeeManagementApplication.GetEmployeeLeaves(employeeSLNo, statusId);
            //using (var dbConn = new SqlConnection(str1))
            //{
            //    string strQuery = string.Empty;
            //    try
            //    {
            //        dbConn.Open();
            //        strQuery = @"SELECT * FROM TBL_STUDENT_DTL";
            //        var a = dbConn.Query<Student>(strQuery);
            //    }
            //    catch (System.Exception ex)
            //    {

            //        throw;
            //    }

            //    return dbConn.Query<Student>(strQuery).ToList();
            //}


        }

        // GET api/<SQL_UserManagementController1cs>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/CreateEmployee")]
        [HttpPost]
        public async Task<EmpLeaveResponse> Post([FromBody] Student students)
        {
            EmpLeaveResponse response = null;
            int affectedRows = 0;
            using (var connection = new SqlConnection(str1))
            {
                Student objstd = new Student();

                try
                {

                    connection.Open();
                    string strQuery = string.Empty;
                    strQuery = @"SELECT username FROM TBL_STUDENT_DTL WHERE username='"+students.username+"'";
                    int count = connection.Query<Student>(strQuery).Count();
                    if (count==0)
                    {
                        affectedRows = connection.Execute(@"Insert into TBL_STUDENT_DTL(Id, Name,SchoolId,Grade,username,password) values ('" + students.id + "','" + students.name + "','" + students.schoolId + "','" + students.grade + "','" + students.username + "','" + students.password + "')");
                        //affectedRows = +1;
                    }
                    else
                    {
                        response = new EmpLeaveResponse
                        {
                            Response = true,
                            Message = "UserName Already Exist in the System.",
                            isSuccess=false
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
        [HttpPost]
        //[HttpDelete("{id}")]
        public async Task<EmpLeaveResponse> Delete([FromBody] Student students)
        {
            EmpLeaveResponse response = null;
            int affectedRows = 0;
            using (var connection = new SqlConnection(str1))
            {
                Student objstd = new Student();

                try
                {

                    connection.Open();
                    affectedRows = connection.Execute(@"DELETE FROM TBL_STUDENT_DTL where Id='"+ students.id + "'");
                    connection.Close();
                    affectedRows = +1;

                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
            if (affectedRows != 1)
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Facing the issue while deleting.",
                    isSuccess = false
                };
            }
            else
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Record deleted sucessfully.",
                    isSuccess = true
                };
            }
            return response;
        }

        [Route("api/Authentication")]
        [HttpPost]
        //[Authorize]
        public async Task<EmpLeaveResponse> Authentication([FromBody] LoginViewModel student)
        {
            EmpLeaveResponse response = null;
            UserService a = new UserService(Configuration);
            var Result = a.Authenticate(student);
            if (Result.Count == 0)
            {
                response = new EmpLeaveResponse
                {
                    Response = false,
                    Message = "Invalid Credentials."
                };

                return response;
            }
            //else
            //{
            //    response = new EmpLeaveResponse
            //    {
            //        Response = false,
            //        Message = "Invalid Credentials."
            //    };
            //}



            //var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name,student.username),
            //        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            //                        };
            //var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]));
            //var token = new JwtSecurityToken(
            //    issuer: Configuration["JWT:ValidIsuser"],
            //    audience: Configuration["JWT:ValidAudience"],
            //    expires: DateTime.Now.AddDays(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
            //    );

            //string tokenval= new JwtSecurityTokenHandler().WriteToken(token);


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,student.username),
                //new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            string tokenval= new JwtSecurityTokenHandler().WriteToken(token);


            response = new EmpLeaveResponse
            {
                Response = true,
                Message = tokenval
            };
            return response;
        }



    }
}
