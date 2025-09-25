using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    public class CreateTodoRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters")]
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;

        /// User ID associated with the todo (defaults to 1 for this demo)
        public int UserId { get; set; } = 1;
    }
}