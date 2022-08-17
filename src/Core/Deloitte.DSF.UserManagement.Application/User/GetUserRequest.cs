using Deloitte.DSF.UserManagement.Application.Common.Exceptions;
using Deloitte.DSF.UserManagement.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Deloitte.DSF.UserManagement.Application.User;

public class GetUserRequest : IRequest<UserDto>
{
    public Guid Id { get; set; }

    public GetUserRequest(Guid id) => Id = id;
}

public class UserByIdSpec : Specification<ApplicationUser, UserDto>, ISingleResultSpecification
{
    public UserByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
{
    private readonly IRepository<ApplicationUser> _repository;
    private readonly IStringLocalizer _t;

    public GetUserRequestHandler(IRepository<ApplicationUser> repository, IStringLocalizer<GetUserRequestHandler> localizer)
        => (_repository, _t) = (repository, localizer);

    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync((ISpecification<ApplicationUser, UserDto>)new UserByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["User {0} Not Found.", request.Id]);
}
