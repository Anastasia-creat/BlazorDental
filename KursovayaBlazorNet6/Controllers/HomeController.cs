using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KursovayaBlazorNet6.DataAccessLayer;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Providers.Entities;

namespace KursovayaBlazorNet6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //-------------------
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Reviews.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Reviews review)
        {
            db.Reviews.Add(review);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        //--------

        //[HttpGet]
        //public IActionResult ReviewsView()
        //{
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult ReviewsView(string name, string text, bool isAgree)
        //{
        //    string authData = $"Name: {name}   Text: {text}   isAgree: {isAgree}";

        //    if(authData != null)
        //    {

        //    }
        //    return RedirectToAction("Reviews");
        //}

        //public IActionResult Reviews()
        //{
        //    return View();
        //}
       

        //public IActionResult Index()
        //{
        //    return View();
        //}

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
