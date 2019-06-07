using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Domain.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentModel>> GetAll();
        Task<DepartmentModel> GetSingle(int id);
        Task Add(DepartmentModel model);
        Task AddRange(IEnumerable<DepartmentModel> models);
        Task Remove(int id);
    }
}
