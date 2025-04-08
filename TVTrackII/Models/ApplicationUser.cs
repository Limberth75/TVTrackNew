using Microsoft.AspNetCore.Identity;

namespace TVTrackII.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? NombreCompleto { get; set; }
        public string? Rol { get; set; }
    }
}
