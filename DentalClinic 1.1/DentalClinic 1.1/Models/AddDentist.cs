using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class AddDentists
    {
        public AddDentists()
        {
            Specialty = new HashSet<Specialization>();
        }
        public AddDentistViewModel Dentist { get; set; }
        public ICollection<Specialization> Specialty { get; set; }
    }
}