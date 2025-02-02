namespace ReptileForum.Models
{
    public class Comment
    {
        // Primary Key
        public int CommentId { get; set; }

        public required string Content { get; set; }
        public DateTime CreateDate { get; set; }

        // Foreign Key
        public int DiscussionId { get; set; }

        // Navigation Property: Reference to Discussion
        public Discussion? Discussion { get; set; }
    }
}
