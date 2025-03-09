using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReptileForum.Data;
using ReptileForum.Models;

namespace ReptileForum.Controllers
{
    // Removed Actions:
    // GET: Comments/Details/5
    // GET: Comments
    // GET: Comments/Edit/5
    // POST: Comments/Edit/5
    // GET: Comments/Delete/5
    // POST: Comments/Delete/5

    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ReptileForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ReptileForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments/Create
        public IActionResult Create(int discussionId)
        {
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "Title", discussionId);
            return View(new Comment { DiscussionId = discussionId, Content = string.Empty });
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.ApplicationUserId = _userManager.GetUserId(User);
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "DiscussionId", comment.DiscussionId);
            return View(comment);
        }
    }
}
