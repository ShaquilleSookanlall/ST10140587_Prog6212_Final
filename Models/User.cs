using Microsoft.AspNetCore.Identity;

namespace ST10140587_Prog6212_Part2.Models
{

    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}