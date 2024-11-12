using MediatR;
using Promomash.Entities.User;

namespace Promomash.Core.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<GetUsersResponse>>
    {
    }
}
