using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Data
{
    public class MockDepartments
    {
        public static IEnumerable<Department> Departments
        {
            get
            {
                return new List<Department>
                {
                    new Department
                    {
                        Id =1,
                        Name = "LTE"
                    },

                    new Department
                    {
                        Id = 2,
                        Name= "Cyber Academy"
                    },

                    new Department
                    {
                        Id = 3,
                        Name= "CybSoft"
                    },

                    new Department
                    {
                        Id =4,
                        Name= "Cyber Cloud"
                    },

                    new Department
                    {
                        Id= 5,
                        Name= "FinTech"
                    }
                };
            }
        }

    }

    public class MockStaff
    {
        public static IEnumerable<Staff> Staff
        {
            get
            {
                return new List<Staff>
                {
                    new Staff
                    {
                        Id = 1,
                        FirstName = "Chukwuma",
                        LastName = "Mabi",
                        Address = "V.I",
                        DateOfBirth = DateTime.Now,
                        Department = MockDepartments.Departments.FirstOrDefault(),
                        StaffNumber = "CYB4as4xh"
                    }

                };
            }
        }

    }




}

