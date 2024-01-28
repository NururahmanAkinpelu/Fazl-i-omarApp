using Backend.Context;
using Backend.Entities;

using Backend.Interface.Repositories;

namespace Backend.Implementation.Repositories
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}