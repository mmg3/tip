using TIP.Dtos;
using TIP.Helpers;
using TIP.IRepositories;
using TIP.IServices;
using TIP.Models;

namespace TIP.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEnterpriseRepository enterpriseRepository)
        {
            _departmentRepository = departmentRepository;
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<DepartmentDTO> SaveOrUpdate(DepartmentDTO entityDTO)
        {
            Department department = new();

            department = AutoMapperHelper<DepartmentDTO, Department>.Map(entityDTO);

            if (department.Id > 0)
            {
                department = await _departmentRepository.Update(department);
            }
            else
            {
                department = await _departmentRepository.Save(department);
            }
            entityDTO = AutoMapperHelper<Department, DepartmentDTO>.Map(department);

            return entityDTO;
        }

        public async Task<DepartmentDTO> Delete(int idDepartment)
        {
            DepartmentDTO entityDTO = new();

            Department department = await _departmentRepository.GetById(idDepartment);

            if (department != null && department.Status)
            {
                department.Status = false;

                department = AutoMapperHelper<DepartmentDTO, Department>.Map(entityDTO);
                department = await _departmentRepository.Update(department);

                entityDTO = AutoMapperHelper<Department, DepartmentDTO>.Map(department);
            }

            return entityDTO;
        }

        public async Task<DepartmentDTO> FindById(int idDepartment)
        {
            Department department = await _departmentRepository.GetById(idDepartment);

            DepartmentDTO entityDTO = AutoMapperHelper<Department, DepartmentDTO>.Map(department);

            return entityDTO;
        }

        public async Task<List<DepartmentDTO>> GetAll()
        {
            List<Department> departments = await _departmentRepository.GetAll();

            List<DepartmentDTO> entityDTO = AutoMapperHelper<Department, DepartmentDTO>.MapList(departments);

            return entityDTO;
        }
    }
}
