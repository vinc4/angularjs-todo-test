using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoResponse>> GetAllTodosAsync();
        Task<TodoResponse?> GetTodoByIdAsync(int id);
        Task<TodoResponse> CreateTodoAsync(CreateTodoRequest request);
        Task<TodoResponse?> UpdateTodoAsync(int id, UpdateTodoRequest request);
        Task<bool> DeleteTodoAsync(int id);
    }
}