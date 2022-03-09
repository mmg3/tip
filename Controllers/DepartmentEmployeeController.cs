using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentEmployeeController : ControllerBase
    {
        private IDepartmentEmployeeService _departmentEmployeeService;

        public DepartmentEmployeeController(IDepartmentEmployeeService departmentEmployeeService)
        {
            _departmentEmployeeService = departmentEmployeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentEmployeeDTO>> GetAll()
        {
            return await _departmentEmployeeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<DepartmentEmployeeDTO> GetAll(int id)
        {
            return await _departmentEmployeeService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<DepartmentEmployeeDTO> Delete(int id)
        {
            return await _departmentEmployeeService.Delete(id);
        }

        [HttpPost]
        public async Task<DepartmentEmployeeDTO> GetAll([FromBody] DepartmentEmployeeDTO entidad)
        {
            return await _departmentEmployeeService.SaveOrUpdate(entidad);
        }
    }
}