using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public UnitTest1(UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        [Fact]
        public void ShouldAddPatientToTheDatabase()
        {
            var createPatient = new ApplicationUser
            {
                Firstname = "John",
                Lastname = "Dow",
                Email = "j.dow@test.bg",
                Birthdate = DateTime.Now,
                Address = "34, Washington square",
                Town = new Town (),
                PhoneNumber = "0329470294",
                UserName = "j.dow@test.bg"
            };

            var user = userManager.CreateAsync(createPatient);
            
           //TODO Act

               //TODO Assert

        }
    }
}
