using System;
using MediatR;

namespace Todo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}