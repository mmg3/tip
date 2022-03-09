using TIP.Dtos;
using TIP.Helpers;
using TIP.IRepositories;
using TIP.IServices;
using TIP.Models;

namespace TIP.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseService(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<EnterpriseDTO> SaveOrUpdate(EnterpriseDTO entityDTO)
        {
            Enterprise enterprise = new();

            enterprise = AutoMapperHelper<EnterpriseDTO, Enterprise>.Map(entityDTO);

            if (enterprise.Id > 0)
            {
                enterprise = await _enterpriseRepository.Update(enterprise);
            }
            else
            {
                enterprise = await _enterpriseRepository.Save(enterprise);
            }
            entityDTO = AutoMapperHelper<Enterprise, EnterpriseDTO>.Map(enterprise);

            return entityDTO;
        }

        public async Task<EnterpriseDTO> Delete(int idEnterprise)
        {
            EnterpriseDTO entityDTO = new();

            Enterprise enterprise = await _enterpriseRepository.GetById(idEnterprise);

            if (enterprise != null && enterprise.Status)
            {
                enterprise.Status = false;

                enterprise = AutoMapperHelper<EnterpriseDTO, Enterprise>.Map(entityDTO);
                enterprise = await _enterpriseRepository.Update(enterprise);

                entityDTO = AutoMapperHelper<Enterprise, EnterpriseDTO>.Map(enterprise);
            }

            return entityDTO;
        }

        public async Task<EnterpriseDTO> FindById(int idEnterprise)
        {
            Enterprise enterprise = await _enterpriseRepository.GetById(idEnterprise);

            EnterpriseDTO entityDTO = AutoMapperHelper<Enterprise, EnterpriseDTO>.Map(enterprise);

            return entityDTO;
        }

        public async Task<List<EnterpriseDTO>> GetAll()
        {
            List<Enterprise> enterprises = await _enterpriseRepository.GetAll();

            List<EnterpriseDTO> entityDTO = AutoMapperHelper<Enterprise, EnterpriseDTO>.MapList(enterprises);

            return entityDTO;
        }
    }
}
