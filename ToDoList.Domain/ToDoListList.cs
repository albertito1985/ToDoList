namespace ToDoList.Domain
{
    public class ToDoListList
    {
        public int Id { get; set; }
        public List<SingleEntry> Entries { get; set; } = new List<SingleEntry>();
    }
}
