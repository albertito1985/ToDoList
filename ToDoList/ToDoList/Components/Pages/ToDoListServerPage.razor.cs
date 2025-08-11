using Microsoft.AspNetCore.Components;
using ToDoList.Application.Interfaces;
using ToDoList.Domain;
using ToDoList.Shared;

namespace ToDoList.Components.Pages
{
    public partial class ToDoListServerPage()
    {
        public int ListId { get; set; } = 1;
        public ToDoListSingleEntryDTO NewEntry { get; set; } = new();

        public List<SingleEntry> Entries = new();

        [Inject]
        public IServiceManager serviceManager { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Entries = (await serviceManager.ToDoListService.GetAsync(ListId)).Entries;
        }

        public async Task FormSubmitted()
        {
            if (!string.IsNullOrWhiteSpace(NewEntry.Name) && !string.IsNullOrWhiteSpace(NewEntry.Description))
            {
                await serviceManager.ToDoListSingleEntryService.Add(new SingleEntry
                {
                    Name = NewEntry.Name,
                    Description = NewEntry.Description,
                    ToDoListListId = ListId
                });
                NewEntry = new ToDoListSingleEntryDTO(); // Reset the form
                await RefreshList();
            }
        }

        public async Task RefreshList()
        {
            Entries = (await serviceManager.ToDoListService.GetAsync(ListId)).Entries;
        }
    }
}