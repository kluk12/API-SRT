using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
     
        //public int? Phone { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Login { get; set; }
        //public string? Email { get; set; }
        public  string Password { get; set; }
        //public bool? IsDeleted { get; set; } = false;
        //public bool? IsAdmin { get; set; } = false;
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        private readonly IUserRepository _UserRepository;

        public AddUserCommandHandler(IUserRepository _userRepository)
        {
            _UserRepository = _userRepository;

        }

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region validation
                if (_UserRepository.Find().Any(x => x.Login == request.Login))
                    throw new ApiException(string.Format("Login o tej nazwie już istnieje" ));

                #endregion

                User config = new User()
                {
                    //Phone = request.Phone,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Login = request.Login,
                    //Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    IsDeleted = false,
                    IsAdmin = false,
                    CreateDate = DateTime.Now,

                };


                await _UserRepository.Add(config);
                return true;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
