using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class AddTrainingCommand : IRequest<bool>
    {
        public decimal Price { get; set; } = 0m;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public int? NumberPeople { get; set; }
        [Precision(18, 2)]
        public decimal FixedCosts { get; set; } = 0m;
        public int? WhenCloseTraining { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? GeneratorId { get; set; }

    }

    public class AddTrainingCommandHandler : IRequestHandler<AddTrainingCommand, bool>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public AddTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
      
        }

        public async Task<bool> Handle(AddTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));
                #endregion

                Training item = new Training()
                {
                    BeforStartTimeInHour = request.BeforStartTimeInHour,
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    FixedCosts = request.FixedCosts,
                    Price = request.Price,
                    Summary = request.Summary,
                    WhenCloseTraining = request.WhenCloseTraining,
                    LocationId = request.LocationId,
                    Type = request.Type,
                    AdditionalInformation = request.AdditionalInformation,
                    GeneratorId = request.GeneratorId
                };

               await _TrainingRepository.Add(item);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
     
    }
}
