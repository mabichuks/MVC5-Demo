using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Repositories
{
    public interface IComputePayeRepository
    {
        double TotalTax { get; set; }
        double FinalBalance { get; set; }
        Dictionary<double, double> Dictionary { get; set; }
        double ComputePaye(double salary);
    }
}
