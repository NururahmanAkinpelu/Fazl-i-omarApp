using Backend.Context;
using Backend.Entities;
using Backend.Implementation.Repositories;
using Backend.Interface.Repositories;

namespace BackEnd.Implementation.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}