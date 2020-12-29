using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string username);
        public ApplicationUser CreateDentist(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string specialty, string description, string username);
        public string RemoveDentist(string id);
        public string RemovePatient(string id);
        public AllPatientsViewModel PatientDetails(string id);
        public AllDentistsViewModel DentistDetails(string id);
    }
}
