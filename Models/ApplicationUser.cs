using Microsoft.AspNetCore.Identity;

namespace Recuriment_Platform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
