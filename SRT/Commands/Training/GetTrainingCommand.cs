using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class GetTrainingCommand : IRequest<Training>
    {
        public int Id { get; set; }
    }

    public class GetTrainingCommandHandler : IRequestHandler<GetTrainingCommand, Training>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public GetTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<Training> Handle(GetTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _TrainingRepository.Get(request.Id);

            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
        public  DateTime StartOfWeek( DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

    }
}
