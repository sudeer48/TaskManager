using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Model.Business.EmployeeManagement
{
    [Table("TBL_MENUITEM_MT")]
    public class MenuDetails
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string RouterLink { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

    }
}
