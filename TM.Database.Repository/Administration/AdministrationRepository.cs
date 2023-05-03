using Microsoft.Extensions.Configuration;
using Phoenix.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Infrastructure.EntityFramework;
using TM.Model.Business.EmployeeManagement;

namespace TM.Database.Repository.Administration
{
    public class AdministrationRepository: BaseRepository
    {
        private readonly IConfiguration configuration;
        EmployeeDbContext _dbContext = new EmployeeDbContext();
        public AdministrationRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<MenuDetails>> MenuItemDetails()
        {
            List<MenuDetails> menuDetails = null;
            menuDetails = this._dbContext.menuDetails.ToList();
            return menuDetails;
        }
    }
}
