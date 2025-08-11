using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;

namespace ToDoList.Infrastructure.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<SingleEntry> SingleEntries { get; set; } = default!;
        public DbSet<ToDoListList> ToDoListLists { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data

            modelBuilder.Entity<ToDoListList>()
                .HasData(
                    new ToDoListList
                    { Id = 1});
            modelBuilder.Entity<SingleEntry>()
                .HasData(
                    new SingleEntry { Id = 1, Name = "Buy groceries", Description = "Milk, Bread, Eggs",ToDoListListId=1 },
                    new SingleEntry { Id = 2, Name = "Walk the dog", Description = "Take the dog for a walk in the park", ToDoListListId=1 }
                );       
        }
    }
}
