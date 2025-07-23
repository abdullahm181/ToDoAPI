using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Insfrastructure.Context
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
            // Configure your entities here if needed
        }
        // DbSet properties for your entities can be added here
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }

    }
}
