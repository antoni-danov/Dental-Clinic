﻿using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Administrator
{
    public class AddUserViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public Town Town { get; set; }
        public string PhoneNumber { get; set; }
    }
}