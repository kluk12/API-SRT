using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class AddReservationCommand : IRequest<bool>
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
        public int? Type { get; set; }
        public int TrainingId { get; set; }
        public int? LocationId { get; set; }

    }

    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, bool>
    {
        private readonly IReservationRepository _ReservationRepository;

        public AddReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;

        }

        public async Task<bool> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                if (_ReservationRepository.Find().Any(x => x.UserId == request.UserId && x.TrainingId == request.TrainingId))
                    throw new ApiException("Nie możesz zarezerwować ponownie tych zajęć");

                #endregion

                Reservation item = new Reservation()
                {
                    TrainingId = request.TrainingId,
                    LocationId = request.LocationId,
                    WhenCloseRezerwation = 1,
                    Type = request.Type,
                    UserId = request.UserId,
                    Create = DateTime.Now,
                    Paid = false,
                };


                await _ReservationRepository.Add(item);
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
