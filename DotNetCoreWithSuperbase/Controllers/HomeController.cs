using DotNetCoreWithSuperbase.Interface;
using DotNetCoreWithSuperbase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetCoreWithSuperbase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISuperbaseService _superbaseService;

        public HomeController(ILogger<HomeController> logger, ISuperbaseService superbaseService)
        {
            _logger = logger;
            _superbaseService = superbaseService;
        }

        public async Task<IActionResult> Index()
        {
            var studentList = await _superbaseService.GetStudentsAsync();
            return View(studentList);
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
