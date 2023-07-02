using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Task;
using Todo.Persistence.EntityTypeConfiguration;

namespace Todo.Persistence
{
    public class TasksDbContext : DbContext, ITasksDbContext
    {
        public DbSet<Todo.Task.Task> Tasks { get; set; }

        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}