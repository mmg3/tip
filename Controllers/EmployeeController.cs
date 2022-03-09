using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDTO> GetAll(int id)
        {
            return await _employeeService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<EmployeeDTO> Delete(int id)
        {
            return await _employeeService.Delete(id);
        }

        [HttpPost]
        public async Task<EmployeeDTO> GetAll([FromBody] EmployeeDTO entidad)
        {
            return await _employeeService.SaveOrUpdate(entidad);
        }
    }
}