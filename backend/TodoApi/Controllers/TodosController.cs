using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoService todoService, ILogger<TodosController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        // GET: api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoResponse>>> GetTodos()
        {
            try
            {
                var todos = await _todoService.GetAllTodosAsync();
                
                // Transform to match frontend format (id, text, completed)
                var result = todos.Select(t => new
                {
                    id = t.Id,
                    text = t.Text,
                    completed = t.Completed
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting todos");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetTodo(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);

                if (todo == null)
                {
                    return NotFound();
                }

                // Transform to match frontend format
                var result = new
                {
                    id = todo.Id,
                    text = todo.Text,
                    completed = todo.Completed
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting todo with id {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/todos
        [HttpPost]
        public async Task<ActionResult<object>> CreateTodo([FromBody] CreateTodoRequest request)
        {
            try
            {
                var todo = await _todoService.CreateTodoAsync(request);

                // Transform to match frontend format
                var result = new
                {
                    id = todo.Id,
                    text = todo.Text,
                    completed = todo.Completed
                };

                return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating todo");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/todos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> UpdateTodo(int id, [FromBody] UpdateTodoRequest request)
        {
            try
            {
                var todo = await _todoService.UpdateTodoAsync(id, request);

                if (todo == null)
                {
                    return NotFound();
                }

                // Transform to match frontend format
                var result = new
                {
                    id = todo.Id,
                    text = todo.Text,
                    completed = todo.Completed
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating todo with id {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                var deleted = await _todoService.DeleteTodoAsync(id);

                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo with id {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}