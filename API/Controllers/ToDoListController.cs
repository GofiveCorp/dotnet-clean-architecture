using Core.Features.ToDoLists.Queries.GetToDoLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
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
    }
}
