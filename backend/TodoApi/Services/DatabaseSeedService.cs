using TodoApi.Data;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services
{
    public interface IDatabaseSeedService
    {
        Task SeedAsync();
        Task SeedDemoDataAsync();
    }

    public class DatabaseSeedService : IDatabaseSeedService
    {
        private readonly TodoContext _context;

        public DatabaseSeedService(TodoContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Ensure database is created
            await _context.Database.EnsureCreatedAsync();

            // Check if we already have data
            if (await _context.Todos.AnyAsync())
            {
                return; // Database already seeded
            }

            // Add seed data
            await SeedDemoDataAsync();
        }

        public async Task SeedDemoDataAsync()
        {
            var todos = new List<Todo>
            {
                new Todo { Text = "🎯 Set up development environment", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-7) },
                new Todo { Text = "📚 Learn Entity Framework Core", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-6) },
                new Todo { Text = "🏗️ Create API endpoints", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-5) },
                new Todo { Text = "🎨 Design user interface", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-4) },
                new Todo { Text = "🔗 Connect frontend to backend", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-3) },
                new Todo { Text = "✅ Add data validation", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new Todo { Text = "🧪 Write unit tests", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new Todo { Text = "🚀 Deploy to production", IsCompleted = false, CreatedAt = DateTime.UtcNow },
                new Todo { Text = "📈 Monitor application performance", IsCompleted = false, CreatedAt = DateTime.UtcNow },
                new Todo { Text = "🔧 Set up CI/CD pipeline", IsCompleted = false, CreatedAt = DateTime.UtcNow }
            };

            _context.Todos.AddRange(todos);
            await _context.SaveChangesAsync();
        }
    }
}