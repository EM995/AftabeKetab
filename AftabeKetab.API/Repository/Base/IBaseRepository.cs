using System.Linq.Expressions;

namespace AftabeKetab.API.Repository
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(Guid id, T entity);
        void Delete(T entity);
    }
}
