using MediatR;
using Microsoft.AspNetCore.Mvc;
using SRT.Commands;
using SRT.DBModels;
using System.Collections.Generic;

namespace SRT.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservationController : ControllerBase
    {
   

        private readonly ILogger<ReservationController> _logger;
        private readonly IMediator _mediator;
        public ReservationController(ILogger<ReservationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Add(AddReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Reservation>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Edit(EditReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<Reservation>(result));
        }
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]

        //public async Task<IActionResult> Delete(DeleteReservationCommand command, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(command, cancellationToken);
        //    return Ok(new GenericResponse<bool>(result));
        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<List<Reservation>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Find(FindReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<List<Reservation>> (result));
        } [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int?))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> IsReserved(IsReservedCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<int?> (result));
        } [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<List<Reservation>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> IsPaid(IsPaidReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<List<Reservation>> (result));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> UnReservation(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new GenericResponse<bool>(result));
        }
    }
}