using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KursovayaBlazorNet6.Domains
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        public long DoctorId { get; set; }

        public string Name { get; set; }

        public virtual Category DoctorCategory { get; set; }
        public virtual CategoryMedic MedicCategory { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }


      // public virtual ICollection<OrderRecord> OrderRecordsForDoctors { get; set; }



    }
}
