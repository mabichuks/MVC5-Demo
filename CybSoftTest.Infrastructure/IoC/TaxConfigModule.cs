using CybSoftTest.Infrastructure.Repositories;
using Ninject.Modules;

namespace CybSoftTest.Infrastructure.IoC
{
    public class TaxConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IComputePayeRepository>().To<ComputePayeRepository>();
        }
    }
}
