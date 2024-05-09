using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using KursovayaBlazorNet6.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using KursovayaBlazorNet6.Domains;
using System.Linq;

namespace KursovayaBlazorNet6.Models
{
    public class EditDoctorsModel
    {
        // для загрузки картинок с клиента на сервер!
        public IFormFile ImageFile { get; set; }

        public void ApplyCategory(
          
           IRepository<Category> categoryRepository)
        {
            var categories = categoryRepository.GetList().ToList();
           
            CreateSelectListItems(categories);
        }
        public Doctor AsDoctor(
     IRepository<Category> categoryRepository)
        {
            return new Doctor
            {
                Description = this.Description,
                ImageUrl = this.ImageUrl,
                Name = this.Name,
                
                DoctorId = this.DoctorId,
               
                DoctorCategory = categoryRepository.Read(SelectedCategoryId)
            };
        }

        public string UrlReturn { get; set; }

        public long SelectedCategoryId { get; set; }

       

        public List<SelectListItem> ListCategories { get; set; }

      


        [Display(Name = "Категория")]
        public string Category { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long DoctorId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

     

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public EditDoctorsModel()
        { }

        public EditDoctorsModel(
            Doctor entity,
            List<Category> categories)
        {
            DoctorId = entity.DoctorId;

            SelectedCategoryId = entity.DoctorCategory.CategoryId;

            Name = entity.Name;
            Description = entity.Description;

            ImageUrl = entity.ImageUrl;

            Category = entity.DoctorCategory.Name;

            CreateSelectListItems(categories);
        }

        private void CreateSelectListItems(
            List<Category> categories)
        {
            ListCategories = categories
                .Select(
                c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                })
                .ToList();
          
        }

        //public EditDoctorsModel(
        //    List<Category> categories)
        //{
        //    CreateSelectListItems(categories);
        //}
    }
}
