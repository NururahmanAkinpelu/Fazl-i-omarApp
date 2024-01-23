using Backend.Contract;
using System.Linq.Expressions;

namespace Backend.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<T> Register(T entity);

        Task<T> Update(T entity);

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task<IList<T>> GetAll();
        Task<List<T>> GetAllByIdsAsync(List<Guid> ids);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression);
    }
}
