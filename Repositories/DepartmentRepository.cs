using Microsoft.EntityFrameworkCore;
using TIP.Contexts;
using TIP.IRepositories;
using TIP.Models;

namespace TIP.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private TIPContext _context;

        public DepartmentRepository(TIPContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAll()
        {
            List<Department> listAll = new();
            try
            {
                listAll = await _context.Departments
                                        .AsNoTracking()
                                        .Include(i => i.EnterpriseNav)
                                        .ToListAsync()
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                listAll = null;
            }
            return listAll;
        }

        public async Task<Department> GetById(int id)
        {
            Department entity = new();
            try
            {
                entity = await _context.Departments
                                        .AsNoTracking()
                                        .Include(i => i.EnterpriseNav)
                                        .FirstOrDefaultAsync(x => x.Id == id)
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Department> Save(Department entity)
        {
            try
            {
                _context.Departments.Attach(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Department> Update(Department entity)
        {
            try
            {
                _context.Departments.Update(entity);

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
