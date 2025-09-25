using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Todo entity
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).IsRequired().HasMaxLength(200);
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
            });

            // Seed initial data
            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Text = "Learn AngularJS",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Todo
                {
                    Id = 2,
                    Text = "Build a todo app",
                    IsCompleted = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Todo
                {
                    Id = 3,
                    Text = "Create .NET Core API",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Todo
                {
                    Id = 4,
                    Text = "Connect frontend to backend",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Todo
                {
                    Id = 5,
                    Text = "Deploy the application",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}