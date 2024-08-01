using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;
using SRT.DBModels;

namespace SRT.Commands
{
    public class LoginCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IUserRepository _UserRepository;

        public LoginCommandHandler(IUserRepository _userRepository)
        {
            _UserRepository = _userRepository;

        }

        public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _UserRepository.Find().FirstOrDefaultAsync(x => x.Login == request.Login );//&& x.Password == request.Password

                if (items!=null && BCrypt.Net.BCrypt.Verify(request.Password, items.Password))
                {
                    return items;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }
    }
}
