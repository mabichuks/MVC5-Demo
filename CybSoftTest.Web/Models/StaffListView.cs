using CybSoftTest.Domain.Domain;
using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CybSoftTest.Web.Models
{
    public class StaffListView
    {
        public IEnumerable<StaffModel> Staff { get; set; }
    }
}