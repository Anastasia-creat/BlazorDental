using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursovayaBlazorNet6.Domains
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public long ServiceId { get; set; }

        public string Name { get; set; }

        public virtual Category ServiceCategory { get; set; }


        public virtual CategoryUslugi UslugiCategory { get; set; }

      //  public virtual ICollection<OrderRecord> OrderRecordsForServices { get; set; }

        public int Price { get; set; }
    }
}
