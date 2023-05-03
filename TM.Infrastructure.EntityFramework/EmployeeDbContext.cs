using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Model.Business.EmployeeManagement;

namespace TM.Infrastructure.EntityFramework
{
    public class EmployeeDbContext : DbContext
    {
        //public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions) : base(dbContextOptions)
        //{

        //}

        

        public DbSet<EmployeeDetails> employeeDetails { get; set; }
        public DbSet<RoleInformation> roleInformation { get; set; }
        public DbSet<MenuDetails> menuDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.; initial catalog=TaskManager;persist security info=True;Integrated Security=True");
        }
    }
}
