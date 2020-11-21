using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Aministrator, Patient")]
    public class PatientsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public PatientsController(UserManager<ApplicationUser> userManager, IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }
        public async Task<IActionResult> Dentists()
        {
            if(!User.Identity.IsAuthenticated == true)
            {
                return this.Redirect("/Users/Login");
            }
            
            var dentists = this.usersService.GetAllDentists();

            return View(dentists);
        }
        public IActionResult Appointments()
        {
            return View();
        }
        public IActionResult GetAppointment()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }

    }
}
