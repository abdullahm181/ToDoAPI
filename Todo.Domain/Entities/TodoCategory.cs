namespace Todo.Domain.Entities
{
    public class TodoCategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Color { get; set; }
        public string Description { get; set; } = string.Empty;
        // Navigation property for related TodoItems
        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
