using CybSoftTest.Domain;
using CybSoftTest.Domain.Domain;
using CybSoftTest.Domain.Interface;
using CybSoftTest.Infrastructure.Data;
using CybSoftTest.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _ctxt;

        public StaffRepository(AppDbContext ctxt)
        {
            _ctxt = ctxt;
        }
        public async Task Add(StaffModel model)
        {
            var staff = new Staff().Assign(model);
            staff.DepartmentId = model.Department.Id;
            _ctxt.Set<Staff>().Add(staff);
            await _ctxt.SaveChangesAsync();
        }

        public Task AddRange(IEnumerable<StaffModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task Update(StaffModel model)
        {
            var staff = await _ctxt.Set<Staff>().FirstOrDefaultAsync(b => b.Id == model.Id);
            if (model == null) throw new Exception("Staff not found");
            staff.DepartmentId = model.Department.Id;
            staff.Address = model.Address;
            staff.DateOfBirth = model.DateOfBirth;
            staff.FirstName = model.FirstName;
            staff.LastName = model.LastName;
            staff.StaffNumber = model.StaffNumber;

            await _ctxt.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffModel>> GetAll()
        {
            var query = from staff in _ctxt.Set<Staff>()
                        select new StaffModel
                        {
                            Address = staff.Address,
                            DateOfBirth = staff.DateOfBirth,
                            StaffNumber = staff.StaffNumber,
                            Id = staff.Id,
                            Department = new DepartmentModel { Id = staff.DepartmentId, Name = staff.Department.Name},
                            FirstName = staff.FirstName,
                            LastName = staff.LastName
                        };

            return await query.ToListAsync();
        }

        public async Task<StaffModel> GetSingle(int id)
        {

            var query = from staff in _ctxt.Set<Staff>()
                        where staff.Id == id
                        join deparment in _ctxt.Set<Department>()
                        on staff.DepartmentId equals deparment.Id
                        into staffdept
                        from sd in staffdept
                        select new { staff, sd };

            var st = await query.FirstOrDefaultAsync();
            var model = new StaffModel().Assign(st.staff);
            model.Department = new DepartmentModel().Assign(st.sd);
            return model;
        }

        public async Task Remove(int id)                                                                                                                
        {
            var staff = await _ctxt.Set<Staff>().FirstOrDefaultAsync(s => s.Id == id);
            _ctxt.Set<Staff>().Remove(staff);
            _ctxt.SaveChanges();
        }

        public async Task Save()
        {
            await _ctxt.SaveChangesAsync();
        }
    }
}
