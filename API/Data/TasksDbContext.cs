using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) 
        : base(options)
        {
            
        }

       public DbSet<Task> Tasks {get; set;}
    }
}