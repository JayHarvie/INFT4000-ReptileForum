using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileForum.Models
{
    public class Discussion
    {
        // Primary Key
        public int DiscussionId { get; set; }

        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string ImageFilename { get; set; }

        // Property for file upload not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; }
        public DateTime CreateDate { get; set; }

        // Navigation Property: One-to-Many Relationship with Comments
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
