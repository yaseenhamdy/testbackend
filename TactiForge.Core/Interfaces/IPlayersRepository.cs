using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Core.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Player?> GetByIdAsync(int id);
        Task<IReadOnlyList<Player>> GetAllAsync();
        Task<IReadOnlyList<Player>> GetPlayersInTeamAsync(int teamId);
    }
}
