using System.Linq;
using System.Threading;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;

namespace Todo.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListView>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITasksDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async System.Threading.Tasks.Task<TaskListView> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasksQuery = await _dbContext.Tasks
                .Where(task => task.UserId == request.UserId)
                .ProjectTo<TaskListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListView { Tasks = tasksQuery };
        }
    }
}