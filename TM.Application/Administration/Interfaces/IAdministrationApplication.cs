using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Model.Business.EmployeeManagement;

namespace TM.Application.Administration.Interfaces
{
    public interface IAdministrationApplication
    {
        Task<List<MenuDetails>> MenuItemDetails();

    }
}
