using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands.Configs
{
    public class DeleteConfigCommand : IRequest<bool>
    {

        public int id { get; set; }


    }

    public class DeleteConfigCommandHandler : IRequestHandler<DeleteConfigCommand, bool>
    {
        private readonly IConfigRepository _ConfigRepository;

        public DeleteConfigCommandHandler(IConfigRepository _configRepository)
        {
            _ConfigRepository = _configRepository;

        }

        public async Task<bool> Handle(DeleteConfigCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.id == null)
                    throw new ApiException("");

                await _ConfigRepository.Delete(request.id);
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
