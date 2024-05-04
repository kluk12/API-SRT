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
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

                #endregion

                var item = await _ReservationRepository.Get(request.Id);
                if (item == null)
                    throw new ApiException("null id");

                item.BeforStartTimeInHour = request.BeforStartTimeInHour;
                item.Create = request.Create;
                item.GeneratorId = request.GeneratorId;
                item.LocationId = request.LocationId;
                item.NumberPeopleNo = request.NumberPeopleNo;
                item.Paid = request.Paid;
                item.Price = request.Price;
                item.Remove = request.Remove;
                item.Summary = request.Summary;
                item.TrainingId = request.TrainingId;
                item.LocationId = request.LocationId;
                item.Type = request.Type;
                item.GeneratorId = request.GeneratorId;
                item.Paid = request.Paid;
                item.TrainingId = request.TrainingId;

                await _ReservationRepository.Update(item);
                return item;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
