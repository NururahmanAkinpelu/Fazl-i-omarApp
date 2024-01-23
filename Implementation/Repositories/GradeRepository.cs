using Backend.Context;
using Backend.Entities;
using Backend.Repositories;

namespace Backend.Implementation.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}