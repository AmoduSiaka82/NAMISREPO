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
    public class retirementbiodatasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public retirementbiodatasController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: retirementbiodatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.retirementbiodata.ToListAsync());
        }

        // GET: retirementbiodatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirementbiodata = await _context.retirementbiodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (retirementbiodata == null)
            {
                return NotFound();
            }

            return View(retirementbiodata);
        }

        // GET: retirementbiodatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: retirementbiodatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Decoration,Natinality,DateOfFirstAppointment,DateOfFirstArrival,LGAOrigin,DateOfBirth,PlaceOfBirth,CheckBy,Proof,Date,Dates,Time,Status,HomeAddress,Department,GeographicalLocation,SubstansiveAppointment,DateOfAppointment,TermsOfEngagement,CurrentAppointment,StateOfOrigin,DateOfCurrentAppointment,StationName,Carder,EdNote,HodNote,UnitNote,HighestQualification,GradeLevel,Step,TrainingStatus,QualificationInView,ProStatus,RStatus,ProYr,RYr,AppointmentStatus,ConfirmationDate,ConfirmationYr,DateOfRetirement,IPPISNO,DateOfPromotion,NHISNO,PhoneNo,EmailID,NHFNO")] retirementbiodata retirementbiodata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retirementbiodata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retirementbiodata);
        }

        // GET: retirementbiodatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirementbiodata = await _context.retirementbiodata.FindAsync(id);
            if (retirementbiodata == null)
            {
                return NotFound();
            }
            return View(retirementbiodata);
        }

        // POST: retirementbiodatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Decoration,Natinality,DateOfFirstAppointment,DateOfFirstArrival,LGAOrigin,DateOfBirth,PlaceOfBirth,CheckBy,Proof,Date,Dates,Time,Status,HomeAddress,Department,GeographicalLocation,SubstansiveAppointment,DateOfAppointment,TermsOfEngagement,CurrentAppointment,StateOfOrigin,DateOfCurrentAppointment,StationName,Carder,EdNote,HodNote,UnitNote,HighestQualification,GradeLevel,Step,TrainingStatus,QualificationInView,ProStatus,RStatus,ProYr,RYr,AppointmentStatus,ConfirmationDate,ConfirmationYr,DateOfRetirement,IPPISNO,DateOfPromotion,NHISNO,PhoneNo,EmailID,NHFNO")] retirementbiodata retirementbiodata)
        {
            if (id != retirementbiodata.SprpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retirementbiodata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!retirementbiodataExists(retirementbiodata.SprpNo))
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
            return View(retirementbiodata);
        }

        // GET: retirementbiodatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirementbiodata = await _context.retirementbiodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (retirementbiodata == null)
            {
                return NotFound();
            }

            return View(retirementbiodata);
        }

        // POST: retirementbiodatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var retirementbiodata = await _context.retirementbiodata.FindAsync(id);
            _context.retirementbiodata.Remove(retirementbiodata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool retirementbiodataExists(string id)
        {
            return _context.retirementbiodata.Any(e => e.SprpNo == id);
        }
    }
}
