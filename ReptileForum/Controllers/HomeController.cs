using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ReptileForumContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var discussions = _context.Discussion
                .Include(d => d.ApplicationUser)
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate)
                .ToList();

            return View(discussions);
        }

        public IActionResult GetDiscussion(int id)
        {
            var discussion = _context.Discussion
                .Include(d => d.ApplicationUser)
                .Include(d => d.Comments)
                .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefault(d => d.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            discussion.Comments = discussion.Comments.OrderByDescending(c => c.CreateDate).ToList();

            return View(discussion);
        }

        public IActionResult Profile(string id)
        {
            // Fetch the ApplicationUser based on the passed ApplicationUserId
            var user = _context.Users
                .Where(u => u.Id == id)  
                .FirstOrDefault();  

            if (user == null)
            {
                return NotFound();  
            }

            // Now, fetch the discussions where the ApplicationUserId matches the user's ID
            var discussions = _context.Discussion
                .Where(d => d.ApplicationUserId == user.Id)  
                .ToList();  

            // Pass the user and their discussions to the view directly
            ViewData["User"] = user;
            ViewData["Discussions"] = discussions;

            return View(); 
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
