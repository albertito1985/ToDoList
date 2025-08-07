using ToDoList.Shared;

namespace ToDoList.Client.Pages.ToDoListComponents
{
    public class ToDoListState : IToDoListState
    {
        public List<ToDoListSingleEntryDTO> Entries { get; } = new();
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AddEntry(ToDoListSingleEntryDTO newEntry)
        {
            Entries.Add(newEntry);
            NotifyStateChanged();
        }
    }
}
