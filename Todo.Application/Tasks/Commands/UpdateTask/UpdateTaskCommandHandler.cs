using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Exceptions;
using Todo.Application.Interfaces;

namespace Todo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITasksDbContext _dbContext;

        public UpdateTaskCommandHandler(ITasksDbContext dbContext) => _dbContext = dbContext;
        
        public async System.Threading.Tasks.Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tasks.FirstOrDefaultAsync(task => task.TaskId == request.TaskId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Task), request.TaskId);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.DeadlineDate = request.DeadlineDate;
            entity.Status = request.Status;
            entity.CompleteDate = request.CompleteDate;

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}