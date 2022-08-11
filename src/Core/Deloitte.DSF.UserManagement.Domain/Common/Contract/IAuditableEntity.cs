﻿namespace Deloitte.DSF.UserManagement.Domain.Common.Contract;
public interface IAuditableEntity
{
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; }
    public Guid LastModifiedBy { get; set; }
    public DateTimeOffset LastModifiedOn { get; set; }
}