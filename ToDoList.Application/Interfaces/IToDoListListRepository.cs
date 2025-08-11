using ToDoList.Domain;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoListListRepository
    {
        Task AddListAsync(ToDoListList list);
        Task<ToDoListList> GetListAsync(int id, bool trackChanges = false);
    }
}