using TIP.Dtos;

namespace TIP.IServices
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> Delete(int idDepartment);
        Task<DepartmentDTO> FindById(int idDepartment);
        Task<List<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> SaveOrUpdate(DepartmentDTO entityDTO);
    }
}