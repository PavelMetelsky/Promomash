using MediatR;

namespace Promomash.Core.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
    }
}
