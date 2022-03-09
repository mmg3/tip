using TIP.Dtos;
using TIP.Helpers;
using TIP.IRepositories;
using TIP.IServices;
using TIP.Models;

namespace TIP.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDTO> SaveOrUpdate(EmployeeDTO entityDTO)
        {
            Employee employee = new();

            employee = AutoMapperHelper<EmployeeDTO, Employee>.Map(entityDTO);

            if (employee.Id > 0)
            {
                employee = await _employeeRepository.Update(employee);
            }
            else
            {
                employee = await _employeeRepository.Save(employee);
            }
            entityDTO = AutoMapperHelper<Employee, EmployeeDTO>.Map(employee);

            return entityDTO;
        }

        public async Task<EmployeeDTO> Delete(int idEmployee)
        {
            EmployeeDTO entityDTO = new();

            Employee employee = await _employeeRepository.GetById(idEmployee);

            if (employee != null && employee.Status)
            {
                employee.Status = false;

                employee = AutoMapperHelper<EmployeeDTO, Employee>.Map(entityDTO);
                employee = await _employeeRepository.Update(employee);

                entityDTO = AutoMapperHelper<Employee, EmployeeDTO>.Map(employee);
            }

            return entityDTO;
        }

        public async Task<EmployeeDTO> FindById(int idEmployee)
        {
            Employee employee = await _employeeRepository.GetById(idEmployee);

            EmployeeDTO entityDTO = AutoMapperHelper<Employee, EmployeeDTO>.Map(employee);

            return entityDTO;
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();

            List<EmployeeDTO> entityDTO = AutoMapperHelper<Employee, EmployeeDTO>.MapList(employees);

            return entityDTO;
        }
    }
}
