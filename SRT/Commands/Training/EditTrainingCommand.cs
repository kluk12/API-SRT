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
        public decimal Price { get; set; } = 0m;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public int? NumberPeople { get; set; }
        public decimal FixedCosts { get; set; } = 0m;
        public int? WhenCloseTraining { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? GeneratorId { get; set; }


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
                item.FixedCosts = request.FixedCosts;
                item.Price = request.Price;
                item.Summary = request.Summary;
                item.WhenCloseTraining = request.WhenCloseTraining;
                item.LocationId = request.LocationId;
                item.Type = request.Type;
                item.AdditionalInformation = request.AdditionalInformation;
                item.GeneratorId = request.GeneratorId;

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
