using CybSoftTest.Infrastructure.Repositories;
using CybSoftTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybSoftTest.Web.Controllers
{
    public class PayeController : Controller
    {
        
        private IComputePayeRepository _payeRepo;
        private static Dictionary<double, double> dictionary;


        public PayeController(IComputePayeRepository payeRepo)
        {
            _payeRepo = payeRepo;
        }
        // GET: Paye
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SalaryViewModel());
        }

        [HttpGet]
        public ActionResult GetTax(int? id)
        {
            //var tax = ComputePaye((double)id);
            var tax = _payeRepo.ComputePaye((double)id);
            var d = new TaxViewModel
            {
                Tax = _payeRepo.Dictionary
            };
            ViewBag.TotalTax = _payeRepo.TotalTax;
            ViewBag.FinalBalance = _payeRepo.FinalBalance;
            return View(d);

        }

    }
}