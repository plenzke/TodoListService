using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Task;

namespace Todo.Persistence.EntityTypeConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Todo.Task.Task>
    {
        public void Configure(EntityTypeBuilder<Todo.Task.Task> builder)
        {
            builder.HasKey(task => task.TaskId);
            builder.HasIndex(task => task.TaskId).IsUnique();
            builder.Property(task => task.Title).HasMaxLength(128);
            builder.Property(task => task.Description).HasMaxLength(1028);
        }
    }
}