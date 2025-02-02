namespace ReptileForum.Models
{
    public class Discussion
    {
        // Primary Key
        public int DiscussionId { get; set; }

        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string ImageFilename { get; set; }
        public DateTime CreateDate { get; set; }

        // Navigation Property: One-to-Many Relationship with Comments
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
