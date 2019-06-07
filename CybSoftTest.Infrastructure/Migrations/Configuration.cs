namespace CybSoftTest.Infrastructure.Migrations
{
    using CybSoftTest.Infrastructure.Data;
    using CybSoftTest.Infrastructure.Entities;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CybSoftTest.Infrastructure.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CybSoftTest.Infrastructure.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var taxconfigs = new List<TaxConfig>()
            {
                new TaxConfig
                {
                    Id = 1,
                    Monthly = 25000,
                    Rate = 0.07
                },

                new TaxConfig
                {
                    Id = 2,
                    Monthly = 25000,
                    Rate = 0.11
                },
                new TaxConfig
                {
                    Id = 3,
                    Monthly = 41666,
                    Rate = 0.15
                },
                new TaxConfig
                {
                    Id = 4,
                    Monthly = 41666,
                    Rate = 0.19
                },
                new TaxConfig
                {
                    Id = 5,
                    Monthly = 133333,
                    Rate = 0.21
                },
                new TaxConfig
                {
                    Id = 6,
                    Monthly = 26666,
                    Rate = 0.24
                }
            };

            IEnumerable<Department> departments = MockDepartments.Departments;
            IEnumerable<Staff> staff = MockStaff.Staff;

            //context.Set<Department>().AddRange(departments);
            context.Set<TaxConfig>().AddRange(taxconfigs);
        }
    }
}
