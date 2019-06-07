using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Entities
{
    public class TaxConfig
    {
        public int Id { get; set; }
        public double Monthly { get; set; }
        public double Rate { get; set; }
    }
}
