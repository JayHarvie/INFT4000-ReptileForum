using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileForum.Models
{
    public class Discussion
    {
        // Primary Key
        public int DiscussionId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageFilename { get; set; } = string.Empty;

        // Property for file upload not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navigation Property: One-to-Many Relationship with Comments
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
