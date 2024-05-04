using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class FindTrainingCommand : IRequest<List<Training>>
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

    public class FindTrainingCommandHandler : IRequestHandler<FindTrainingCommand, List<Training>>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public FindTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<List<Training>> Handle(FindTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _TrainingRepository.Find().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
