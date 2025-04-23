using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TactiForge.Core.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPlayersRepository PlayersRepository { get; }
        ICoachesRepository CoachesRepository { get; }
        ITeamsRepository TeamsRepository { get; }
        ILeaguesRepository LeaguesRepository { get; }


        //IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();
    }
}
