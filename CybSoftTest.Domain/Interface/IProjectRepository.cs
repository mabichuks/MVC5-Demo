using CybSoftTest.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CybSoftTest.Domain.Interface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectModel>> GetAll();
        Task<ProjectModel> GetSingle(int id);
        Task Add(ProjectModel model);
        Task AddRange(IEnumerable<ProjectModel> models);
        Task Remove(int id);
        Task Update(ProjectModel model);
        Task<IEnumerable<ProjectModel>> GetProjectByStaff(int staffId);
    }
}
