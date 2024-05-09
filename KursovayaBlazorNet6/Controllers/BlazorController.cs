using Microsoft.AspNetCore.Mvc;

namespace KursovayaBlazorNet6.Controllers
{
    public class BlazorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexDoctor()
        {
            return View();
        }


        public IActionResult IndexMain()
        {
            return View();
        }

    }
}
