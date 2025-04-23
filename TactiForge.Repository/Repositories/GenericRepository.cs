using Microsoft.EntityFrameworkCore;
using TactiForge.Core.Interfaces;
using TactiForge.Repository.Data.Context;

namespace TactiForge.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Fifa24DbContext _context;

        public GenericRepository(Fifa24DbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

  
    }
}
