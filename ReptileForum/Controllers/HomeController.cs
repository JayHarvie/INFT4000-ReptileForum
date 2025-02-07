using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReptileForum.Data;
using ReptileForum.Models;

namespace ReptileForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReptileForumContext _context;

        public HomeController(ILogger<HomeController> logger, ReptileForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var discussions = _context.Discussion
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate)
                .ToList();

            return View(discussions);
        }

        public IActionResult GetDiscussion(int id)
        {
            var discussion = _context.Discussion
                .Include(d => d.Comments) 
                .FirstOrDefault(d => d.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            discussion.Comments = discussion.Comments.OrderByDescending(c => c.CreateDate).ToList();

            return View(discussion);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
