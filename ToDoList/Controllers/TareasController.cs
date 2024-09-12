using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.Entities;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TareasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetALlTareas()
        {
            var allTareas = dbContext.Tareas.ToList();

            return Ok(allTareas);
        }

        /*[HttpGet]
        [Route("i{id:guid}")]
        public IActionResult GetTareaById(Guid id)
        {
            var tarea = dbContext.Tareas.Find(id);

            if(tarea is null)
            {
                return NotFound();
            }
            return Ok(tarea);

        }*/

        [HttpPost]
        public IActionResult AddTarea(AddTareaDto addTareaDto)
        {
            var tareaEntity = new Tarea()
            {
                Title = addTareaDto.Title,
                Description = addTareaDto.Description,
                IsCompleted = addTareaDto.IsCompleted,
                CreatedDate = addTareaDto.CreatedDate
            };

            dbContext.Tareas.Add(tareaEntity);
            dbContext.SaveChanges();
            return Ok(tareaEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateTarea(Guid id, UpdateTareaDto updateTareaDto)
        {
            var tarea = dbContext.Tareas.Find(id);

            if (tarea is null)
            {
                return NotFound();
            }

            tarea.Title = updateTareaDto.Title;
            tarea.Description = updateTareaDto.Description;
            tarea.IsCompleted = updateTareaDto.IsCompleted;
            tarea.CreatedDate = tarea.CreatedDate;

            dbContext.SaveChanges();
            return Ok(tarea);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteTarea(Guid id)
        {
            var tarea = dbContext.Tareas.Find(id);

            if(tarea is null)
            {
                return NotFound();
            }

            dbContext.Tareas.Remove(tarea);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
