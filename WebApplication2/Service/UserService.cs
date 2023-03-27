using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class UserService
    {
        DataContext dataContext = new DataContext();
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
                    strQuery = @"SELECT * FROM TBL_STUDENT_DTL WHERE USERNAME='" + loginViewModel.username + "' AND PASSWORD='" + loginViewModel.password + "'";
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
