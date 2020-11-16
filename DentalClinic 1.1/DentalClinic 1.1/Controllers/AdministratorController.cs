using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Services.Administrator;
using DentalClinic_1._1.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly UsersService usersService;

        public AdministratorController(UsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult AddPatient(AddUserViewModel input)
        {
            usersService.CreateUser(input);
            return Redirect("/");
        }
        public IActionResult All()
        {
            if (!User.Identity.IsAuthenticated == true)
            {
                return this.Redirect("/Users/Login");
            }
            var patients = this.usersService.All();
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
