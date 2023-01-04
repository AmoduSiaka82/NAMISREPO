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
    public class FileDestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public FileDestinationsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

    

        // GET: FileDestinations
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileDestination.ToListAsync());
        }

        // GET: FileDestinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDestination = await _context.FileDestination
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileDestination == null)
            {
                return NotFound();
            }

            return View(fileDestination);
        }

        // GET: FileDestinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileDestinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationName,ID")] FileDestination fileDestination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileDestination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileDestination);
        }

        // GET: FileDestinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDestination = await _context.FileDestination.FindAsync(id);
            if (fileDestination == null)
            {
                return NotFound();
            }
            return View(fileDestination);
        }

        // POST: FileDestinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationName,ID")] FileDestination fileDestination)
        {
            if (id != fileDestination.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileDestination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileDestinationExists(fileDestination.ID))
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
            return View(fileDestination);
        }

        // GET: FileDestinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDestination = await _context.FileDestination
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileDestination == null)
            {
                return NotFound();
            }

            return View(fileDestination);
        }

        // POST: FileDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileDestination = await _context.FileDestination.FindAsync(id);
            _context.FileDestination.Remove(fileDestination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileDestinationExists(int id)
        {
            return _context.FileDestination.Any(e => e.ID == id);
        }
    }
}
