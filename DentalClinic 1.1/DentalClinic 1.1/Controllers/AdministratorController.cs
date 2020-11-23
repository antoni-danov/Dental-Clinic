﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager,
                                       UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(AddPatientViewModel input)
        {
            var roleName = "Patient";

            var createPatient = new ApplicationUser
            {
                Firstname = input.FirstName,
                Lastname = input.LastName,
                Email = input.Email,
                Birthdate = input.BirthDate,
                Address = input.Address,
                Town = input.Town,
                PhoneNumber = input.PhoneNumber

            };

            var user = await userManager.CreateAsync(createPatient);
            var userManage = await userManager.GetUserAsync(User);

            if (!User.IsInRole(roleName))
            {
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }

            return Redirect("/AllPatients");
        }
        public IActionResult RemovePatient()
        {

            return View();
        }
        public IActionResult AllPatients()
        {
            return View();
        }
        public IActionResult AddDentist()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDentist(AddDentistViewModel input)
        {
            var roleName = "Dentist";
            var userManage = await userManager.GetUserAsync(User);

            if (!User.IsInRole(roleName))
            {
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }
            return View();
        }
        public IActionResult RemoveDentist()
        {
            return View();
        }
        public IActionResult AllDentists()
        {
            return View();
        }
        public IActionResult AddSpecialization()
        {
            return View();
        }
        public IActionResult RemoveSpecialization()
        {
            return View();
        }
        public IActionResult AllSpecialties()
        {
            return View();
        }
    }
}
