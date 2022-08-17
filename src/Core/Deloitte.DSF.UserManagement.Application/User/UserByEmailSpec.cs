namespace Deloitte.DSF.UserManagement.Application.User;

internal class UserByEmailSpec : Specification<ApplicationUser>, ISingleResultSpecification
{
    public UserByEmailSpec(string email) => Query.Where(b => b.EMail == email);
}
