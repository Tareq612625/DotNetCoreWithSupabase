using DotNetCoreWithSuperbase.Interface;
using DotNetCoreWithSuperbase.Models;
using DotNetCoreWithSuperbase.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetCoreWithSuperbase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISuperbaseService _superbaseService;
        private readonly SupabaseConnection _supabaseConnection;

        public HomeController(ILogger<HomeController> logger, ISuperbaseService superbaseService, SupabaseConnection supabaseConnection)
        {
            _logger = logger;
            _superbaseService = superbaseService;
            _supabaseConnection = supabaseConnection;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _supabaseConnection.GetStudentListDataAsync();
            var list1 = await _supabaseConnection.GetStudentListbyFunction();

            return View(list1);
        }
        [HttpGet]
        public async Task<IActionResult> CreateStudent()
        {
            var list = await _supabaseConnection.GetStudentListDataAsync();
            return View(new Student());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student obj)
        {
           _supabaseConnection.CreateStudent(obj);
            return View();
        }
        public async Task<IActionResult> Indexcopy()
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
