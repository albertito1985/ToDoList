using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Domain;

namespace ToDoList.Application.Services
{
    public class ToDoListSingleEntryService(IUnitOfWork uow) : IToDoListSingleEntryService
    {
        public async Task DeleteByListId(int id)
        {
            await uow.ToDoListSingleEntryRepository.DeleteByListIdAsync(id);
            await uow.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entryToDelete = await uow.ToDoListSingleEntryRepository.GetAsync(id, true);
            if (entryToDelete!= null)
            {
                uow.ToDoListSingleEntryRepository.Delete(entryToDelete);
                await uow.CompleteAsync();
            }
            
        }

        public async Task Add(SingleEntry newEntry)
        {
            uow.ToDoListSingleEntryRepository.Create(newEntry);
            await uow.CompleteAsync();
        }
    }
}
