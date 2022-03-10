using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("[controller]")]
    public class DepartmentEmployeeController : ControllerBase
    {
        private IDepartmentEmployeeService _departmentEmployeeService;
        private IDepartmentService _departmentService;
        private IEmployeeService _employeeService;

        public DepartmentEmployeeController(IDepartmentEmployeeService departmentEmployeeService, IDepartmentService departmentService,
            IEmployeeService employeeService)
        {
            _departmentEmployeeService = departmentEmployeeService;
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<DepartmentEmployeeDTO>> GetAll()
        {
            var depeps = await _departmentEmployeeService.GetAll();

            foreach(var d in depeps)
            {
                var emp = await _employeeService.FindById(d.IdEmployee);
                var dep = await _departmentService.FindById(d.IdDepartment);

                d.DepartmentNav = dep;
                d.EmployeeNav = emp;
                d.EmpName = emp.Name + " " + emp.Surname;
                d.DepName = dep.Name;
            }

            return depeps;
        }

        [HttpGet("{id}")]
        public async Task<DepartmentEmployeeDTO> FindById(int id)
        {
            return await _departmentEmployeeService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<DepartmentEmployeeDTO> Delete(int id)
        {
            return await _departmentEmployeeService.Delete(id);
        }

        [HttpPost]
        public async Task<DepartmentEmployeeDTO> SaveOrUpdate([FromBody] DepartmentEmployeeDTO entidad)
        {
            return await _departmentEmployeeService.SaveOrUpdate(entidad);
        }
    }
}