using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class DeleteReservationCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, bool>
    {
        private readonly IReservationRepository _ReservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                    throw new ApiException("");

              var a =  await _ReservationRepository.Delete(request.Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}
