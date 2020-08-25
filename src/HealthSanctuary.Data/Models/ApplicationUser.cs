using Microsoft.AspNetCore.Identity;

namespace HealthSanctuary.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string username)
            : base(username)
        {
        }
    }
}
