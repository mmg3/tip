using TIP.Dtos;

namespace TIP.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> Delete(int idEmployee);
        Task<EmployeeDTO> FindById(int idEmployee);
        Task<List<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> SaveOrUpdate(EmployeeDTO entityDTO);
    }
}