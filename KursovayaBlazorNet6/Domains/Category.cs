using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace KursovayaBlazorNet6.Domains
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> ServicesOfCategory { get; set; }

        public virtual ICollection<Doctor> DoctorsOfCategory { get; set; }
    }
}
