using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Task;

namespace Todo.Application.Interfaces
{
    public interface ITasksDbContext
    {
        DbSet<Todo.Task.Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}