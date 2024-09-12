namespace ToDoList.Models
{
    public class UpdateTareaDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Boolean IsCompleted { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
