using ImpactaLawTech_Test.CustomAttributes;
using LawTech.Application.Models.Commands.Tasks.Create;
using LawTech.Application.Models.Commands.Tasks.Delete;
using LawTech.Application.Models.Commands.Tasks.Update;
using LawTech.Application.Models.Queries.Tasks.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImpactaLawTech_Test.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator mediator;

        public TaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Token]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

        [Token]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTaskCommand command)
        {
            return Ok( await this.mediator.Send(command));
        }

        [Token]
        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskCommand command)
        {
            return Ok( await this.mediator.Send(command));
        }

        [Token]
        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery] ListTaskQuery command)
        {
            return Ok(await this.mediator.Send(command));
        }
    }
}
