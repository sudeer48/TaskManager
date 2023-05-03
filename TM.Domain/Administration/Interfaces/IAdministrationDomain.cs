using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Model.Business.EmployeeManagement;

namespace TM.Domain.Administration.Interfaces
{
    public interface IAdministrationDomain
    {
        Task<List<MenuDetails>> MenuItemDetails();
    }
}
