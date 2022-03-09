using TIP.Models;

namespace TIP.IRepositories
{
    public interface IEnterpriseRepository
    {
        Task<List<Enterprise>> GetAll();
        Task<Enterprise> GetById(int id);
        Task<Enterprise> Save(Enterprise entity);
        Task<Enterprise> Update(Enterprise entity);
    }
}