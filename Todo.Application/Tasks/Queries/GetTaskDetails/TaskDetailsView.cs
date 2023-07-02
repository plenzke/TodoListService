using System;
using AutoMapper;
using Todo.Application.Common.Mappings;
using Todo.Task;

namespace Todo.Application.Tasks.Queries.GetTaskDetails
{
    public class TaskDetailsView : IMapWith<Task.Task>
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public Status Status { get; set; }
        public DateTime CompleteDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task.Task, TaskDetailsView>()
                .ForMember(noteView => noteView.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(noteView => noteView.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(noteView => noteView.TaskId,
                    opt => opt.MapFrom(task => task.TaskId))
                .ForMember(noteView => noteView.CreateDate,
                    opt => opt.MapFrom(task => task.CreateDate))
                .ForMember(noteView => noteView.DeadlineDate,
                    opt => opt.MapFrom(task => task.DeadlineDate))
                .ForMember(noteView => noteView.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(noteView => noteView.CompleteDate,
                    opt => opt.MapFrom(task => task.CompleteDate));
        }
    }
}