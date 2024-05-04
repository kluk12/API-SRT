using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands.Configs
{
    public class FindConfigCommand : IRequest<List<Config>>
    {
    }

    public class FindConfigCommandHandler : IRequestHandler<FindConfigCommand, List<Config>>
    {
        private readonly IConfigRepository _ConfigRepository;

        public FindConfigCommandHandler(IConfigRepository _configRepository)
        {
            _ConfigRepository = _configRepository;

        }

        public async Task<List<Config>> Handle(FindConfigCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _ConfigRepository.Find().ToListAsync();
                return items;
            }
            catch (Exception e)
            {
                throw e;

            }
        }
    }
}
