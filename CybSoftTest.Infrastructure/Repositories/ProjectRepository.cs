using CybSoftTest.Domain;
using CybSoftTest.Domain.Domain;
using CybSoftTest.Domain.Interface;
using CybSoftTest.Infrastructure.Data;
using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _ctxt;

        public ProjectRepository(AppDbContext ctxt)
        {
            _ctxt = ctxt;
        }
        public async Task Add(ProjectModel model)
        {
            var project = new Project().Assign(model);
            project.StaffId = model.Staff.Id;
            _ctxt.Set<Project>().Add(project);
            await _ctxt.SaveChangesAsync();

        }

        public Task AddRange(IEnumerable<ProjectModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectModel>> GetAll()
        {
            var query = from project in _ctxt.Set<Project>()
                        select new ProjectModel
                        {
                            Id = project.Id,
                            Name = project.Name,
                            Description = project.Description,
                            StartDate = project.StartDate,
                            EndDate = project.EndDate,
                            IsComplete = project.IsComplete,
                            Staff = new StaffModel { Id = project.StaffId, FirstName = project.Staff.FirstName, LastName = project.Staff.LastName }
                        };
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectByStaff(int staffId)
        {
            var query = from project in _ctxt.Set<Project>()
                        where project.StaffId == staffId
                        select new ProjectModel
                        {
                            Id = project.Id,
                            Name = project.Name,
                            Description = project.Description,
                            StartDate = project.StartDate,
                            EndDate = project.EndDate,
                            IsComplete = project.IsComplete,
                            Staff = new StaffModel { Id = project.StaffId, FirstName = project.Staff.FirstName, LastName = project.Staff.LastName }
                        };

            return await query.ToListAsync();
        }

        public async Task<ProjectModel> GetSingle(int id)
        {
            var query = from project in _ctxt.Set<Project>()
                        where project.Id == id
                        select new ProjectModel
                        {
                            Id = project.Id,
                            Name = project.Name,
                            Description = project.Description,
                            StartDate = project.StartDate,
                            EndDate = project.EndDate,
                            IsComplete = project.IsComplete,
                            Staff = new StaffModel { Id = project.StaffId, FirstName = project.Staff.FirstName, LastName = project.Staff.LastName }
                        };
            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(int id)
        {
            var project = await _ctxt.Set<Project>().FirstOrDefaultAsync(p => p.Id == id);
            _ctxt.Set<Project>().Remove(project);
            _ctxt.SaveChanges();
        }

        public async Task Update(ProjectModel model)
        {
            var project = await _ctxt.Set<Project>().FirstOrDefaultAsync(p => p.Id == model.Id);
            if (model == null) throw new Exception("Staff not found");
            project.Name = model.Name;
            project.StaffId = model.Staff.Id;
            project.Description = model.Description;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;

            await _ctxt.SaveChangesAsync();

        }
    }
}
