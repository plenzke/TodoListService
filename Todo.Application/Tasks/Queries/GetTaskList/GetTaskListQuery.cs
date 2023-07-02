using System;
using MediatR;

namespace Todo.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListView>
    {
        public Guid UserId { get; set; }
    }
}