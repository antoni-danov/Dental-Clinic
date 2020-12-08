using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Dentist")]
    public class DentistsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public DentistsController(UserManager<ApplicationUser> userManager,
                                  ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public IActionResult Patients()
        {
                       return View();
        }
        public async Task<IActionResult> Appointments()
        {
            return View();
        }

    }
}
