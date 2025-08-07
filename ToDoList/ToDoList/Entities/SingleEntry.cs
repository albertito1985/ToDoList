using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entities
{
    public class SingleEntry
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Descrption field is required")]
        public string Description { get; set; }
        public int ToDoListListId { get; set; }
    }
}
