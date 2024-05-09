using Microsoft.AspNetCore.Identity;

namespace KursovayaBlazorNet6.UsersRoles
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string PhoneNumber { get; set; }
       // public string Address { get; set; }
     
    }
}
