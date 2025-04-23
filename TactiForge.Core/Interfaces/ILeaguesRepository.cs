using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Core.Interfaces
{
    public interface ILeaguesRepository
    {
        Task<League?> GetByIdAsync(int id);
        Task<IReadOnlyList<League>> GetAllAsync();
    }
}
