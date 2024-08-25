using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class EditReservationCommand : IRequest<Reservation>
    {
        public int Id { get; set; }
        public bool Remove { get; set; }=false;

    }

    public class EditReservationCommandHandler : IRequestHandler<EditReservationCommand, Reservation>
    {

        private readonly IReservationRepository _ReservationRepository;

        public EditReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<Reservation> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                //if (!_ReservationRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

                #endregion

                var item = await _ReservationRepository.Get(request.Id);
                if (item == null)
                    throw new ApiException("Rezerwacja nie istnije");

                if (request.Remove)
                {
                    item.IsDelete = request.Remove;
                    item.Remove = DateTime.Now;
                    await _ReservationRepository.Update(item);
                    return item;
                }
               
                return item;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
