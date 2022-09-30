//this communicates with the database
using Interface.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Data
{
    //the class interfacedbcontext inherits from dbcontext class
    public class InterfaceDbContext : DbContext
    {
        public InterfaceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
