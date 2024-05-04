using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class EditConfigCommand : IRequest<bool>
    {
        public int Id { get; set; } 
        public decimal Price { get; set; } = 0;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public decimal FixedCosts { get; set; } = 0;
        public int? WhenCloseTraining { get; set; }

    }

    public class EditConfigCommandHandler : IRequestHandler<EditConfigCommand, bool>
    {
        private readonly IConfigRepository _ConfigRepository;

        public EditConfigCommandHandler(IConfigRepository _configRepository)
        {
            _ConfigRepository = _configRepository;
      
        }

        public async Task<bool> Handle(EditConfigCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

                #endregion

                Config config = new Config()
                {

                     BeforStartTimeInHour= request.BeforStartTimeInHour,
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    FixedCosts = request.FixedCosts,
                    Price = request.Price,
                    Summary = request.Summary,
                    WhenCloseTraining = request.WhenCloseTraining,
                };


               await _ConfigRepository.Add(config);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
