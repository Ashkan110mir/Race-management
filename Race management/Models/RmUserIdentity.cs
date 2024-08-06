using Microsoft.AspNetCore.Identity;

namespace Race_management.Models
{
    public class RmUserIdentity : IdentityUser
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }
    }
}
