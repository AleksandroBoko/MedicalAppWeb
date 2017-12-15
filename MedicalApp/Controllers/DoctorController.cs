using MedicalApp.BuisnessServices.Services;
using MedicalApp.BuisnessServices.Services.Implementation;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MedicalApp.Controllers
{
    public class DoctorController : Controller
    {
        public DoctorController()
        {
            service = new DoctorService();
        }

        private readonly IDoctorService service;

        // GET: Doctor
        public ActionResult Index()
        {
            var entities = service.GetAll();
            return View(entities);
        }

        public ActionResult FormDoctor()
        {
            return View();
        }

        [HttpPost]
        public ContentResult CreateDoctor(Doctor doctor)
        {
            service.Add(doctor);
            service.Save();
            return Content("<p>The doctor was created successfully!</p>");
        }
    }
}