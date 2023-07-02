using System;
using System.Threading;
using AutoMapper;
using MediatR;
using Todo.Application.Common.Exceptions;
using Todo.Application.Interfaces;
using Todo.Task;

namespace Todo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITasksDbContext _dbContext;
        
        public DeleteTaskCommandHandler(ITasksDbContext dbContext) => _dbContext = dbContext;

        public async System.Threading.Tasks.Task<Unit> Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks.FindAsync(new object[] { request.TaskId }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Task), request.TaskId);
            }

            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}