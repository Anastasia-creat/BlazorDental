using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.BusinessLogic;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace KursovayaBlazorNet6.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IRepository<Doctor> _repositoryDoctors;
        private readonly IRepository<Category> _repositoryCategories;

        public AdminController(IRepository<Doctor> repositoryDoctors, IRepository<Category>
            repositoryCategories)
        {
            _repositoryDoctors = repositoryDoctors;
            _repositoryCategories = repositoryCategories;
        }



        public IActionResult DeleteDoctor(long id)
        {
            var doctor = _repositoryDoctors.GetList();

            if (doctor != null)
            {
                _repositoryDoctors.Delete(id);
            }



            return Redirect("/Doctor/ListView");
        }
       

        //===========================

        public IActionResult EditCategories()
        {
            var categories = _repositoryCategories.GetList();
            return View(categories);
        }


        //-------------------------------------------------
        //Редактирование категорий
        public IActionResult AddCategory()
        {
            var category = new Category();
            return View("EditCategory", category);
        }

        public IActionResult DeleteCategory(long id)
        {
            var category = _repositoryCategories.ReadWithRelations(id);
            if (category.DoctorsOfCategory.Count() > 0)
            {
                ViewBag.ErrorMessage = "Нельзя удалять категорию с товарами!";
                return View("Error");
            }
            else
            {
                _repositoryCategories.Delete(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(long id)
        {
            var category = _repositoryCategories.Read(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryId == 0)
                {
                    _repositoryCategories.Create(model);
                }
                else
                {
                    _repositoryCategories.Update(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //----------------------------------------------------------------

        public IActionResult AddProduct()
        {
            var categories = _repositoryCategories.GetList();


            var model = new EditDoctorsModel();
            model.ApplyCategory(_repositoryCategories);


            model.UrlReturn = "Index";

            return View("EditDoctorsView", model);
        }

        public IActionResult EditDoctorsView(long id, string urlReturn)
        {
            var entity = _repositoryDoctors.Read(id);
            var categories = _repositoryCategories.GetList();
         

            var model = new EditDoctorsModel(
                entity,
                categories.ToList());

            model.UrlReturn = urlReturn;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditDoctorsView(EditDoctorsModel editModel)
        {
            if (ModelState.IsValid)
            {
                // Download, Upload
                UploadImage(editModel);

                var model = editModel
                    .AsDoctor( _repositoryCategories);

                if (editModel.DoctorId == 0)
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



        public void UploadImage(EditDoctorsModel editModel)
        {
            if(editModel.ImageFile == null)
            {
                Debug.WriteLine("Фото не найдено");
                return;
            }

            string ext = Path.GetExtension(editModel.ImageFile.FileName);
            string uniqueName = Guid.NewGuid().ToString() + ext;

            string filename = Path.Combine(
                Directory.GetCurrentDirectory(),
                @"wwwroot\DoctorsImages",
                uniqueName);

            //сохраняем физический файл на сервер
            using (var stream = System.IO.File.Create(filename))
            {
                editModel.ImageFile.CopyTo(stream);
            }

            editModel.ImageUrl = uniqueName;

            
        }

        //public IActionResult DeleteDoctors(long id)
        //{
        //    var doctor = _repositoryDoctors.GetList();
        //    if (doctor == null) 
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        _repositoryDoctors.Delete(id);
        //    }

        //    return RedirectToAction("Index");
        //}

        


        public IActionResult Index()
        {
            var cart = new Cart();
            return View(cart);
        }

    }
}
