using System;
using AutoMapper;
using Todo.Application.Common.Mappings;
using Todo.Application.Tasks.Commands.CreateTask;
using Todo.Task;

namespace Todo.WebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DeadlineDate { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.Status,
                    opt => opt.MapFrom(taskDto => taskDto.Status))
                .ForMember(taskCommand => taskCommand.DeadlineDate,
                    opt => opt.MapFrom(taskDto => taskDto.DeadlineDate))
                .ForMember(taskCommand => taskCommand.DeadlineDate,
                    opt => opt.MapFrom(taskDto => taskDto.DeadlineDate));
        }
    }
}