using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoService> _logger;

        public TodoService(TodoContext context, ILogger<TodoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TodoResponse>> GetAllTodosAsync()
        {
            try
            {
                var todos = await _context.Todos
                    .Select(t => new TodoResponse
                    {
                        Id = t.Id,
                        Text = t.Text,
                        Completed = t.IsCompleted,
                        UserId = 1, // Default user ID
                        CreatedAt = t.CreatedAt,
                        UpdatedAt = t.UpdatedAt
                    })
                    .ToListAsync();

                return todos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all todos");
                throw;
            }
        }

        public async Task<TodoResponse?> GetTodoByIdAsync(int id)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);

                if (todo == null)
                {
                    return null;
                }

                return new TodoResponse
                {
                    Id = todo.Id,
                    Text = todo.Text,
                    Completed = todo.IsCompleted,
                    UserId = 1, // Default user ID
                    CreatedAt = todo.CreatedAt,
                    UpdatedAt = todo.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving todo with id {Id}", id);
                throw;
            }
        }

        public async Task<TodoResponse> CreateTodoAsync(CreateTodoRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Title))
                {
                    throw new ArgumentException("Title cannot be empty", nameof(request.Title));
                }

                var todo = new Todo
                {
                    Text = request.Title.Trim(),
                    IsCompleted = request.Completed,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();

                return new TodoResponse
                {
                    Id = todo.Id,
                    Text = todo.Text,
                    Completed = todo.IsCompleted,
                    UserId = request.UserId,
                    CreatedAt = todo.CreatedAt,
                    UpdatedAt = todo.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating todo with title {Title}", request.Title);
                throw;
            }
        }

        public async Task<TodoResponse?> UpdateTodoAsync(int id, UpdateTodoRequest request)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);

                if (todo == null)
                {
                    return null;
                }
                if (!string.IsNullOrWhiteSpace(request.Title))
                {
                    todo.Text = request.Title.Trim();
                }

                todo.IsCompleted = request.Completed;
                todo.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new TodoResponse
                {
                    Id = todo.Id,
                    Text = todo.Text,
                    Completed = todo.IsCompleted,
                    UserId = request.UserId, 
                    CreatedAt = todo.CreatedAt,
                    UpdatedAt = todo.UpdatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating todo with id {Id}", id);
                throw;
            }
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);

                if (todo == null)
                {
                    return false;
                }

                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo with id {Id}", id);
                throw;
            }
        }
    }
}