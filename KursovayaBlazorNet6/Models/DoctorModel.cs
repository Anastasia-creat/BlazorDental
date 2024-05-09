using KursovayaBlazorNet6.Domains;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace KursovayaBlazorNet6.Models
{
    public class DoctorModel
    {
        [HiddenInput(DisplayValue = false)]
        public long DoctorId { get; set; }

        [Display(Name ="ФИО")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string Category  { get; set; }

        //Medic new
        [Display(Name = "Категория на врачей ")]
        public string CategoryMedic { get; set; }


        [BindProperty, DataType(DataType.Date)]
        public DateTime DateValue { get; set; }

        [BindProperty]
        public DateTime Day { get; set; } = DateTime.Now;




        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Фото")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public string  UrlReturn { get; set; }
        public DoctorModel()
        {   }

        public DoctorModel(Doctor entity)
        {
            Name = entity.Name;
            Description = entity.Description;
            Category = entity.DoctorCategory.Name;
            CategoryMedic = entity.MedicCategory.Name;
            ImageUrl = entity.ImageUrl;
            DoctorId = entity.DoctorId;
        }
    }
}
