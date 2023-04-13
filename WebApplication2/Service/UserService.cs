using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TM.Model.Business.EmployeeManagement;

namespace WebApplication2.Service
{
    public class UserService
    {
        //DataContext dataContext = new DataContext();
        public UserService(IConfiguration _configuration) { Configuration = _configuration; }
        private static IConfiguration Configuration;

        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";
        public IList<LoginViewModel> Authenticate(LoginViewModel loginViewModel)
        {
            using (var dbConn = new SqlConnection(str1))
            {
                string strQuery = string.Empty;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_EMPLOYEE_DTL WHERE USERNAME='" + loginViewModel.username + "' AND PASSWORD='" + loginViewModel.password + "'";
                    var a = dbConn.Query<LoginViewModel>(strQuery);
                }
                catch (System.Exception ex)
                {

                    throw;
                }

                return dbConn.Query<LoginViewModel>(strQuery).ToList();
            }

        }
    }
}
