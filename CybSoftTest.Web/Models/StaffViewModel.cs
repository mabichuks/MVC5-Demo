using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CybSoftTest.Web.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }
        public IEnumerable<DepartmentModel> Departments { get; set; }
    }
}