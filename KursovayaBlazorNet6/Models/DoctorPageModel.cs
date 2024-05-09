using System.Collections.Generic;

namespace KursovayaBlazorNet6.Models
{
    public class DoctorPageModel
    {
        public string CategoryName { get; set; }
      //  public IEnumerable<ServicesBriefModel> ServicesForPage { get; set; }

        public IEnumerable<DoctorBriefModel> DoctorForPage { get; set; }

        public int PagesQuantity { get; set; }

        public int ActivePage { get; set; }
    }
}
