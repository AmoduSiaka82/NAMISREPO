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
    public class PersonelFilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public PersonelFilesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: PersonelFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonelFile.ToListAsync());
        }

        // GET: PersonelFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelFile = await _context.PersonelFile
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelFile == null)
            {
                return NotFound();
            }

            return View(personelFile);
        }

        // GET: PersonelFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonelFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FistName,SprpNo,Date,Dates,Time,ExpDate,ExpDates,UserID,Status,DestinationName,ID,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark")] PersonelFile personelFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personelFile);
        }

        // GET: PersonelFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelFile = await _context.PersonelFile.FindAsync(id);
            if (personelFile == null)
            {
                return NotFound();
            }
            return View(personelFile);
        }

        // POST: PersonelFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Surname,MiddleName,FistName,SprpNo,Date,Dates,Time,ExpDate,ExpDates,UserID,Status,DestinationName,ID,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark")] PersonelFile personelFile)
        {
            if (id != personelFile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelFileExists(personelFile.ID))
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
            return View(personelFile);
        }

        // GET: PersonelFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelFile = await _context.PersonelFile
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelFile == null)
            {
                return NotFound();
            }

            return View(personelFile);
        }

        // POST: PersonelFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personelFile = await _context.PersonelFile.FindAsync(id);
            _context.PersonelFile.Remove(personelFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelFileExists(int id)
        {
            return _context.PersonelFile.Any(e => e.ID == id);
        }
    }
}
