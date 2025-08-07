using System.ComponentModel.DataAnnotations;

namespace ToDoList.Shared
{
    public class ToDoListSingleEntryDTO
    {
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Descrption field is required")]
        public string Description { get; set; }
    }
}
