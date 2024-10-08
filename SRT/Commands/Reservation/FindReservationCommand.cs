﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class FindReservationCommand : IRequest<List<Reservation>>
    {
        public int? TrainingId { get; set; }
    }

    public class FindReservationCommandHandler : IRequestHandler<FindReservationCommand, List<Reservation>>
    {
        private readonly IReservationRepository _ReservationRepository;

        public FindReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _ReservationRepository = reservationRepository;
        }

        public async Task<List<Reservation>> Handle(FindReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query =  _ReservationRepository.Find();
                if (request.TrainingId.HasValue)
                    query = query.Where(x => x.TrainingId == request.TrainingId);
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
     
    }
}
