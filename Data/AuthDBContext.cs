using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recuriment_Platform.Models;

namespace Recuriment_Platform.Data
{
    public class AuthDBContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
        }

    }
}
