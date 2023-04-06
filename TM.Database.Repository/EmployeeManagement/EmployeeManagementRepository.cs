using Dapper;
using Microsoft.Extensions.Configuration;
using Phoenix.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace TM.Database.Repository.EmployeeManagement
{
    public class EmployeeManagementRepository: BaseRepository
    {
        private readonly IConfiguration configuration;
        public EmployeeManagementRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";
        public async Task<List<Student>> GetEmployeeDetails()
        {
            List<Student> students = new List<Student>();
            using (var dbConn = new SqlConnection(str1))
            {
                string strQuery = string.Empty;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_STUDENT_DTL";
                    students = (await dbConn.QueryAsync<Student>(strQuery)).ToList();
                }
                catch (System.Exception ex)
                {

                    throw;
                }

                return students;
            }
        }
    }
}
