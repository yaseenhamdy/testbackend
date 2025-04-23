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
    public class PlayersRepository : IPlayersRepository
    {
        private readonly Fifa24DbContext fifaDbContext;

        public PlayersRepository(Fifa24DbContext fifaDbContext)
        {
            this.fifaDbContext = fifaDbContext;
        }
        public async Task<IReadOnlyList<Player>> GetAllAsync()
          => await fifaDbContext.Players.ToListAsync();


        public async Task<Player?> GetByIdAsync(int id)
            => await fifaDbContext.Players.FindAsync(id);

        public async Task<IReadOnlyList<Player>> GetPlayersInTeamAsync(int teamId)
             => await fifaDbContext.Players.Where(p => p.ClubTeamId == teamId)
                               .ToListAsync();

    }
}
