using MediatR;
using Promomash.Database;

namespace Promomash.Core.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersResponse>>
    {
        private readonly PromomashContext _context;

        public GetUsersQueryHandler(PromomashContext context)
        {
            _context = context;
        }

        public async Task<List<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Select(user => new GetUsersResponse
            {
                Id = user.Id,
                Login = user.Login,
                Country = user.Country,
                Province = user.Province
            }).ToList();

            return await Task.FromResult(users);
        }
    }
}
