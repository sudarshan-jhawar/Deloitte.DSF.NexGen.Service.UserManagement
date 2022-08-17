using Deloitte.DSF.UserManagement.Application.Common.Persistence;
using Deloitte.DSF.UserManagement.Application.Common.Validaton;
using MediatR;

namespace Deloitte.DSF.UserManagement.Application.User;
public class CreateUserRequest : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
}

public class CreateUserRequestValidator : CustomValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(IReadRepository<ApplicationUser> repository) =>
        RuleFor(p => p.FirstName)
        .NotEmpty()
        .MaximumLength(75)
        .MustAsync(async (email, ct) => await repository.AnyAsync(new UserByEmailSpec(email), ct))
        .WithMessage((_, email) => $"User {email} already Exists.");
}

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Guid>
{
    private readonly IRepositoryWithEvents<ApplicationUser> _repository;

    public CreateUserRequestHandler(IRepositoryWithEvents<ApplicationUser> repository) => _repository = repository;
    public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(request.FirstName, request.LastName, request.EMail);
        await _repository.AddAsync(user, cancellationToken);
        return user.Id;
    }
}