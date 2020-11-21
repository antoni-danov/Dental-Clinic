using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using DentalClinic_1._1.ViewModels.Specialization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services
{
    public interface IUsersService
    {
        //public string CreatePatient(AddPatientViewModel input);
        public IEnumerable<GetAllDentistsViewModel> GetAllDentists();
        public IEnumerable<ApplicationUser> AllPatients();
        public string CreateDentist(AddDentistViewModel input);
        public IEnumerable<AddDentistViewModel> AllDentists();
        public string CreateSpecialization(AddSpecializationViewModel input);
        public Task<IActionResult> RemovePatient(string userId);


    }
}
