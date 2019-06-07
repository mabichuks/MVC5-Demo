using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext():base("CybTestDb")
        {

        }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TaxConfig> TaxConfigs { get; set; }
    }
}
