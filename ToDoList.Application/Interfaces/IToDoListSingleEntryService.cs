using ToDoList.Domain;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoListSingleEntryService
    {
        Task DeleteByListId(int id);
        Task DeleteByIdAsync(int id);
        Task Add(SingleEntry newEntry);
    }
}