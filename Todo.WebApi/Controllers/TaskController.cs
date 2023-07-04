using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Tasks.Queries.GetTaskDetails;
using Todo.Application.Tasks.Queries.GetTaskList;
using Todo.WebApi.Models;

namespace Todo.WebApi.Controllers
{
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;
        
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<TaskListView>> GetAll()
        {
            var query = new GetTaskListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<TaskListView>> Get(Guid taskid)
        {
            var query = new GetTaskDetailsQuery()
            {
                UserId = UserId,
                TaskId = taskid
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskDto>(createTaskDto);
            command.
        }
    }
}