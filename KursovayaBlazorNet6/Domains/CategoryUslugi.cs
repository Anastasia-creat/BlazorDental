using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace KursovayaBlazorNet6.Domains
{
    [Table("CategoryUslugi")]
    public class CategoryUslugi
    {

        [Key]
        public long CategoryUslugiId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> UslugiOfCategory { get; set; }
    }
}
