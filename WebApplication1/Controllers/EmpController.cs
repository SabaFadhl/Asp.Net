using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string print()
        {
            return "Hello world";
        }
        public string getID(int id)
        {
            return "ID = "+ id;
        }
        public string getAge(int a)
        {
            return "your age is " + a;
        }
        public int sum(int a , int b)
        {
            return a + b;
        }
        public IActionResult Form1()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Form2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form2(int n1, int n2)
        {
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.sum = n1 + n2;
            ViewData["sum"] = n1 + n2;
            return View();
        }
        [HttpGet]
        public IActionResult Form3()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Form3(string tname, string gender, int age, string status, string notes)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Form4()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form4(int n1, int n2)
        {
            int sum = n1 + n2;
            TempData["n1"] = n1.ToString();
            TempData["n2"] = n2.ToString();
            TempData["sum"] = sum.ToString();
            return RedirectToAction("Form5");
        }
        [HttpGet]
        public IActionResult Form5()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Form5")]
        public IActionResult back()
        {
            return RedirectToAction("Form4");
        }
    }
}
