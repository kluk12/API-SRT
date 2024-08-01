using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SRT.Commands;
using SRT.Commands.Configs;
using SRT.DBModels;

namespace SRT.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
   

        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]

        public async Task<IActionResult> Add(AddUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<User>))]

        public async Task<IActionResult> Edit(EditUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<User>(result));
        }
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]

        //public async Task<IActionResult> Delete(DeleteUserCommand command, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(command, cancellationToken);
        //    return Ok(new GenericResponse<bool>(result));
        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<User>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<User>(result));
        } 
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<List<User>>))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]

        //public async Task<IActionResult> Find(FindUserCommand command, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(command, cancellationToken);
        //    return Ok(new GenericResponse<List<User>>(result));
        //}
    }
}