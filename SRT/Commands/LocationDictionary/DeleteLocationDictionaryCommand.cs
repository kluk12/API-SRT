using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class DeleteLocationDictionaryCommand : IRequest<bool>
    {

        public int Id { get; set; }
      

    }

    public class DeleteLocationDictionaryCommandHandler : IRequestHandler<DeleteLocationDictionaryCommand, bool>
    {
        private readonly ILocationDictionaryRepository _LocationDictionaryRepository;

        public DeleteLocationDictionaryCommandHandler(ILocationDictionaryRepository LocationDictionaryRepository)
        {
            _LocationDictionaryRepository = LocationDictionaryRepository;

        }

        public async Task<bool> Handle(DeleteLocationDictionaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                    throw new ApiException("");

                await _LocationDictionaryRepository.Delete(request.Id);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
