using System;
using System.Threading;
using MediatR;
using Todo.Application.Interfaces;
using Todo.Task;

namespace Todo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITasksDbContext _dbContext;

        public CreateTaskCommandHandler(ITasksDbContext dbContext) => _dbContext = dbContext;
        
        public async System.Threading.Tasks.Task<Guid> Handle(CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = new Task.Task
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                DeadlineDate = request.DeadlineDate,
                TaskId = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                CompleteDate = null,
                Status = Status.Created
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.TaskId;
        }
    }
}