using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Services.Administrator;
using DentalClinic_1._1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IUsersService usersService;

        public AdministratorController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(AddPatientViewModel input)
        {
            var user = usersService.CreatePatient(input);

            return Redirect("/Administrator/All");
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
