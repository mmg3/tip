using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [EnableCors("AllowOrigin")]
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
        public async Task<EmployeeDTO> FindById(int id)
        {
            return await _employeeService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<EmployeeDTO> Delete(int id)
        {
            return await _employeeService.Delete(id);
        }

        [HttpPost]
        public async Task<EmployeeDTO> SaveOrUpdate([FromBody] EmployeeDTO entidad)
        {
            return await _employeeService.SaveOrUpdate(entidad);
        }
    }
}