using System.Linq.Expressions;

namespace ToDoList.Application.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        void Update(T entity);
    }
}