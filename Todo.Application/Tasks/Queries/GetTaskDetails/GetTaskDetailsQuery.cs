using System;
using MediatR;

namespace Todo.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery: IRequest<TaskDetailsView>
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}