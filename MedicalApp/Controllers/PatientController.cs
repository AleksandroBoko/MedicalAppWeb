﻿using MedicalApp.BuisnessServices.Services;
using MedicalApp.BuisnessServices.Services.Implementation;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalApp.Controllers
{
    public class PatientController : Controller
    {
        public PatientController()
        {
            patientService = new PatientService();
            roomService = new RoomService();
        }

        private readonly IPatientService patientService;
        private readonly IRoomService roomService;

        // GET: Patient
        public ActionResult Index()
        {
            var patients = patientService.GetAll();
            var rooms = roomService.GetAll();            
            ViewBag.rooms = rooms;
            
            return View(patients);
        }

        public ActionResult FormPatient()
        {
            
            var rooms = roomService.GetAll();
            var selectList = new SelectList(rooms, "Id", "Number", "Number");
            ViewBag.selectList = selectList;

            return View();
        }

        [HttpPost]
        public ContentResult CreatePatient(Patient patient)
        {
            patientService.Add(patient);
            patientService.Save();
            return Content("<p>The patient was created successfully!</p>");
        }
    }
}