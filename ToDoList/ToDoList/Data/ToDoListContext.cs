using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<SingleEntry> SingleEntries { get; set; } = default!;
        public DbSet<ToDoListList> ToDoListLists { get; set; } = default!;
    }
}
