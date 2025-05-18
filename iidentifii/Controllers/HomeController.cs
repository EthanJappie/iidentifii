using iidentifii.Data;
using iidentifii.Data.Service;
using iidentifii.Models;
using iidentifii.Data.Entities;
using iidentifii.Models.Posts;
using iidentifii.Models.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using iidentifii.EntityModelMappers;

namespace iidentifii.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserStore<IdentityUser> _userStore;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userStore = userStore;
        }

        public IActionResult Index()
        {
            var posts = _dbContext.GetPosts();
            var postViewModels = EntityMapping.MapPostsToViewModels(posts);
            return View(postViewModels);
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
