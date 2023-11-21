using ActivityStatusPing.Data;
using ActivityStatusPing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ActivityStatusPing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ActivityStatusPingContext _context;

        public HomeController(ILogger<HomeController> logger, ActivityStatusPingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Users = _context.User.ToList()
            };

            return View(viewModel);
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

        [HttpPost]
        public IActionResult Login([Bind("Id, Username")]IndexViewModel viewModel)
        {
            var user = _context.User.FirstOrDefault(x => x.Username == viewModel.Username);


            if (user != null) 
            {
                user.LastActive = DateTime.UtcNow;
                _context.User.Update(user);
                _context.SaveChanges();

                viewModel.User = user;
                viewModel.Id = user.Id;
            }

            viewModel.Users = _context.User.ToList();

            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            var viewModel = new IndexViewModel()
            {
                Users = _context.User.ToList()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public void CheckIn(int id)
        {
            var user = _context.User.Find(id);

            if (user == null) return;

            user.LastActive = DateTime.UtcNow;
            _context.User.Update(user);
            _context.SaveChanges();
        }

        [HttpGet]
        public JsonResult GetUserStatuses()
        {
            var users = _context.User.ToList();
            return Json(users);
        }
    }
}