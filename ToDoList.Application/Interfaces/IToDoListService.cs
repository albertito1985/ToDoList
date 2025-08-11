using ToDoList.Domain;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoListService
    {
        void Create(ToDoListList toDoList);
        void Delete(int id);
        void Edit(int id, ToDoListList newToDoList);
        Task<ToDoListList> GetAsync(int id);
    }
}