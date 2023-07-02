using System;
using MediatR;
using Todo.Task;

namespace Todo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineDate { get; set; }
        public Status Status { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}