using System.Collections.Generic;

namespace Todo.Application.Tasks.Queries.GetTaskList
{
    public class TaskListView
    {
        public IList<TaskListDto> Tasks { get; set; }
    }
}