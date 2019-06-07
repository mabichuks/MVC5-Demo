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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _ctxt;

        public DepartmentRepository(AppDbContext ctxt)
        {
            _ctxt = ctxt;
        }
        public async Task Add(DepartmentModel model)
        {
            var department = new Department().Assign(model);
            _ctxt.Set<Department>().Add(department);
            await _ctxt.SaveChangesAsync();
        }

        public Task AddRange(IEnumerable<DepartmentModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartmentModel>> GetAll()
        {
            var query = from department in _ctxt.Set<Department>()
                        select new DepartmentModel
                        {
                            Id = department.Id,
                            Name = department.Name
                        };
            return await query.ToListAsync();
        }

        public async Task<DepartmentModel> GetSingle(int id)
        {
            var query = from department in _ctxt.Set<Department>()
                        where department.Id == id
                        select new DepartmentModel
                        {
                            Id = department.Id,
                            Name = department.Name
                        };
            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(int id)
        {
            var department = await _ctxt.Set<Department>().FirstOrDefaultAsync(d => d.Id == id);
            _ctxt.Set<Department>().Remove(department);
            await _ctxt.SaveChangesAsync();
        }
    }
}
