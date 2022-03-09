using Microsoft.AspNetCore.Mvc;
using TIP.Dtos;
using TIP.IServices;

namespace TIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        [HttpGet]
        public async Task<IEnumerable<EnterpriseDTO>> GetAll()
        {
            return await _enterpriseService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<EnterpriseDTO> GetAll(int id)
        {
            return await _enterpriseService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<EnterpriseDTO> Delete(int id)
        {
            return await _enterpriseService.Delete(id);
        }

        [HttpPost]
        public async Task<EnterpriseDTO> GetAll([FromBody] EnterpriseDTO entidad)
        {
            return await _enterpriseService.SaveOrUpdate(entidad);
        }
    }
}