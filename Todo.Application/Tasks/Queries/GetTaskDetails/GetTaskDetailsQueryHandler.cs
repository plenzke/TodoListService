using System.Linq;
using System.Threading;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Exceptions;
using Todo.Application.Interfaces;

namespace Todo.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, TaskDetailsView>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITasksDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async System.Threading.Tasks.Task<TaskDetailsView> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tasks.FirstOrDefaultAsync(task => task.TaskId == request.TaskId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Task.Task), request.TaskId);
            }

            return _mapper.Map<TaskDetailsView>(entity);
        }
    }
}