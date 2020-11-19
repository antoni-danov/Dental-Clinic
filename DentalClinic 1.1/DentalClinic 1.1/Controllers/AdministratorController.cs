using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services.Administrator;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IUsersService usersService;
        private readonly RoleManager<string> roleManager;
        private readonly UserManager<string> userManager;

        public AdministratorController(IUsersService usersService,
                                       RoleManager<string> roleManager,
                                       UserManager<string> userManager)
        {
            this.usersService = usersService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientViewModel input)
        {

            var user = usersService.CreatePatient(input);

            var roleName = "Patient";
            var roleExist = await roleManager.RoleExistsAsync(roleName);

            if (roleExist)
            {
                var userManage = await userManager.GetUserAsync(User);
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }

            return Redirect("/Administrator/AllPatients");
        }
        public IActionResult AllPatients()
        {
            if (!User.Identity.IsAuthenticated == true)
            {
                return this.Redirect("/Users/Login");
            }
            var patients = this.usersService.AllPatients();
            return View(patients);
        }
        public IActionResult RemovePatient()
        {
            return View();
        }
        public IActionResult AddDentist()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDentist(AddDentistViewModel input)
        {
            var dentist = this.usersService.CreateDentist(input);

            var roleName = "Dentist";
            var roleExist = await roleManager.RoleExistsAsync(roleName);

            if (roleExist)
            {
                var userManage = await userManager.GetUserAsync(User);
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }
            return Redirect("/Administrator/AllDentists");
        }
        public IActionResult RemoveDentist()
        {
            return View();
        }
        public IActionResult AllDentists()
        {
            if (!User.Identity.IsAuthenticated == true)
            {
                return this.Redirect("/Users/Login");
            }
            var dentists = this.usersService.AllDentists();
            return View(dentists);
        }

        public IActionResult AddSpecialization()
        {
            return View();
        }
        public IActionResult RemoveSpecialization()
        {
            return View();
        }
    }
}
