using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Aministrator, Patient")]
    public class PatientsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public PatientsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Dentists()
        {
            return View();
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
