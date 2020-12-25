using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            var password = "$A123b456";
            var passrodHash = ComputeHash(password);

            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                Password = passrodHash,
                UserName = lastname
            };

            return user;
        }
        //OK
        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber)
        {
            var password = "#A123b456";
            var passwordHash = ComputeHash(password);


            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                Password = passwordHash,
                UserName = lastname
            };

            return user;
        }
        //OK
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
        //OK
        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
