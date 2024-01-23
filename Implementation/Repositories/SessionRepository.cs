using Backend.Context;
using Backend.Entities;
using Backend.Interface.Repositories;

namespace Backend.Implementation.Repositories
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}