using Microsoft.EntityFrameworkCore;
using TIP.Contexts;
using TIP.IRepositories;
using TIP.Models;

namespace TIP.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private TIPContext _context;

        public EnterpriseRepository(TIPContext context)
        {
            _context = context;
        }

        public async Task<List<Enterprise>> GetAll()
        {
            List<Enterprise> listAll = new();
            try
            {
                listAll = await _context.Enterprises.AsNoTracking()
                                        .ToListAsync()
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                listAll = null;
            }
            return listAll;
        }

        public async Task<Enterprise> GetById(int id)
        {
            Enterprise entity = new();
            try
            {
                entity = await _context.Enterprises.AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id)
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Enterprise> Save(Enterprise entity)
        {
            try
            {
                _context.Enterprises.Attach(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Enterprise> Update(Enterprise entity)
        {
            try
            {
                _context.Enterprises.Update(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }
    }
}
