using ToDoList.Shared;

namespace ToDoList.Client.Pages.ToDoListComponents
{
    public interface IToDoListState
    {
        List<ToDoListSingleEntryDTO> Entries { get; }

        event Action? OnChange;

        void AddEntry(ToDoListSingleEntryDTO newEntry);
    }
}