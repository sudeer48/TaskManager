using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TM.Helper.Helper;
using TM.Model.Business.EmployeeManagement;

namespace WebApplication2.Service
{
    public class UserService
    {
        //DataContext dataContext = new DataContext();
        public UserService(IConfiguration _configuration) { Configuration = _configuration; }
        private static IConfiguration Configuration;

        string str1 = "Data Source=.;Initial Catalog=TaskManager;Integrated Security=True";
        public bool Authenticate(LoginViewModel loginViewModel)
        {
            using (var dbConn = new SqlConnection(str1))
            {
                bool isLogin = false;
                string strQuery = string.Empty;
                string decryptedVal = string.Empty;
                List<LoginViewModel> loginViewModels = null;
                try
                {
                    dbConn.Open();
                    strQuery = @"SELECT * FROM TBL_EMPLOYEE_DTL WHERE USERNAME='" + loginViewModel.username + "'";
                    loginViewModels = dbConn.Query<LoginViewModel>(strQuery).ToList();
                    if (loginViewModels.Count > 0)
                    {
                        //string encryptVal= EncryptDecrypt.EncryptString(loginViewModels.FirstOrDefault().password, ApplicationSettings.Current.Key);
                        decryptedVal = EncryptDecrypt.DecryptString(loginViewModels.FirstOrDefault().password, ApplicationSettings.Current.Key);
                    }
                    else
                    {
                        return isLogin;
                    }

                    if (loginViewModel.password == decryptedVal)
                    {
                        isLogin = true;
                    }
                    else
                    {
                        isLogin = false;
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }

                return isLogin;
            }

        }
    }
}
