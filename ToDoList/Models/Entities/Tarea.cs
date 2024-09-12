using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Entities
{
    public class Tarea
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Boolean IsCompleted { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
