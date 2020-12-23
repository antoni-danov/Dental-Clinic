using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public interface IAdministratorService
    {
        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber);
        public string GetPatientById(string id);
        public ApplicationUser CreateDentist(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber);


    }
}
