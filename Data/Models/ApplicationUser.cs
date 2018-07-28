using Microsoft.AspNetCore.Identity;

namespace FitHub.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int DOB { get; set; }
    }
}
