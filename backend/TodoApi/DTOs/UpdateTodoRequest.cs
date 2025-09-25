using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    /// <summary>
    /// Request model for updating an existing todo item
    /// </summary>
    public class UpdateTodoRequest
    {
        /// <summary>
        /// The updated title/text of the todo item
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Whether the todo item is completed
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// User ID associated with the todo (defaults to 1 for this demo)
        /// </summary>
        public int UserId { get; set; } = 1;
    }
}