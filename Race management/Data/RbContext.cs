using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Race_management.Data
{
    public class RbContext : IdentityDbContext
    {
        public RbContext(DbContextOptions<RbContext> option) : base(option)
        {
        }
    }
}
