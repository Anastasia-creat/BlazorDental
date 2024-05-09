using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KursovayaBlazorNet6.Domains
{
    [Table("Reviews")]
    public class Reviews
    {
        [Key]
        public long ReviewId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }


    }
}
