using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class FindLocationDictionaryCommand : IRequest<List<LocationDictionary>>
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

    public class FindLocationDictionaryCommandHandler : IRequestHandler<FindLocationDictionaryCommand, List<LocationDictionary>>
    {
        private readonly ILocationDictionaryRepository _LocationDictionaryRepository;

        public FindLocationDictionaryCommandHandler(ILocationDictionaryRepository LocationDictionaryRepository)
        {
            _LocationDictionaryRepository = LocationDictionaryRepository;

        }

        public async Task<List<LocationDictionary>> Handle(FindLocationDictionaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
             var items=  await _LocationDictionaryRepository.Find().ToListAsync();
                return items;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
