﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Dentists()
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