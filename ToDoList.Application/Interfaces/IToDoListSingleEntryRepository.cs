using ToDoList.Domain;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoListSingleEntryRepository
    {
        void Delete(SingleEntry entry);
        void Create(SingleEntry newEntry);
        Task DeleteByListIdAsync(int listId);
        Task<SingleEntry> GetAsync(int id, bool trackChanges = false);
        
    }
}