using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
