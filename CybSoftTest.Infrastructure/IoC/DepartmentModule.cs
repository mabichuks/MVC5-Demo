using CybSoftTest.Domain.Interface;
using CybSoftTest.Infrastructure.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.IoC
{
    public class DepartmentModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDepartmentRepository)).To(typeof(DepartmentRepository));
        }
    }
}
