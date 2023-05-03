using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Database.Repository.Administration;
using TM.Database.Repository.EmployeeManagement;
using TM.Domain.Administration.Interfaces;
using TM.Model.Business.EmployeeManagement;

namespace TM.Domain.Administration.Implementations
{
    public class AdministrationDomain : IAdministrationDomain
    {
        private readonly IConfiguration configuration;

        public AdministrationDomain(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<MenuDetails>> MenuItemDetails()
        {
            List<MenuDetails> menuDetails = null;
            using (AdministrationRepository administrationRepository = new(configuration))
            {
                menuDetails = await administrationRepository.MenuItemDetails();
            }
            return menuDetails;
        }
    }
}
