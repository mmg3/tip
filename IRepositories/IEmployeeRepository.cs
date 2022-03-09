using TIP.Models;

namespace TIP.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Save(Employee entity);
        Task<Employee> Update(Employee entity);
    }
}