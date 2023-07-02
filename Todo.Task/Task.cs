using System;

namespace Todo.Task
{
    public enum Status
    {
        Created,
        InProgress,
        Compeleted
    }

    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public Status Status { get; set; }
    }
}