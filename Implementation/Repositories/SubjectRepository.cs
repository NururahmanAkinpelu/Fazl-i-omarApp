using Backend.Context;
using Backend.Entities;
using Backend.Interface.Repositories;

namespace Backend.Implementation.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}