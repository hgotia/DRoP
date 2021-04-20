using Drop.Web.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Drop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DropDatabaseContext db;
        public HomeController(DropDatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
