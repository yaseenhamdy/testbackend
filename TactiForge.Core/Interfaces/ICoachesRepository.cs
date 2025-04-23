using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Core.Interfaces
{
    public interface ICoachesRepository
    {
        Task<Coach?> GetByIdAsync(int id);
        Task<IReadOnlyList<Coach>> GetAllAsync();
        Task<Coach?> GetCoachByTeamIdAsync(int teamId); // Add this method
    }
}
