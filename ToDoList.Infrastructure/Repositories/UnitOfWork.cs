using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories
{
    public class UnitOfWork(ToDoListContext context, IToDoListListRepository _toDoListRepository, IToDoListSingleEntryRepository _singleEntryRepository) : IUnitOfWork
    {
        public IToDoListListRepository ToDoListListRepository { get; } = _toDoListRepository;
        public IToDoListSingleEntryRepository ToDoListSingleEntryRepository { get; } = _singleEntryRepository;

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }     
    }
}
