using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class FindReservationCommand : IRequest<List<Reservation>>
    {
           }

    public class FindReservationCommandHandler : IRequestHandler<FindReservationCommand, List<Reservation>>
    {
        private readonly IReservationRepository _ReservationRepository;

        public FindReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<List<Reservation>> Handle(FindReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _ReservationRepository.Find().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
