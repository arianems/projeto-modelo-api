using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using ModelAPIProject.Domain.Entities;
using ModelAPIProject.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI.Domain.Entities;
using TokenAPI.Infra.Mappings;

namespace TokenAPI.Infra.Contexts
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext()
        {

        }
        public SQLServerContext(DbContextOptions<SQLServerContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                     
            base.OnConfiguring(optionsBuilder);

            #region Retrieving the connection string from the appsettings.json file

            var configurations = new ConfigurationBuilder();

            configurations.AddJsonFile
                (Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var connectionString = configurations.Build().GetConnectionString("ModelAPI");

            #endregion


            #region Connecting the current DBContext class to a SQL Server database

            #endregion
            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
