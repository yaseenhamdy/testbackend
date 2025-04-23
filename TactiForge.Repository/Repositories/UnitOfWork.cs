using System.Collections;
using TactiForge.Core.Interfaces;
using TactiForge.Repository.Data.Context;
using TactiForge.Repository.Entities;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Fifa24DbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(Fifa24DbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        //public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        //{
        //    var type = typeof(TEntity).Name;
        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repository = new GenericRepository<TEntity>(_context);
        //        _repositories.Add(type, repository);
        //    }
        //    return _repositories[type] as IGenericRepository<TEntity>;
        //}

        public IPlayersRepository PlayersRepository
        {
            get
            {
                var type = typeof(Player).Name;
                if (!_repositories.ContainsKey(type))
                {
                    var repository = new PlayersRepository(_context);
                    _repositories.Add(type, repository);
                }
                return _repositories[type] as IPlayersRepository;
            }
        }

        public ICoachesRepository CoachesRepository
        {
            get
            {
                var type = typeof(Coach).Name; // Use 'Coach' as the entity type
                if (!_repositories.ContainsKey(type))
                {
                    var repository = new CoachesRepository(_context);
                    _repositories.Add(type, repository);
                }
                return _repositories[type] as ICoachesRepository;
            }
        }


        public ILeaguesRepository LeaguesRepository
        {
            get
            {
                var type = typeof(League).Name; // Use 'League' as the entity type
                if (!_repositories.ContainsKey(type))
                {
                    var repository = new LeaguesRepository(_context);
                    _repositories.Add(type, repository);
                }
                return _repositories[type] as ILeaguesRepository;
            }
        }

        public ITeamsRepository TeamsRepository
        {
            get
            {
                var type = typeof(Team).Name; // Use 'Team' as the entity type
                if (!_repositories.ContainsKey(type))
                {
                    var repository = new TeamsRepository(_context);
                    _repositories.Add(type, repository);
                }
                return _repositories[type] as ITeamsRepository;
            }
        }
    }
}
