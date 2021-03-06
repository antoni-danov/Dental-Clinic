﻿using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public Specialization AddSpecialization(string name, string description);

        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string username);

        public ApplicationUser CreateDentist(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string specialty, string description, string username);

        public string RemoveDentist(string id);

        public string RemovePatient(string id);

        public string RemoveSpecialization(int id);

        public Task<IList<ApplicationUser>> AllPatients();

        public Task<IList<ApplicationUser>> AllDentists();

        public Task<IList<Specialization>> AllSpecializations();

        public AllPatientsViewModel PatientDetails(string id);

        public AllDentistsViewModel DentistDetails(string id);
    }
}