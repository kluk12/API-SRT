using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class IsReservedCommand : IRequest<bool>
    {
        public int? TrainingId { get; set; }
        public int? UserId { get; set; }
    }

    public class IsReservedCommandHandler : IRequestHandler<IsReservedCommand, bool>
    {
        private readonly IReservationRepository _ReservationRepository;

        public IsReservedCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<bool> Handle(IsReservedCommand request, CancellationToken cancellationToken)
        {
            try
            {

                return  _ReservationRepository.Find().Any(x => x.UserId == request.UserId && x.TrainingId == request.TrainingId);
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
