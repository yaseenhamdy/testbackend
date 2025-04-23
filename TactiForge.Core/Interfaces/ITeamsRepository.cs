using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Core.Interfaces
{
    public interface ITeamsRepository
    {
        Task<Team?> GetByIdAsync(int id);
        Task<IReadOnlyList<Team>> GetAllAsync();
        Task<Team?> GetTeamByNameAsync(string name); // Add this method
    }
}
