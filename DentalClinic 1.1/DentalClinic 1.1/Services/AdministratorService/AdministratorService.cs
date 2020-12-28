using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdministratorService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string username)
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
                UserName = email
            };

            return user;
        }
    }
}
