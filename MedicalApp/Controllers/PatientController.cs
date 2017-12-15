using MedicalApp.BuisnessServices.Services;
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
            service = new PatientService();
        }

        private readonly IPatientService service;

        // GET: Patient
        public ActionResult Index()
        {
            var entities = service.GetAll();
            return View(entities);
            //if (entities != null && entities.Any())
            //{
            //    return View(entities);
            //}
            //else
            //{
            //    return Content("<p>The list of patients is empty<p>");
            //}
        }

        public ActionResult FormPatient()
        {
            var roomService = new RoomService();
            var rooms = roomService.GetAll();
            var selectList = new SelectList(rooms, "Id", "Number", "Number");
            ViewBag.selectList = selectList;

            return View();
        }

        [HttpPost]
        public ContentResult CreatePatient(Patient patient)
        {
            service.Add(patient);
            service.Save();
            return Content("<p>The patient was created successfully!</p>");
        }
    }
}