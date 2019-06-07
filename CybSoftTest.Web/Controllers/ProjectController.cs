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

namespace CybSoftTest.Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        private IStaffRepository _staffRepo;
        private IProjectRepository _projectRepo;
        private IDepartmentRepository _departmentRepo;
        public ProjectController(IStaffRepository staffRepo,
            IProjectRepository projectRepo,
            IDepartmentRepository departmentRepo)
        {
            _staffRepo = staffRepo;
            _projectRepo = projectRepo;
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult> ProjectListView()
        {
            var projects = await _projectRepo.GetAll();
            ViewBag.Staff = await _staffRepo.GetAll();
            var pvm = new ProjectListViewModel
            {
                Projects = projects
            };
            return View(pvm);
        }

        [HttpGet]
        public async Task<ActionResult> AddProject()
        {
            var staff = await _staffRepo.GetAll();
            var pvm = new ProjectViewModel
            {
                Staff = staff
            };

            return View(pvm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> AddProject(ProjectViewModel pvm)
        {
            if(ModelState.IsValid)
            {
                ProjectModel pm = new ProjectModel().Assign(pvm);
                pm.Staff = new StaffModel { Id = pvm.StaffId };
                await _projectRepo.Add(pm);
            }

            return RedirectToAction("ProjectListView");


        }

        [HttpGet]
        public async Task<ActionResult> GetProjectByStaff(int id)
        {
            var projects = await _projectRepo.GetProjectByStaff(id);
            if(projects != null)
            {
                var plvm = new ProjectListViewModel
                {
                    Projects = projects
                };

                return View(plvm);
            }

            return RedirectToAction("ProjectListView");

        }

        [HttpGet]

        public async Task<ActionResult> EditProject(int id)
        {
            var project = await _projectRepo.GetSingle(id);
            var staff = await _staffRepo.GetAll();

            if (project != null)
            {
                var model = new ProjectViewModel().Assign(project);
                model.Staff = staff;
                return View(model);
            }
            return RedirectToAction("ProjectListView");
        }

        [HttpPost]
        [ValidateInput(false)]

        public async Task<ActionResult> EditProject(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {

                var project = new ProjectModel().Assign(model);

                project.Staff = new StaffModel { Id = model.StaffId };

                await _projectRepo.Update(project);
                return RedirectToAction("ProjectListView");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectRepo.Remove(id);
            return RedirectToAction("ProjectListView");
        }
    }
}