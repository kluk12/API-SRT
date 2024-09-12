using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class IsReservedCommand : IRequest<int?>
    {
        public int? TrainingId { get; set; }
        public int? UserId { get; set; }
    }

    public class IsReservedCommandHandler : IRequestHandler<IsReservedCommand, int?>
    {
        private readonly IReservationRepository _ReservationRepository;

        public IsReservedCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<int?> Handle(IsReservedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _ReservationRepository.Find().FirstAsync(x => x.UserId == request.UserId && x.TrainingId == request.TrainingId);

                return query?.Id;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
