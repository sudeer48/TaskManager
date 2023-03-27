using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {
        DataContext dataContext = new DataContext();


        public ValuesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        private static IConfiguration Configuration;

        //static string str1 =Configuration.GetConnectionString("EmployeeConnection");
        string str1 = "User ID=PUBLICITYNEW;PASSWORD=LOCAL;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.13.75.181)(PORT=1521))(ADDRESS=(PROTOCOL=TCP)(HOST=10.13.75.181)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)))";
        // GET: api/<ValuesController>
        [Route("api/GetEmployeeDetails")]
        [HttpGet]
        public IList<Student> Get()
        {
            //var students = dataContext.details();

            using (var dbConn = new OracleConnection(str1))
            {
                string strQuery = string.Empty;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_STUDENT_DTL";
                    var a = dbConn.Query<Student>(strQuery);
                }
                catch (System.Exception ex)
                {

                    throw;
                }

                return dbConn.Query<Student>(strQuery).OrderBy(x => x.id).ToList();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [Route("api/CreateEmployee")]
        [HttpPost]
        public async Task<EmpLeaveResponse> Post([FromBody] Student students)
        {
            EmpLeaveResponse response = null;
            int affectedRows = 0;
            using (var connection = new OracleConnection(str1))
            {
                Student objstd = new Student();

                try
                {

                    connection.Open();
                    affectedRows = connection.Execute(@"Insert into TBL_STUDENT_DTL(Id, Name,SchoolId,Grade,Username,Password) values (:Id, :Name,:SchoolId,:Grade,:Username,:Password)", new { Id = students.id, Name = students.name, SchoolId = students.schoolId, Grade = students.grade, Username = students.username, Password = students.password });
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
                    Message = "Your leave request is sucessfully submitted"
                };
            }
            else
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Facing the issue while inserting."
                };
            }
            return response;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
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
            using (var connection = new OracleConnection(str1))
            {
                Student objstd = new Student();

                try
                {

                    connection.Open();
                    affectedRows = connection.Execute(@"DELETE FROM TBL_STUDENT_DTL where Id=:Id", new { Id = students.id });
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
                    Message = "Facing the issue while deleting."
                };
            }
            else
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Record deleted sucessfully."
                };
            }
            return response;
        }

        [Route("api/Authentication")]
        [HttpPost]
        public async Task<EmpLeaveResponse> Authentication([FromBody] LoginViewModel student)
        {
            EmpLeaveResponse response = null;
            UserService a = new UserService(Configuration);
            var Result = a.Authenticate(student);
            if (Result.Count == 1)
            {
                response = new EmpLeaveResponse
                {
                    Response = true,
                    Message = "Authentication Successfully."
                };
            }
            else
            {
                response = new EmpLeaveResponse
                {
                    Response = false,
                    Message = "Invalid Credentials."
                };
            }
            return response;
        }
    }
}
