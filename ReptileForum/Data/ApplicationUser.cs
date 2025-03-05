using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ReptileForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; } = string.Empty;

        [PersonalData]
        public string? Location { get; set; } = string.Empty;

        [PersonalData]
        public string? ImageFilename { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
