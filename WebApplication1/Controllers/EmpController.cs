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
        public IActionResult Form2()
        {
            return View();
        }
    }
}
