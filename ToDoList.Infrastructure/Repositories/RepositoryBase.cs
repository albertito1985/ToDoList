using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Application.Interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected ToDoListContext Context { get; }
        protected DbSet<T> DbSet { get; }



        public RepositoryBase(ToDoListContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return trackChanges ? DbSet.Where(expression) : DbSet.Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
