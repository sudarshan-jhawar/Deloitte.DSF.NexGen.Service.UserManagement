namespace Deloitte.DSF.UserManagement.Domain.Common.Contracts;
public abstract class AuditableEntity : AuditableEntity<DefaultIdType>
{
}

public abstract class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity
{
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public Guid LastModifiedBy { get; set; }
    public DateTimeOffset LastModifiedOn { get; set; }

    protected AuditableEntity()
    {
        CreatedOn = DateTimeOffset.UtcNow;
        LastModifiedOn = DateTimeOffset.UtcNow;
    }
}
