using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KursovayaBlazorNet6.Models
{
    public class ReviewsModel
    {

        [HiddenInput(DisplayValue = false)]
        public long ReviewId { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }


        [Display(Name = "Отзыв")]
        public string Text { get; set; }

        [Display(Name = "Дата")]
        public string Date { get; set; }
    }
}
