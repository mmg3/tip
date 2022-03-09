using TIP.Dtos;

namespace TIP.IServices
{
    public interface IDepartmentEmployeeService
    {
        Task<DepartmentEmployeeDTO> Delete(int idDepartmentEmployee);
        Task<DepartmentEmployeeDTO> FindById(int idDepartmentEmployee);
        Task<List<DepartmentEmployeeDTO>> GetAll();
        Task<DepartmentEmployeeDTO> SaveOrUpdate(DepartmentEmployeeDTO entityDTO);
    }
}