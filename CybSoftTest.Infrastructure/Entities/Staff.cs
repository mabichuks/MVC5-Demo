using System;

namespace CybSoftTest.Infrastructure.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
    }   
}