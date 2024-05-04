using MediatR;
using Microsoft.AspNetCore.Mvc;
using SRT.Commands;
using SRT.DBModels;

namespace SRT.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationDictionaryController : ControllerBase
    {
   

        private readonly ILogger<LocationDictionaryController> _logger;
        private readonly IMediator _mediator;
        public LocationDictionaryController(ILogger<LocationDictionaryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Add(AddLocationDictionaryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<LocationDictionary>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Edit(EditLocationDictionaryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<LocationDictionary>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Delete(DeleteLocationDictionaryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<List<LocationDictionary>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Find(FindLocationDictionaryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<List<LocationDictionary>> (result));
        }
    }
}