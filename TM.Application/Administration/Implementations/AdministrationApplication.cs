using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Administration.Interfaces;
using TM.Domain.Administration.Interfaces;
using TM.Domain.EmployeeManagement.Implementations;
using TM.Model.Business.EmployeeManagement;

namespace TM.Application.Administration.Implementations
{
    public class AdministrationApplication : IAdministrationApplication
    {
        private readonly IAdministrationDomain administrationDomain;
        public AdministrationApplication(IAdministrationDomain administrationDomain)
        {
            this.administrationDomain = administrationDomain;
        }

        public async Task<List<MenuDetails>> MenuItemDetails()
        {
            List<MenuDetails> menuDetails = await administrationDomain.MenuItemDetails();
            return menuDetails;
        }
    }
}
