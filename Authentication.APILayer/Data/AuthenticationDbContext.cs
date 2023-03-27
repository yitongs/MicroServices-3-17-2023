using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.APILayer.Data
{
    public class AuthenticationDbContext:IdentityDbContext<HrmUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> option):base(option)
        {

        }
    }
}
