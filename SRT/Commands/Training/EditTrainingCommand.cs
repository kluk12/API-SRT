using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class EditTrainingCommand : IRequest<Training>
    {
        public int Id { get; set; }
        public decimal Price { get; set; } = 20;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; } = 72;
        public int? NumberPeople { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public string? AdditionalInformation { get; set; }


    }

    public class EditTrainingCommandHandler : IRequestHandler<EditTrainingCommand, Training>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public EditTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<Training> Handle(EditTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

                #endregion
                var item = await _TrainingRepository.Get(request.Id);
                if (item == null)
                    throw new ApiException("null id");

                item.BeforStartTimeInHour = request.BeforStartTimeInHour;
                item.DateFrom = request.DateFrom;
                item.DateTo = request.DateTo;
                item.Price = request.Price;
                item.LocationId = request.LocationId;
                item.Type = request.Type;
                item.AdditionalInformation = request.AdditionalInformation;

                await _TrainingRepository.Update(item);
                return item;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
     
    }
}
