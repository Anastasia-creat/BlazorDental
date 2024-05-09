
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Mapster;
using KursovayaBlazorNet6.DataAccessLayer;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;

namespace KursovayaBlazorNet6.Controllers
{
    public class ServiceController : Controller
    {

        ApplicationDbContext db;
        private int _serviceQuantityPerPage = 7;

        private readonly IRepository<Service> _repositoryServices;
       private readonly IRepository<Category> _repositoryCategories;

        public ServiceController(IRepository<Service> repositoryServices,
            IRepository<Category> repositoryCategories, ApplicationDbContext context)
        {
            _repositoryServices = repositoryServices;
            _repositoryCategories = repositoryCategories;
            db = context;
        }

        
        public IActionResult ListView(string categoryName, string name)
        {
            var category = _repositoryCategories
               .FindByName(categoryName);

            var query = _repositoryServices
               .GetList()
               .Where(p =>
                   category == null ||
                   p.ServiceCategory.CategoryId == category.CategoryId);

           // добавляем механизм пагинации
            var servicesSample = query
                .OrderBy(x => x.ServiceId)
               // .Skip((page - 1) * _serviceQuantityPerPage)
                .Take(_serviceQuantityPerPage)
                .Select(e => e.Adapt<ServicesBriefModel>());

            int totalServicesQuantity = query.Count();



            //int pagesQuantity = (int)
            //    Math.Ceiling(
            //    totalServicesQuantity /
            //    (double)_serviceQuantityPerPage
            //    );


           
           
         
            var model = new ServicePageModel
            {
                ServicesForPage = servicesSample,
               // ActivePage = page,
               // PagesQuantity = pagesQuantity,
                CategoryName = categoryName

            };

            return View(model);


        }

       

        public IActionResult ServicesDetailsView(long id)
        {
            var entity = _repositoryServices.Read(id);
           
            
            var model = entity.Adapt<ServicesModel>();

            return View(model);

          

        }
    }
}
