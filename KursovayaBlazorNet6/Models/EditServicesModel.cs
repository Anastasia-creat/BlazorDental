using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace KursovayaBlazorNet6.Models
{
    public class EditServicesModel
    {

        public void ApplyCategory(IRepository<Category> categoryRepository)
        {
            var categories = categoryRepository.GetList().ToList();
            CreateSelectListItems(categories);
        }

        public  Service AsService(
            IRepository<Category> categoryRepository)
        {
            return new Service
            {
                Name = this.Name,
                Price = this.Price,
                ServiceId = this.ServiceId,
                ServiceCategory = categoryRepository.Read(SelectedCategoryId),


            };
        }

        public long SelectedCategoryId { get; set; }

        public string UrlReturn { get; set; }

        public List<SelectListItem> ListCategories { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long ServiceId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public EditServicesModel()
        {

        }

        private void CreateSelectListItems(
            List<Category> categories
           )
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


     
        //public EditServicesModel(Service entity, List<Category> categories)
        //{
        //    ServiceId = entity.ServiceId;
        //    SelectedCategoryId = entity.ServiceCategory.CategoryId;
        //    Name = entity.Name;
        //    Category = entity.ServiceCategory.Name;
        //    Price = entity.Price;

        //    ListCategories = categories
        //        .Select(
        //        c => new SelectListItem()
        //        {
        //            Text = c.Name,
        //            Value = c.CategoryId.ToString()
        //        })
        //        .ToList();

        //}



    }
}
