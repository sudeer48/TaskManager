using Microsoft.Extensions.Configuration;
using Phoenix.Infrastructure.Dapper;
using TM.Model.Business.EmployeeManagement;
using System.Data.SqlClient;
using Dapper;
using TM.Infrastructure.EntityFramework;

namespace TM.Database.Repository.EmployeeManagement
{
    public class EmployeeManagementRepository: BaseRepository
    {
        private readonly IConfiguration configuration;
        EmployeeDbContext _dbContext = new EmployeeDbContext();
        public EmployeeManagementRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";
        public async Task<List<EmployeeDetails>> GetEmployeeDetails()
        {
            List<EmployeeDetails> students = new List<EmployeeDetails>();
            try
            {
                var data = this._dbContext.employeeDetails.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
       

            using (var dbConn = new SqlConnection(str1))
            {
                GetRoleDetails();
                string strQuery = string.Empty;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_EMPLOYEE_DTL";
                    students = (await dbConn.QueryAsync<EmployeeDetails>(strQuery)).ToList();
                }
                catch (System.Exception ex)
                {

                    throw;
                }

                return students;
            }
        }

        public async Task<List<RoleInformation>> GetRoleDetails()
        {
            List<RoleInformation> students = new List<RoleInformation>();
            using (var dbConn = new SqlConnection(str1))
            {
                string strQuery = string.Empty;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_ROLEMST";
                    students = (await dbConn.QueryAsync<RoleInformation>(strQuery)).ToList();
                }
                catch (System.Exception ex)
                {

                    throw;
                }

                return students;
            }
        }

        public async Task<EmpLeaveResponse> DeleteRecord(int studentid)
        {
            EmpLeaveResponse response = null;
            int affectedRows = 0;
            using (var connection = new SqlConnection(str1))
            {
                EmployeeDetails objstd = new EmployeeDetails();

                try
                {

                    connection.Open();
                    affectedRows = connection.Execute(@"DELETE FROM TBL_EMPLOYEE_DTL where Id='" + studentid + "'");
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


    }
}
