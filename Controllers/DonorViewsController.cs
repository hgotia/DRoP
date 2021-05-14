using Drop.Web.models;
using Drop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Drop.Web.Controllers
{
    public class DonorViewsController : Controller
    {
        private readonly DropDatabaseContext db;

        public DonorViewsController(models.DropDatabaseContext db)
        {
            this.db = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Questions(string sortOrder)
        {
            ViewBag.QSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var questions = from s in db.DonorQuestions
                            select s;

            questions = questions.OrderBy(s => s.Question);

            return View(questions.ToList());
        }

        [AllowAnonymous]
        public IActionResult ScheduleAppointment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("AppointmentId,FirstName,LastName,PhoneNumber,Date,Time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Add(appointment);
                await db.SaveChangesAsync();
                return RedirectToAction("thanks");
            }
            return View(appointment);
        }

        [AllowAnonymous]
        public IActionResult Thanks()
        {
            return View();
        }
    }
}