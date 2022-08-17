using Deloitte.DSF.UserManagement.Application.Common.Persistence;
using Deloitte.DSF.UserManagement.Application.Common.Specification;
using FSH.WebApi.UserManagement.Application.Common.Models;
using MediatR;

namespace Deloitte.DSF.UserManagement.Application.User;

public class SearchUsersRequest : PaginationFilter, IRequest<PaginationResponse<UserDto>>
{
}

public class UsersBySearchRequestSpec : EntitiesByPaginationFilterSpec<ApplicationUser, UserDto>
{
    public UsersBySearchRequestSpec(SearchUsersRequest request)
        : base(request) =>
        Query.OrderBy(c => c.FirstName, !request.HasOrderBy());
}

public class SearchUsersRequestHandler : IRequestHandler<SearchUsersRequest, PaginationResponse<UserDto>>
{
    private readonly IReadRepository<ApplicationUser> _repository;

    public SearchUsersRequestHandler(IReadRepository<ApplicationUser> repository) => _repository = repository;

    public async Task<PaginationResponse<UserDto>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
    {
        var spec = new UsersBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}