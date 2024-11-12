using MediatR;
using Promomash.Database;
using Promomash.Entities.User;

namespace Promomash.Core.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly PromomashContext _context;

        public CreateUserHandler(PromomashContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Login = request.Login,
                Password = request.Password,
                Country = request.Country,
                Province = request.Province
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
