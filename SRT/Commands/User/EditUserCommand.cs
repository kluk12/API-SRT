using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.Commands;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class EditUserCommand : IRequest<User>
    {
        public int Id { get; set; }
       // public int? Phone { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Login { get; set; }
       //public string? Email { get; set; }
        public string Password { get; set; }
      
    }

    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, User>
    {
        private readonly IUserRepository _UserRepository;

        public EditUserCommandHandler(IUserRepository _UserRepository)
        {
            _UserRepository = _UserRepository;
      
        }

        public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
            #region validation
            //if (!_yardRepository.Find().Any(x => x.Id == request.StationFromId))
            //    throw new ApiException(string.Format(Resource.Yard_with_id_0_not_found, request.StationFromId));

            #endregion
          var user=  await _UserRepository.Get(request.Id);
            if (user == null)
                throw new ApiException(string.Format("User with id {0} not found", request.Id));
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Login = request.Login;
            //user.Email = request.Email;
            //user.Password = request.Password;
            user =   await _UserRepository.Update(user);
                return user;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }

}
}
