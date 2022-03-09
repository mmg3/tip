using TIP.Models;

namespace TIP.IRepositories
{
    public interface IDepartmentEmployeeRepository
    {
        Task<List<DepartmentEmployee>> GetAll();
        Task<DepartmentEmployee> GetById(int id);
        Task<DepartmentEmployee> Save(DepartmentEmployee entity);
        Task<DepartmentEmployee> Update(DepartmentEmployee entity);
    }
}