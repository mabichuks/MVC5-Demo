using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CybSoftTest.Web.Models
{
    public class ProjectListViewModel
    {
        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}