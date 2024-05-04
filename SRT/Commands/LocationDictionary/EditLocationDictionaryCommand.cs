using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;
using SRT.Migrations;

namespace SRT.Commands
{
    public class EditLocationDictionaryCommand : IRequest<LocationDictionary>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LocationIframe { get; set; }
        public string? LocationLinq { get; set; }

    }

    public class EditLocationDictionaryCommandHandler : IRequestHandler<EditLocationDictionaryCommand, LocationDictionary>
    {
        private readonly ILocationDictionaryRepository _LocationDictionaryRepository;

        public EditLocationDictionaryCommandHandler(ILocationDictionaryRepository LocationDictionaryRepository)
        {
            _LocationDictionaryRepository = LocationDictionaryRepository;

        }

        public async Task<LocationDictionary> Handle(EditLocationDictionaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = await _LocationDictionaryRepository.Get(request.Id);
                if (item == null)
                    throw new ApiException("null id");
                item.Name = request.Name;
                item.LocationIframe = request.LocationIframe;
                item.LocationLinq = request.LocationLinq;

               await _LocationDictionaryRepository.Update(item);
                return item;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
