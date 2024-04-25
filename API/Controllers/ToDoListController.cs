using Core.Features.ToDoLists.Commands.CreateToDoList;
using Core.Features.ToDoLists.Commands.DeleteToDoList;
using Core.Features.ToDoLists.Commands.UpdateToDoList;
using Core.Features.ToDoLists.Queries.GetToDoLists;
using Core.Models.ToDoLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("todolist")]
    public class ToDoListController : ControllerBase {
        private readonly IMediator _mediator;

        public ToDoListController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetToDoLists() {
            return Ok(await _mediator.Send(new GetToDoListQuery()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateToDoList(CreateToDoListRequest request) {
            return Ok(await _mediator.Send(new CreateToDoListCommand { Title = request.Title} ));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateToDoList(UpdateToDoListRequest request) {
            var response = await _mediator.Send(new UpdateToDoListCommand { ToDoListId = request.ToDoListId, Title = request.Title });
            if (response is null) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{toDoListId}")]
        public async Task<ActionResult> DeleteToDoList(int toDoListId) {
            var response = await _mediator.Send(new DeleteToDoListCommand { ToDoListId = toDoListId });
            if (response is false) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
