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
        public decimal Price { get; set; } = 0m;
        public DateTime? Remove { get; set; }
        public DateTime? Create { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public int? NumberPeopleNo { get; set; }
        public int? WhenCloseTraining { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public bool? GeneratorId { get; set; }
        public bool? Paid { get; set; }
        public int? TrainingId { get; set; }

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
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

                #endregion

                Reservation item = new Reservation()
                {
                    BeforStartTimeInHour = request.BeforStartTimeInHour,
                    Create = request.Create,
                    GeneratorId = request.GeneratorId,
                    LocationId = request.LocationId,
                    NumberPeopleNo = request.NumberPeopleNo,
                    Paid = request.Paid,
                    Price = request.Price,
                    Remove = request.Remove,
                    Summary = request.Summary,
                    TrainingId = request.TrainingId,
                    Type = request.Type,
                    WhenCloseTraining = request.WhenCloseTraining,
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
