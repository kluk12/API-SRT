using MediatR;
using Microsoft.AspNetCore.Mvc;
using SRT.Commands;
using SRT.DBModels;

namespace SRT.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TrainingController : ControllerBase
    {
   

        private readonly ILogger<TrainingController> _logger;
        private readonly IMediator _mediator;
        public TrainingController(ILogger<TrainingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Add(AddTrainingCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Training>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Edit(EditTrainingCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<Training>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Delete(DeleteTrainingCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<TrainingWeek>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Find(FindTrainingCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<TrainingWeek>(result));
        }
    }
}