using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class DeleteAllTrainingCommand : IRequest<bool>
    {
    }

    public class DeleteAllTrainingCommandHandler : IRequestHandler<DeleteAllTrainingCommand, bool>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public DeleteAllTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<bool> Handle(DeleteAllTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _TrainingRepository.Find().ToListAsync();
                foreach (var item in items)
                {
                    await _TrainingRepository.Delete(item.Id);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
