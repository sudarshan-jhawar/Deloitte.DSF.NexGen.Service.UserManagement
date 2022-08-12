namespace Deloitte.DSF.UserManagement.Domain.Common.Contract;

public interface ISoftDelete
{
    DateTimeOffset? DeletedOn { get; set; }
    Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
}