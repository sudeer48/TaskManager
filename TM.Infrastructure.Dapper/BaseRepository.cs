using Microsoft.Extensions.Configuration;

using System.Data;

namespace Phoenix.Infrastructure.Dapper
{
    public class BaseRepository : IDisposable, IBaseRepository
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            //_connectionString = configuration.GetConnectionString("SqlConnection");
        }
        //public async Task<IDbConnection> CreateConnection(DbSchema schema)
        //{
        //    IDbConnection con = null;

        //    switch (schema)  
        //    {
        //        case DbSchema.PORTAL:
        //            con = new OracleConnection(OracleSettings.Current.ConnectionString);
        //            break;
        //        default:
        //            break;
        //    }
        //    if (con.State == ConnectionState.Closed) con.Open();
        //    return con;
        //}
        public object LoggedInUserInformation
        {
            get
            {
                //UserInformation loggedInUserInformation;
                //if (redisCache != null)
                //{
                //    var cachedObj = redisCache.GetString("LoggedInUser");
                //    loggedInUserInformation = JsonConvert.DeserializeObject<UserInformation>(cachedObj);
                //}
                //else
                //{
                //    loggedInUserInformation = new UserInformation();
                //}
                //return loggedInUserInformation;
                return null;

            }
        }
        

        public void Dispose()
        {
        }
    }
}
