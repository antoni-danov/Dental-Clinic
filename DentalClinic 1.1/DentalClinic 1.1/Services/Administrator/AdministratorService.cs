using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public AdministratorService(UserManager<ApplicationUser> userManager,
                                    ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public ApplicationUser CreateDentist(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber)
        {
            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                UserName = lastname,
            };

            return user;
        }

        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber)
        {

            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                UserName = lastname
            };

            return user;
        }

        public string GetPatientById(string id)
        {
            if (id == null)
            {
                return "Id is not found.";
            }

            var patient = db.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return "This patient does not exist.";
            }

            return patient.Id.ToString();
        }

    }
}
