using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReptileForum.Models;

namespace ReptileForum.Data
{
    public class ReptileForumContext : DbContext
    {
        public ReptileForumContext (DbContextOptions<ReptileForumContext> options)
            : base(options)
        {
        }

        public DbSet<ReptileForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<ReptileForum.Models.Comment> Comment { get; set; } = default!;
    }
}
