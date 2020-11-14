using System.Collections.Generic;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private TasksDbContext _context;
        public TasksController(TasksDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async System.Threading.Tasks.
        Task<ActionResult<IReadOnlyList<Task>>> GetTasks(){
            var data = await _context.Tasks.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async System.Threading.Tasks.
        Task<ActionResult> CreateTask(Task task){
            if(!ModelState.IsValid){
                return BadRequest("Model not matching requirements");
            }
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return Ok("Successfully Created a Task");
        }

        [HttpDelete("{id}")]
        public async System.Threading.Tasks.
        Task<ActionResult> DeleteTask(int id){
            var taskToDelete = await _context.Tasks
            .SingleOrDefaultAsync(x => x.Id == id);
            if(taskToDelete == null)
                return BadRequest("Task Not Found");
            _context.Remove(taskToDelete);
            await _context.SaveChangesAsync();
            return Ok("Successfully Deleted Task");
        }
        [HttpPut("{id}")]
        public async System.Threading.Tasks.
        Task<ActionResult> UpdateTask(int id, Task newTask){
            if(!ModelState.IsValid)
                return BadRequest("Model not matching requirements");
            newTask.Id = id;
            _context.Entry(newTask).State = EntityState.Modified;
            var taskToUpdate = await _context.Tasks.
            SingleOrDefaultAsync(x => x.Id == id);
            if(taskToUpdate == null)
                return NotFound("Task not found");
            _context.Update(taskToUpdate);
            await _context.SaveChangesAsync();
            return Ok("Task successfully Updated");
        }
    }
}