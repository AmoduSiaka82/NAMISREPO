using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class ConfirmationofappointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public ConfirmationofappointmentsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
       

        // GET: Confirmationofappointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Confirmationofappointment.ToListAsync());
        }

        // GET: Confirmationofappointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationofappointment = await _context.Confirmationofappointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmationofappointment == null)
            {
                return NotFound();
            }

            return View(confirmationofappointment);
        }

        // GET: Confirmationofappointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confirmationofappointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfFirstAppointment,DateDue,DateF,DateD,SprpNo,GradeLevel,StationName,Remark,Dates,Date,Status,Id,Yr,Mnt,Day,YrC,Sex,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark1,Remark2,Remark3,Remark4,UserID")] Confirmationofappointment confirmationofappointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confirmationofappointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confirmationofappointment);
        }

        // GET: Confirmationofappointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationofappointment = await _context.Confirmationofappointment.FindAsync(id);
            if (confirmationofappointment == null)
            {
                return NotFound();
            }
            return View(confirmationofappointment);
        }

        // POST: Confirmationofappointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfFirstAppointment,DateDue,SprpNo,GradeLevel,StationName,Remark,Id")] Confirmationofappointment confirmationofappointment)
        {
            if (id != confirmationofappointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confirmationofappointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfirmationofappointmentExists(confirmationofappointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UsersController.ConfirmationList));
            }
            return View(confirmationofappointment);
        }

        // GET: Confirmationofappointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationofappointment = await _context.Confirmationofappointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmationofappointment == null)
            {
                return NotFound();
            }

            return View(confirmationofappointment);
        }

        // POST: Confirmationofappointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confirmationofappointment = await _context.Confirmationofappointment.FindAsync(id);
            _context.Confirmationofappointment.Remove(confirmationofappointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfirmationofappointmentExists(int id)
        {
            return _context.Confirmationofappointment.Any(e => e.Id == id);
        }
    }
}
