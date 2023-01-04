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
    public class monthlyreturnsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public monthlyreturnsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: monthlyreturns
        public async Task<IActionResult> Index()
        {
            return View(await _context.monthlyreturn.ToListAsync());
        }

        // GET: monthlyreturns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyreturn = await _context.monthlyreturn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyreturn == null)
            {
                return NotFound();
            }

            return View(monthlyreturn);
        }

        // GET: monthlyreturns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: monthlyreturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfCurrentAppointment,DateDue,DateF,DateD,SprpNo,GradeLevel,StationName,Remark,Dates,Date,Status,Id,Yr,Mnt,Day,YrC,Sex,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark1,Remark2,Remark3,Remark4,UserID,PDepartment,Body,HighestQualification,PhoneNo,EmailID")] monthlyreturn monthlyreturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthlyreturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthlyreturn);
        }

        // GET: monthlyreturns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyreturn = await _context.monthlyreturn.FindAsync(id);
            if (monthlyreturn == null)
            {
                return NotFound();
            }
            return View(monthlyreturn);
        }

        // POST: monthlyreturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfCurrentAppointment,DateDue,DateF,DateD,SprpNo,GradeLevel,StationName,Remark,Dates,Date,Status,Id,Yr,Mnt,Day,YrC,Sex,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark1,Remark2,Remark3,Remark4,UserID,PDepartment,Body,HighestQualification,PhoneNo,EmailID")] monthlyreturn monthlyreturn)
        {
            if (id != monthlyreturn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyreturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!monthlyreturnExists(monthlyreturn.Id))
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
            return View(monthlyreturn);
        }

        // GET: monthlyreturns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyreturn = await _context.monthlyreturn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyreturn == null)
            {
                return NotFound();
            }

            return View(monthlyreturn);
        }

        // POST: monthlyreturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyreturn = await _context.monthlyreturn.FindAsync(id);
            _context.monthlyreturn.Remove(monthlyreturn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool monthlyreturnExists(int id)
        {
            return _context.monthlyreturn.Any(e => e.Id == id);
        }
    }
}
