using System.Linq.Expressions;
using Backend.Entities;

namespace Backend.Interface.Repositories
{
    public interface IResultRepository : IBaseRepository<Result>
    {
        Task<List<Result>> GetAllResult(Expression<Func<Result, bool>> expression);
    }
}
