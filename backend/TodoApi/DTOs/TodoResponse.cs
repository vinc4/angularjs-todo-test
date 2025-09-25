namespace TodoApi.DTOs
{
    /// <summary>
    /// Response model for todo items returned by the API
    /// </summary>
    public class TodoResponse
    {
        /// <summary>
        /// Unique identifier for the todo item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text/title of the todo item
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Whether the todo item is completed
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// User ID associated with the todo
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// When the todo was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the todo was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}