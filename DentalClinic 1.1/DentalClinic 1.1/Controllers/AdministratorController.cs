using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult AddPatient()
        {
            return View();
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
