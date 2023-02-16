using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Student> details { get; set; }
    }
}
