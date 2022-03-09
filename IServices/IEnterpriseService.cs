using TIP.Dtos;

namespace TIP.IServices
{
    public interface IEnterpriseService
    {
        Task<EnterpriseDTO> Delete(int idEnterprise);
        Task<EnterpriseDTO> FindById(int idEnterprise);
        Task<List<EnterpriseDTO>> GetAll();
        Task<EnterpriseDTO> SaveOrUpdate(EnterpriseDTO entityDTO);
    }
}