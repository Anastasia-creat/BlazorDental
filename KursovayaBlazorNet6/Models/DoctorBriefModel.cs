using KursovayaBlazorNet6.Domains;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace KursovayaBlazorNet6.Models
{
    public class DoctorBriefModel
    {
        [HiddenInput(DisplayValue = false)]
        public long DoctorId { get; set; }

        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Категория")]
        public string CategoryMedic { get; set; }

        public DoctorBriefModel()
        { }

        public DoctorBriefModel(Doctor entity)
        {
           
            Name = entity.Name;
          
            Category = entity.DoctorCategory.Name;
            CategoryMedic = entity.MedicCategory.Name;
            DoctorId = entity.DoctorId;


        }
    }
}
