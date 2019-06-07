using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CybSoftTest.Web.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int StaffId { get; set; }
        public bool IsComplete { get; set; }
        public IEnumerable<StaffModel> Staff { get; set; }
    }
}