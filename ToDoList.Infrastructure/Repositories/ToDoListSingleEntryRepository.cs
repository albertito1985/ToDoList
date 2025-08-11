using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    public class ToDoListSingleEntryRepository : RepositoryBase<SingleEntry>, IToDoListSingleEntryRepository
    {
        public ToDoListSingleEntryRepository(ToDoListContext context) : base(context)
        {
        }

        //TODO: Chech if it works
        public async Task DeleteByListIdAsync(int listId)
        {
            var setToDelete = await FindByCondition(e => e.ToDoListListId == listId).ToListAsync();
            if (setToDelete.Any())
            {
                foreach (var entry in setToDelete)
                {
                    Delete(entry);
                }
            }
        }

        public async Task<SingleEntry> GetAsync(int id, bool trackChanges = false)
        {
            return await FindByCondition(t => t.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        }
    }
}
