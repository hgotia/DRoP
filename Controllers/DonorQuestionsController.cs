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
    public class DonorQuestionsController : Controller
    {
        private readonly DropDatabaseContext _context;

        public DonorQuestionsController(DropDatabaseContext context)
        {
            _context = context;
        }

        // GET: DonorQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonorQuestions.ToListAsync());
        }

        // GET: DonorQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorQuestion = await _context.DonorQuestions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (donorQuestion == null)
            {
                return NotFound();
            }

            return View(donorQuestion);
        }

        // GET: DonorQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonorQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,Question")] DonorQuestion donorQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donorQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donorQuestion);
        }

        // GET: DonorQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorQuestion = await _context.DonorQuestions.FindAsync(id);
            if (donorQuestion == null)
            {
                return NotFound();
            }
            return View(donorQuestion);
        }

        // POST: DonorQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,Question")] DonorQuestion donorQuestion)
        {
            if (id != donorQuestion.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donorQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorQuestionExists(donorQuestion.QuestionId))
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
            return View(donorQuestion);
        }

        // GET: DonorQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorQuestion = await _context.DonorQuestions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (donorQuestion == null)
            {
                return NotFound();
            }

            return View(donorQuestion);
        }

        // POST: DonorQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donorQuestion = await _context.DonorQuestions.FindAsync(id);
            _context.DonorQuestions.Remove(donorQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorQuestionExists(int id)
        {
            return _context.DonorQuestions.Any(e => e.QuestionId == id);
        }
    }
}
