using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class IsPaidReservationCommand : IRequest<List<Reservation>>
    {
        public int? TrainingId { get; set; }
        public bool? Paid { get; set; }
    }

    public class IsPaidReservationCommandHandler : IRequestHandler<IsPaidReservationCommand, List<Reservation>>
    {
        private readonly IReservationRepository _ReservationRepository;

        public IsPaidReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<List<Reservation>> Handle(IsPaidReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query =  _ReservationRepository.Find();
                if (request.TrainingId.HasValue)
                    query = query.Where(x => x.TrainingId == request.TrainingId);
                if (request.Paid.HasValue)
                    query = query.Where(x => x.Paid == request.Paid);
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
