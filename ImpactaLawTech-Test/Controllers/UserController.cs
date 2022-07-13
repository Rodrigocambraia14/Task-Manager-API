using ImpactaLawTech_Test.CustomAttributes;
using LawTech.Application.Models.Commands.Users.Login;
using LawTech.Application.Models.Commands.Users.Register;
using LawTech.Application.Models.Queries.Users.Get;
using LawTech.Application.Models.Queries.Users.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImpactaLawTech_Test.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

        [Token]
        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery] ListUserQuery command)
        {
            return Ok(await this.mediator.Send(command));
        }

        [Token]
        [HttpGet("get")]
        public async Task<IActionResult> List([FromQuery] GetUserQuery command)
        {
            return Ok(await this.mediator.Send(command));
        }

    }
}
