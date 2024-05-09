using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.BusinessLogic;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using System;
using System.Linq;


namespace KursovayaBlazorNet6.Controllers
{
    [AllowAnonymous()]
    public class DoctorController : Controller
    {
        private int _serviceQuantityPerPage = 40;
        private readonly IRepository<Doctor> _repositoryDoctors;
        private readonly IRepository<Category> _repositoryCategories;

        public DoctorController(IRepository<Doctor> repositoryDoctors, 
            IRepository<Category> repositoryCategory)
        {
            _repositoryDoctors = repositoryDoctors;
            _repositoryCategories = repositoryCategory;
        }
        

       
        public IActionResult CartView(string urlReturn)
        {
            ViewBag.UrlReturn = urlReturn;
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(long id, string urlReturn)
        {
            var doctor = _repositoryDoctors.Read(id);

            if (doctor == null) return View("Error");

            var model = doctor.Adapt<DoctorModel>();

            //сохраняем 
            var cart = GetCart();
            cart.AddCoupons(model);
            SaveCart(cart);

            return new RedirectResult(urlReturn);
           // return View("CartView", cart);
        }

        private void SaveCart(Cart cart)
        {
            string json = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", json);
        }

        private Cart GetCart()
        {
            Cart cart = null;
            string json = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(json))
            {
                cart = new Cart();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(json);
            }
            return cart;
        }

        public IActionResult ListView(string categoryName)
        {

            var category = _repositoryCategories
              .FindByName(categoryName);

            var query = _repositoryDoctors
               .GetList()
               .Where(p =>
                   category == null ||
                   p.DoctorCategory.CategoryId == category.CategoryId);

            var servicesSample = query
                .OrderBy(x => x.DoctorId)
               // .Skip((page - 1) * _serviceQuantityPerPage)
                .Take(_serviceQuantityPerPage)
                 .Select(e => e.Adapt<DoctorBriefModel>());

            int totalServicesQuantity = query.Count();


            //int pagesQuantity = (int)
            //    Math.Ceiling(
            //    totalServicesQuantity /
            //    (double)_serviceQuantityPerPage
            //    );

            var model = new DoctorPageModel
            {
                DoctorForPage = servicesSample,
              //  ActivePage = page,
               // PagesQuantity = pagesQuantity,
                CategoryName = categoryName

            };

            return View(model);
        }

        public IActionResult DoctorsDetailsView(long id)
        {
            var entity = _repositoryDoctors.Read(id);
            var model = entity.Adapt<DoctorModel>();

            return View(model);

           
            
        }

      
       
    }
}
