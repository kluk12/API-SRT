using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class DeleteTrainingCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteConfigCommandHandler : IRequestHandler<DeleteTrainingCommand, bool>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public DeleteConfigCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<bool> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                    throw new ApiException("");

                await _TrainingRepository.Delete(request.Id);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
