using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class AmbulatorySheet
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser Dentist { get; set; }
        public ApplicationUser Patient { get; set; }
        public DateTime Date { get; set; }
        public string Diagnose { get; set; }
        public string Interventions { get; set; }
    }


}
