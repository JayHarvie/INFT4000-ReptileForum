using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    public class CommentsController : Controller
    {
        private readonly ReptileForumContext _context;

        public CommentsController(ReptileForumContext context)
        {
            _context = context;
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
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "DiscussionId", comment.DiscussionId);
            return View(comment);
        }
    }
}
