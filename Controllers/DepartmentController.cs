using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDTO>> GetAll()
        {
            return await _departmentService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<DepartmentDTO> GetAll(int id)
        {
            return await _departmentService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<DepartmentDTO> Delete(int id)
        {
            return await _departmentService.Delete(id);
        }

        [HttpPost]
        public async Task<DepartmentDTO> GetAll([FromBody] DepartmentDTO entidad)
        {
            return await _departmentService.SaveOrUpdate(entidad);
        }
    }
}