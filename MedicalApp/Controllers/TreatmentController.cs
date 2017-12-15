﻿using MedicalApp.BuisnessServices.Services.Implementation;
using MedicalApp.BuisnessServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalApp.Domain.Models;

namespace MedicalApp.Controllers
{
    public class TreatmentController : Controller
    {
        public TreatmentController()
        {
            treatmentService = new TreatmentService();
            doctorService = new DoctorService();
            patientService = new PatientService();
        }

        private readonly ITreatmentService treatmentService;
        private readonly IDoctorService doctorService;
        private readonly IPatientService patientService;

        // GET: Treatment
        public ActionResult Index()
        {
            var treatments = treatmentService.GetAll();
            var doctors = doctorService.GetAll();
            var patients = patientService.GetAll();
            
            ViewBag.doctors = doctors;
            ViewBag.patients = patients;
            return View(treatments);
        }

        public ActionResult FormTreatment()
        {
            var doctors = doctorService.GetAll();
            var patients = patientService.GetAll();

            var doctorsList = new SelectList(doctors, "Id", "FirstName");
            var patientsList = new SelectList(patients, "Id", "FirstName");
            ViewBag.doctors = doctorsList;
            ViewBag.patients = patientsList;
            return View();
        }

        [HttpPost]
        public ContentResult CreateTreatment(Treatment treatment)
        {
            treatmentService.Add(treatment);
            treatmentService.Save();
            return Content("<p>The patient was created successfully!</p>");
        }
    }
}