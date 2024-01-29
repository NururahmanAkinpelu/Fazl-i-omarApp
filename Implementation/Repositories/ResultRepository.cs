using System.Linq.Expressions;
using Backend.Context;
using Backend.Entities;

using Backend.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Implementation.Repositories
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetAllResult(Expression<Func<Result, bool>> expression)
        {
            var result = _context.Results
                .Where(expression)
                .Include(r => r.Student)
                .Include(r => r.Session)
                .Include(r => r.Subject)
                .ToListAsync();

            return await result;
        }
    }
}