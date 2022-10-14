//this communicates with the database
using Interface.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Data
{
    //the class interfacedbcontext inherits from dbcontext class
    //this is what creates thetable needed
    public class InterfaceDbContext : DbContext
    {
        public InterfaceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Users> Users { get; set; }
        //protected override void onModelCreation(ModelBuilder modelBuilder) {
        //    modelBuilder.Entity<LoginModel>().HasData(new LoginModel
        //    {
        //        Email = '',
        //        Password = ''
        //    });
        //}
    }
}
