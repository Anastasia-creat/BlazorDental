using KursovayaBlazorNet6.Domains;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace KursovayaBlazorNet6.Models
{
    public class ServicesBriefModel
    {
        [HiddenInput(DisplayValue = false)]
        public long ServiceId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public ServicesBriefModel()
        { }
        public ServicesBriefModel(Service entity)
        {
            Name = entity.Name;
            Price = entity.Price;
            ServiceId = entity.ServiceId;
        }

    }
}
