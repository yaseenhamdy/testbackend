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
    public class TeamsRepository : ITeamsRepository
    {
        private readonly Fifa24DbContext fifaDbContext;

        public TeamsRepository(Fifa24DbContext fifaDbContext)
        {
            this.fifaDbContext = fifaDbContext;
        }
        public async Task<IReadOnlyList<Team>> GetAllAsync()

          => await fifaDbContext.Teams.ToListAsync();


        public async Task<Team?> GetByIdAsync(int id)

            => await fifaDbContext.Teams.FindAsync(id);

        public async Task<Team?> GetTeamByNameAsync(string name)
        {
            return await fifaDbContext.Teams
                .FirstOrDefaultAsync(t => t.TeamName == name);
        }

    }
}
