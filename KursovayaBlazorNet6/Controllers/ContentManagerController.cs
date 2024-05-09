using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KursovayaBlazorNet6.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class ContentManagerController : Controller
    {

        private readonly IRepository<Service> _repositoryServices;
        private readonly IRepository<Category> _repositoryCategories;

        private readonly IRepository<Doctor> _repositoryDoctors;
        private readonly IRepository<Reviews> _repositoryReviews;

        public ContentManagerController(IRepository<Service> repositoryServices,
            IRepository<Category> repositoryCategories, IRepository<Doctor> repositoryDoctors,
            IRepository<Reviews> repositoryReviews)
        {
            _repositoryServices = repositoryServices;
            _repositoryCategories = repositoryCategories;
            _repositoryDoctors = repositoryDoctors;
            _repositoryReviews = repositoryReviews;
        }
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult DeleteReviewView(long id)
        {
            var rev = _repositoryReviews.GetList();

            if(rev != null)
            {
                _repositoryReviews.Delete(id);
            }
            return Redirect("/Home/Index");
        }



        //услуги
        public IActionResult AddService()
        {
            var categories = _repositoryCategories.GetList();


            var model = new EditServicesModel();
             


            model.ApplyCategory(_repositoryCategories);

            model.UrlReturn = "Index";

            return View("EditServicesView", model);
        }

        public IActionResult EditServicesView(long id, string urlReturn)
        {
            var entity = _repositoryServices.Read(id);
            var categories = _repositoryCategories.GetList();

          

            var model = entity.Adapt<EditServicesModel>();
            model.ApplyCategory( _repositoryCategories);


            model.UrlReturn = urlReturn;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditServicesView(EditServicesModel editModel)
        {
            if (ModelState.IsValid)
            {
               // UploadImage(editModel);

                var model = editModel
                    .AsService(_repositoryCategories);

                if(editModel.ServiceId == 0)
                {
                    _repositoryServices.Create(model);
                }
                else
                {
                    _repositoryServices.Update(model);
                }

               

                string urlReturn = editModel.UrlReturn;

                return new RedirectResult(urlReturn);
            }
            return View(editModel);
        }

        //врачи
        public IActionResult AddDoctors()
        {
            var categories = _repositoryCategories.GetList();


            var model = new EditDoctorsModel();
            model.ApplyCategory(_repositoryCategories);


            model.UrlReturn = "Index";

            return View("EditDoctorsView", model);
        }

        //ВРАЧИ
        public IActionResult EditDoctorsView(long id, string urlReturn)
        {
            var entity = _repositoryDoctors.Read(id);
            var categories = _repositoryCategories.GetList();

            var model = new EditDoctorsModel(entity, categories.ToList());
            model.UrlReturn = urlReturn;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditDoctorsView(EditDoctorsModel editModel)
        {
            if (ModelState.IsValid)
            {
                UploadImage(editModel);

                var model = editModel
                    .AsDoctor(_repositoryCategories);

                if(editModel.DoctorId == 0)
                {
                    _repositoryDoctors.Create(model);
                    
                }
                else
                {
                    _repositoryDoctors.Update(model);
                }

                string urlReturn = editModel.UrlReturn;

                return new RedirectResult(urlReturn);
            }
            return View(editModel);
        }

        private void UploadImage(EditDoctorsModel editModel)
        {

            if (editModel.ImageFile == null)
            {
                Debug.WriteLine("картинка не найдена");
                return;
            }

            string ext = Path.GetExtension(editModel.ImageFile.FileName);
            string uniqueName = Guid.NewGuid().ToString() + ext;
            string filename = Path.Combine(
                Directory.GetCurrentDirectory(),
                @"wwwroot\DoctorsImages",
                uniqueName);

            // сохраняем физический файл на сервер
            using (var stream = System.IO.File.Create(filename))
            {
                editModel.ImageFile.CopyTo(stream);
            }

            // в БД заменить на новое имя файла
            editModel.ImageUrl = uniqueName;


        }
    }
}
