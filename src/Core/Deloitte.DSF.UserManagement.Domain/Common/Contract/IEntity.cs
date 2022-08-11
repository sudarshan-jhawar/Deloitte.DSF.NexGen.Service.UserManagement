namespace Deloitte.DSF.UserManagement.Domain.Common.Contract;

public interface IEntity
{
}
public interface IEntity<TId> : IEntity
{
    TId Id { get; }
}
