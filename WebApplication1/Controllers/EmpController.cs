using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

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
        [HttpGet]
        public IActionResult Form6()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form6(int n1, int n2)
        {
            int sum = n1 + n2;
            HttpContext.Session.SetString("sum", sum.ToString());
            HttpContext.Session.SetString("n1", n1.ToString());
            HttpContext.Session.SetString("n2", n2.ToString());
            return RedirectToAction("Form7");
        }
        [HttpGet]
        public IActionResult Form7()
        {
            ViewBag.n1 = HttpContext.Session.GetString("n1");
            ViewBag.n2 = HttpContext.Session.GetString("n2");
            ViewBag.total = HttpContext.Session.GetString("sum");
            return View();
        }
        [HttpPost]
        [ActionName("Form7")]
        public IActionResult backTo5()
        {
            return RedirectToAction("Form6");
        }
        [HttpGet]
        public IActionResult Login()
        {
            var data = Request.Cookies["UserInfo"];
            if (data == null)
                return View();
            else
                return RedirectToAction("MyPage");
        }
        [HttpPost]
        public IActionResult Login(string user, string pass, string rem)
        {
            if ( rem != null)
            {
                CookieOptions obj = new CookieOptions();
                obj.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("UserInfo", user, obj);

            }
            if (user == "asp" && pass == "asp")
            {
                return RedirectToAction("MyPage");
            }
            return View();
        }
        [HttpGet]
        public string MyPage()
        {
            return "MyPage" ;
        }
    }
}
