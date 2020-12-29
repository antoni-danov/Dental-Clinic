using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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