using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class Appointment
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Dentist { get; set; }
        [Required]
        public string Patient { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public AmbulatorySheet AmbulatorySheets { get; set; }
        public ApplicationUser User { get; set; }

    }
}
