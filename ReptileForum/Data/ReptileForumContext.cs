using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReptileForum.Data
{
    public class ReptileForumContext : IdentityDbContext<ApplicationUser>
    {
        public ReptileForumContext (DbContextOptions<ReptileForumContext> options)
            : base(options)
        {
        }

        public DbSet<ReptileForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<ReptileForum.Models.Comment> Comment { get; set; } = default!;
    }
}
