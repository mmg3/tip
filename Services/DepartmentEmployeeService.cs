using TIP.Dtos;
using TIP.Helpers;
using TIP.IRepositories;
using TIP.IServices;
using TIP.Models;

namespace TIP.Services
{
    public class DepartmentEmployeeService : IDepartmentEmployeeService
    {
        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepository;

        public DepartmentEmployeeService(IDepartmentEmployeeRepository departmentEmployeeRepository)
        {
            _departmentEmployeeRepository = departmentEmployeeRepository;
        }

        public async Task<DepartmentEmployeeDTO> SaveOrUpdate(DepartmentEmployeeDTO entityDTO)
        {
            DepartmentEmployee departmentEmployee = new();

            departmentEmployee = AutoMapperHelper<DepartmentEmployeeDTO, DepartmentEmployee>.Map(entityDTO);

            if (departmentEmployee.Id > 0)
            {
                departmentEmployee = await _departmentEmployeeRepository.Update(departmentEmployee);
            }
            else
            {
                departmentEmployee = await _departmentEmployeeRepository.Save(departmentEmployee);
            }
            entityDTO = AutoMapperHelper<DepartmentEmployee, DepartmentEmployeeDTO>.Map(departmentEmployee);

            return entityDTO;
        }

        public async Task<DepartmentEmployeeDTO> Delete(int idDepartmentEmployee)
        {
            DepartmentEmployeeDTO entityDTO = new();

            DepartmentEmployee departmentEmployee = await _departmentEmployeeRepository.GetById(idDepartmentEmployee);

            if (departmentEmployee != null && departmentEmployee.Status)
            {
                departmentEmployee.Status = false;

                departmentEmployee = AutoMapperHelper<DepartmentEmployeeDTO, DepartmentEmployee>.Map(entityDTO);
                departmentEmployee = await _departmentEmployeeRepository.Update(departmentEmployee);

                entityDTO = AutoMapperHelper<DepartmentEmployee, DepartmentEmployeeDTO>.Map(departmentEmployee);
            }

            return entityDTO;
        }

        public async Task<DepartmentEmployeeDTO> FindById(int idDepartmentEmployee)
        {
            DepartmentEmployee departmentEmployee = await _departmentEmployeeRepository.GetById(idDepartmentEmployee);

            DepartmentEmployeeDTO entityDTO = AutoMapperHelper<DepartmentEmployee, DepartmentEmployeeDTO>.Map(departmentEmployee);

            return entityDTO;
        }

        public async Task<List<DepartmentEmployeeDTO>> GetAll()
        {
            List<DepartmentEmployee> departmentEmployees = await _departmentEmployeeRepository.GetAll();

            List<DepartmentEmployeeDTO> entityDTO = AutoMapperHelper<DepartmentEmployee, DepartmentEmployeeDTO>.MapList(departmentEmployees);

            return entityDTO;
        }
    }
}
