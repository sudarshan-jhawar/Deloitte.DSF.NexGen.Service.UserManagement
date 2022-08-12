namespace Deloitte.DSF.UserManagement.Domain.Common.Contracts;

public interface ISoftDelete
{
    DateTimeOffset? DeletedOn { get; set; }
    Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
}