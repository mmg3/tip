using Microsoft.EntityFrameworkCore;
using TIP.Contexts;
using TIP.IRepositories;
using TIP.Models;

namespace TIP.Repositories
{
    public class DepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private TIPContext _context;

        public DepartmentEmployeeRepository(TIPContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentEmployee>> GetAll()
        {
            List<DepartmentEmployee> listAll = new();
            try
            {
                listAll = await _context.DepartmentEmployees.AsNoTracking()
                                        .ToListAsync()
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                listAll = null;
            }
            return listAll;
        }

        public async Task<DepartmentEmployee> GetById(int id)
        {
            DepartmentEmployee entity = new();
            try
            {
                entity = await _context.DepartmentEmployees.AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id)
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<DepartmentEmployee> Save(DepartmentEmployee entity)
        {
            try
            {
                _context.DepartmentEmployees.Attach(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<DepartmentEmployee> Update(DepartmentEmployee entity)
        {
            try
            {
                _context.DepartmentEmployees.Update(entity);

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
