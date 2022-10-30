using AftabeKetab.DataModels;
using System.Data.Entity;
using System.Linq.Expressions;

namespace AftabeKetab.API.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AftabeKetabContext? Context { get; set; }

        public BaseRepository(AftabeKetabContext context) => Context = context;

        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => Context.Set<T>().Add(entity);

        public void Update(Guid id, T entity)
        {
            var item = Context.Set<T>().Find(id);
            Context.Entry(item).CurrentValues.SetValues(entity);
        }

        public void Delete(T entity) => Context.Entry(entity).State = EntityState.Deleted;
    }
}
