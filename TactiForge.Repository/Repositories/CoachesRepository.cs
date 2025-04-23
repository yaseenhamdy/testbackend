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
    public class CoachesRepository : ICoachesRepository
    {
        private readonly Fifa24DbContext fifaDbContext;

        public CoachesRepository(Fifa24DbContext fifaDbContext)
        {
            this.fifaDbContext = fifaDbContext;
        }
        public async Task<IReadOnlyList<Coach>> GetAllAsync()

          => await fifaDbContext.Coaches.ToListAsync();


        public async Task<Coach?> GetByIdAsync(int id)
        
            => await fifaDbContext.Coaches.FindAsync(id);

        public async Task<Coach?> GetCoachByTeamIdAsync(int teamId)
        {
            return await fifaDbContext.Coaches
                .FirstOrDefaultAsync(c => c.TeamId == teamId);
        }

    }
}
