using ReptileForum.Data;

namespace ReptileForum.Models
{
    public class Comment
    {
        // Primary Key
        public int CommentId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Foreign Key
        public int DiscussionId { get; set; }

        // Navigation Property: Reference to Discussion
        public Discussion? Discussion { get; set; } // Nullable

        public string ApplicationUserId { get; set; } = string.Empty; // Foreign Key

        // Navigation Property: Reference to ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; } // nullable
    }
}
