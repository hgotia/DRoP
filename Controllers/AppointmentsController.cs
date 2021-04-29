using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Drop.Web.models;

namespace Drop.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly DropDatabaseContext _context;

        public AppointmentsController(DropDatabaseContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index(string sortOrder, string searchString, DateTime searchDate)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";

            var appointment = from s in _context.Appointments
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                appointment = appointment.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            //remove if doesn't work
            //if (!String.IsNullOrEmpty(searchDate.ToString()))
            //{
            //    appointment = appointment.Where(s => s.Date.Year == searchDate.Year &&
            //                                        s.Date.Month == searchDate.Month &&
            //                                        s.Date.Day == searchDate.Day);
            //}

            switch (sortOrder)
            {
                case "name_desc":
                    appointment = appointment.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    appointment = appointment.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    appointment = appointment.OrderByDescending(s => s.Date);
                    break;
                case "Time":
                    appointment = appointment.OrderBy(s => s.Time);
                    break;
                case "time_desc":
                    appointment = appointment.OrderByDescending(s => s.Time);
                    break;
                default:
                    appointment = appointment.OrderBy(s => s.Date);
                    break;
            }
            return View(appointment.ToList());
            //return View(await _context.Appointments.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,FirstName,LastName,PhoneNumber,Date,Time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("thanks");
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,FirstName,LastName,PhoneNumber,Date,Time")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }

        public async Task<IActionResult> Thanks()
        {
            return View();
        }
    }
}
