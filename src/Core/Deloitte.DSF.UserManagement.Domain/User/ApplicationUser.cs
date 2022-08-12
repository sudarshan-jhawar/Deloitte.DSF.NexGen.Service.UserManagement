public class ApplicationUser : AuditableEntity, IAggregateRoot, ISoftDelete
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }

    public ApplicationUser(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        EMail = email;
    }
}