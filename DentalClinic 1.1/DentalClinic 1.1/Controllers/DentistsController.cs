using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Dentist")]
    public class DentistsController : Controller
    {
        public IActionResult Patients()
        {
            return View();
        }
        public IActionResult Appointments()
        {
            return View();
        }
    }
}
