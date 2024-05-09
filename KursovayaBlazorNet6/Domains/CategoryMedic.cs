using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace KursovayaBlazorNet6.Domains
{
    [Table("CategoryMedic")]
    public class CategoryMedic
    {
        [Key]
        public long CategoryMedicId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doctor> MedicOfCategory { get; set; }
    }
}
