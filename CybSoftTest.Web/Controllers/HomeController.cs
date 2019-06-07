using CybSoftTest.Domain;
using CybSoftTest.Domain.Domain;
using CybSoftTest.Domain.Interface;
using CybSoftTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CybSoftTest.Infrastructure.Entities;
using Rotativa;

namespace CybSoftTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private IStaffRepository _staffRepo;
        private IProjectRepository _projectRepo;
        private IDepartmentRepository _departmentRepo;

        public HomeController(IStaffRepository staffRepo, 
            IProjectRepository projectRepo, 
            IDepartmentRepository departmentRepo)
        {
            _staffRepo = staffRepo;
            _projectRepo = projectRepo;
            _departmentRepo = departmentRepo;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> StaffListView()
        {
            var staff = await _staffRepo.GetAll();
            var model = new StaffListView
            {
                Staff = staff
            };

            return View(model);
        }

        public async Task<ActionResult> PrintPdf(IEnumerable<StaffModel> model)
        {
            var staff = await _staffRepo.GetAll();
            var staffList = new StaffListView
            {
                Staff = staff
            };

            var pdf = new ViewAsPdf("StaffListView", staffList)
            {
                FileName = "File.Pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = { Left = 0, Right = 0 }
            };

            return pdf;
        }

        [HttpGet]
        public async Task<ActionResult> AddStaff()
        {
            var department = await _departmentRepo.GetAll();
            var staffmodel = new StaffViewModel
            {
                Departments = department
            };
            return View(staffmodel);
        }

        [HttpPost]
        public async Task<ActionResult> AddStaff(StaffViewModel model)
        {
            if(ModelState.IsValid)
            {
                StaffModel staff = new StaffModel().Assign(model);
                staff.Department = new DepartmentModel { Id = model.DepartmentId };

               await _staffRepo.Add(staff);

            }
            return RedirectToAction("StaffListView");


        }

        [HttpGet]
        public async Task<ActionResult> EditStaff(int id)
        {
            var staff = await _staffRepo.GetSingle(id);
            var dept = await _departmentRepo.GetAll();

            if (staff != null)
            {
                StaffViewModel model = new StaffViewModel().Assign(staff);
                model.Departments = dept;
                return View(model);
            }
            return RedirectToAction("StaffListView");
        }

        [HttpPost]
        public async Task<ActionResult> EditStaff(StaffViewModel model)
        {
            if (ModelState.IsValid)
            {

                var staff = new StaffModel().Assign(model);
                staff.Department = new DepartmentModel { Id = model.DepartmentId };
                await _staffRepo.Update(staff);
                return RedirectToAction("StaffListView");

            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            await _staffRepo.Remove(id);
            return RedirectToAction("StaffListView");
        }

        public async Task<ActionResult> GetSingleStaff(int id)
        {
            var staff = await _staffRepo.GetSingle(id);
            var svm = new StaffViewModel().Assign(staff);
            svm.DepartmentId = staff.Department.Id;
            return View(svm);
        }




    }
}