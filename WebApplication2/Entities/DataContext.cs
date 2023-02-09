using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Student> details { get; set; }
    }
}
