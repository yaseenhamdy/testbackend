using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactiForge.Core.Interfaces;
using TactiForge.Repository.Data.Context;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Repository.Repositories
{
    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly Fifa24DbContext fifaDbContext;

        public LeaguesRepository(Fifa24DbContext fifaDbContext)
        {
            this.fifaDbContext = fifaDbContext;
        }
        public async Task<IReadOnlyList<League>> GetAllAsync()
        
          => await fifaDbContext.Leagues.ToListAsync();
        

        public async Task<League?> GetByIdAsync(int id)
        
            => await fifaDbContext.Leagues.FindAsync(id);
        
    }
}
