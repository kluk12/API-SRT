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
        public decimal Price { get; set; } = 20;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }=72;
        public int? NumberPeople { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? Title { get; set; }

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
                    Price = request.Price,
                    LocationId = request.LocationId,
                    Title = request.Title,
                    Type = request.Type,
                    NumberPeople = request.NumberPeople,
                    AdditionalInformation = request.AdditionalInformation,
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
