using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Domain;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories
{
    public class ToDoListListRepository : RepositoryBase<ToDoListList>, IToDoListListRepository
    {
        public ToDoListListRepository(ToDoListContext context) : base(context)
        {

        }
        public async Task AddListAsync(ToDoListList list)
        {
            Context.ToDoListLists.Add(list);
        }

        public async Task<ToDoListList> GetListAsync(int id, bool trackChanges = false)
        {
            return await FindByCondition(t => t.Id.Equals(id), trackChanges).Include(t => t.Entries).FirstOrDefaultAsync();
        }

        public async Task<bool> ListExistAsync(int id)
        {
            return await Context.ToDoListLists.AnyAsync(c => c.Id == id);
        }
    }
}
