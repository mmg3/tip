using TIP.Models;

namespace TIP.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<Department> Save(Department entity);
        Task<Department> Update(Department entity);
    }
}