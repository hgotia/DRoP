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
        //private readonly ViewModels.DonorViewQuestionViewModel db;
        private readonly models.DropDatabaseContext db;
        //public DonorViewsController(ViewModels.DonorViewQuestionViewModel db)
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

            //var questions = from s in db.dropDatabaseContext.DonorQuestions 
            var questions = from s in db.DonorQuestions
                            select s;

            questions = questions.OrderBy(s => s.Question);

            return View(questions.ToList());

            //return View(await _context.DonorQuestions.ToListAsync());
        }

        [AllowAnonymous]
        public IActionResult ScheduleAppointment()
        {
            return View();
        }
    }
}
