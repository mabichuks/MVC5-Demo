using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Domain.Interface
{
    public interface IStaffRepository
    {
        Task<IEnumerable<StaffModel>> GetAll();
        Task<StaffModel> GetSingle(int id);
        Task Update(StaffModel model);
        Task Add(StaffModel model);
        Task AddRange(IEnumerable<StaffModel> models);
        Task Remove(int id);
        Task Save();
    }
}
