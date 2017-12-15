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
    public class RoomController : Controller
    {
        public RoomController()
        {
            service = new RoomService();
        }

        private readonly IRoomService service;

        // GET: Patient
        public ActionResult Index()
        {
            var entities = service.GetAll();
            if (entities != null && entities.Any())
            {
                return View(entities);
            }
            else
            {
                return Content("<p>The list of rooms is empty<p>");
            }
        }

        public ActionResult FormRoom()
        {
            return View();
        }

        [HttpPost]
        public ContentResult CreateRoom(Room room)
        {
            service.Add(room);
            service.Save();
            return Content("<p>The room was created successfully!</p>");
        }

    }
}