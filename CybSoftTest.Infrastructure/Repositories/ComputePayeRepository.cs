using CybSoftTest.Infrastructure.Data;
using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Repositories
{
    public class ComputePayeRepository:IComputePayeRepository
    {
        private readonly AppDbContext _ctxt;
        public Dictionary<double, double> Dictionary { get; set; } = new Dictionary<double, double>();
        public  double TotalTax { get; set; }
        public  double FinalBalance { get; set; }

        public ComputePayeRepository(AppDbContext ctxt)
        {
            _ctxt = ctxt;
        }

        public double ComputePaye(double salary)
        {
            var taxConfig = _ctxt.Set<TaxConfig>().ToArray();
            var monthly = new List<double>();
            var rate = new List<double>();

            foreach(var taxcon in taxConfig)
            {
                monthly.Add(taxcon.Monthly);
                rate.Add(taxcon.Rate);
            }

            double deductable = salary;
            var balance = salary;
            double tax = 0;
            Dictionary = new Dictionary<double, double>();


            for (var i = 0; i < monthly.ToArray().Length; i++)
            {
                if (deductable > monthly[i])
                {
                    deductable = deductable - monthly[i];
                    tax = tax + (rate[i] * monthly[i]);
                    balance = salary - tax;
                    Dictionary.Add(balance, tax);
                    TotalTax = tax;
                    FinalBalance = balance;
                }

                if (deductable < monthly[i])
                {

                    break;
                }

            }

            return tax;
        }
    }
}
