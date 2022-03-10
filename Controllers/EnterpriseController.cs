using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<EnterpriseDTO> FindById(int id)
        {
            return await _enterpriseService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task<EnterpriseDTO> Delete(int id)
        {
            return await _enterpriseService.Delete(id);
        }

        [HttpPost]
        public async Task<EnterpriseDTO> SaveOrUpdate(string entidad)
        {
            EnterpriseDTO ent = JsonConvert.DeserializeObject<EnterpriseDTO>(entidad);
            return await _enterpriseService.SaveOrUpdate(ent);
        }
    }
}