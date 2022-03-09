using Microsoft.EntityFrameworkCore;
using TIP.Contexts;
using TIP.IRepositories;
using TIP.Models;

namespace TIP.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private TIPContext _context;

        public EmployeeRepository(TIPContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> listAll = new();
            try
            {
                listAll = await _context.Employees.AsNoTracking()
                                        .ToListAsync()
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                listAll = null;
            }
            return listAll;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee entity = new();
            try
            {
                entity = await _context.Employees.AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id)
                                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Employee> Save(Employee entity)
        {
            try
            {
                _context.Employees.Attach(entity);

                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public async Task<Employee> Update(Employee entity)
        {
            try
            {
                _context.Employees.Update(entity);

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
