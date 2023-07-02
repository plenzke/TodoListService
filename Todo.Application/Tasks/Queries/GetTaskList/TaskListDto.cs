using System;
using AutoMapper;
using Todo.Application.Common.Mappings;

namespace Todo.Application.Tasks.Queries.GetTaskList
{
    public class TaskListDto : IMapWith<Task.Task>
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task.Task, TaskListDto>()
                .ForMember(taskDto => taskDto.TaskId,
                    opt => opt.MapFrom(task => task.TaskId))
                .ForMember(taskDto => taskDto.Title,
                    opt => opt.MapFrom(task => task.Title));
        }
    }
}