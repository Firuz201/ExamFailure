using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExamFailure.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
