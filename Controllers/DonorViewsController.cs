using Drop.Web.models;
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
        public DonorViewsController(DropDatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Questions(string sortOrder)
        {
            ViewBag.QSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var questions = from s in db.DonorQuestions
                            select s;

            questions = questions.OrderBy(s => s.Question);

            return View(questions.ToList());
            //return View(await _context.DonorQuestions.ToListAsync());
        }
        public IActionResult ScheduleAppointment()
        {
            return View();
        }
    }
}
