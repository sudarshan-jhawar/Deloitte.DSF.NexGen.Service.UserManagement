namespace Deloitte.DSF.UserManagement.Application.Common;

public class BaseDto : IDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset UpdatedDateTime { get; set; }
}
