using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class AddLocationDictionaryCommand : IRequest<bool>
    {
        public string Name { get; set; } 
        public string? LocationIframe { get; set; }
        public string? LocationLinq { get; set; }

    }

    public class AddLocationDictionaryHandler : IRequestHandler<AddLocationDictionaryCommand, bool>
    {
        private readonly ILocationDictionaryRepository _LocationDictionaryRepository;

        public AddLocationDictionaryHandler(ILocationDictionaryRepository LocationDictionaryRepository)
        {
            _LocationDictionaryRepository = LocationDictionaryRepository;
      
        }

        public async Task<bool> Handle(AddLocationDictionaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
                //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));
                #endregion
                LocationDictionary item = new LocationDictionary()
                {
                    Name = request.Name,
                    LocationIframe = request.LocationIframe,
                    LocationLinq = request.LocationLinq,
                };

               await _LocationDictionaryRepository.Add(item);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
