using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
namespace NAMIS.Controllers
{
    public class TrainingAndStudiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public TrainingAndStudiesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: TrainingAndStudies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingAndStudy.ToListAsync());
        }

        // GET: TrainingAndStudies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingAndStudy = await _context.TrainingAndStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingAndStudy == null)
            {
                return NotFound();
            }

            return View(trainingAndStudy);
        }

        // GET: TrainingAndStudies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingAndStudies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Date,Dates,Time,SDate,SDates,EDate,EDates,NoOfDays,UserID,Status,QualificationInView,Id,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,TrainingDescription,Yr,Mnt,Day,StationName,Department,GradeLevel,Step,HighestQualification")] TrainingAndStudy trainingAndStudy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingAndStudy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingAndStudy);
        }

        // GET: TrainingAndStudies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingAndStudy = await _context.TrainingAndStudy.FindAsync(id);
            if (trainingAndStudy == null)
            {
                return NotFound();
            }
            return View(trainingAndStudy);
        }

        // POST: TrainingAndStudies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Surname,MiddleName,FirstName,SprpNo,Date,Dates,Time,SDate,SDates,EDate,EDates,NoOfDays,UserID,Status,QualificationInView,Id,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,TrainingDescription,Yr,Mnt,Day,StationName,Department,GradeLevel,Step,HighestQualification")] TrainingAndStudy trainingAndStudy)
        {
            if (id != trainingAndStudy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingAndStudy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingAndStudyExists(trainingAndStudy.Id))
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
            return View(trainingAndStudy);
        }

        // GET: TrainingAndStudies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingAndStudy = await _context.TrainingAndStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingAndStudy == null)
            {
                return NotFound();
            }

            return View(trainingAndStudy);
        }

        // POST: TrainingAndStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingAndStudy = await _context.TrainingAndStudy.FindAsync(id);
            _context.TrainingAndStudy.Remove(trainingAndStudy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingAndStudyExists(int id)
        {
            return _context.TrainingAndStudy.Any(e => e.Id == id);
        }
    }
}
