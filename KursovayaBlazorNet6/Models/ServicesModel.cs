
using KursovayaBlazorNet6.Domains;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KursovayaBlazorNet6.Models
{
    public class ServicesModel
    {
        public ServicesModel()
        { }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        //Uslugi new
        [Display(Name = "Категория на услуги")]
        public string CategoryUslugi { get; set; }


        [HiddenInput(DisplayValue = false)]
        public long ServiceId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        //public ServicesModel(Service entity)
        //{
        //    ServiceId = entity.ServiceId;

        //    Name = entity.Name;

        //    Price = entity.Price;


        //    Category = entity.ServiceCategory.Name;
        //}

    }
}
