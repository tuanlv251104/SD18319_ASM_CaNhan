using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using ShopTrangSuc.Models;
using System.Diagnostics;

namespace ShopTrangSuc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = new AppDbContext();
        }

        public IActionResult Index()
        {
            var datasp = _db.sanPhams.ToList();
            var data = HttpContext.Session.GetString("username"); // Lấy data từ session
            if (data == null) ViewData["login"] = "Chưa đăng nhập";
            else ViewData["login"] = "Xin chào " + data;
            return View(datasp);
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