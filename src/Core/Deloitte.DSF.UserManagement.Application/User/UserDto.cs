using Deloitte.DSF.UserManagement.Application.Common;

namespace Deloitte.DSF.UserManagement.Application.User;
public class UserDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
}