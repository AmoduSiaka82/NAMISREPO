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
    public class reportuploadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public reportuploadsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: reportuploads
        public async Task<IActionResult> Index()
        {
            return View(await _context.reportupload.ToListAsync());
        }

        // GET: reportuploads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportupload = await _context.reportupload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportupload == null)
            {
                return NotFound();
            }

            return View(reportupload);
        }

        // GET: reportuploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: reportuploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportFile,RId,Id")] reportupload reportupload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportupload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportupload);
        }

        // GET: reportuploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportupload = await _context.reportupload.FindAsync(id);
            if (reportupload == null)
            {
                return NotFound();
            }
            return View(reportupload);
        }

        // POST: reportuploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportFile,RId,Id")] reportupload reportupload)
        {
            if (id != reportupload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportupload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reportuploadExists(reportupload.Id))
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
            return View(reportupload);
        }

        // GET: reportuploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportupload = await _context.reportupload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportupload == null)
            {
                return NotFound();
            }

            return View(reportupload);
        }

        // POST: reportuploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportupload = await _context.reportupload.FindAsync(id);
            _context.reportupload.Remove(reportupload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reportuploadExists(int id)
        {
            return _context.reportupload.Any(e => e.Id == id);
        }
    }
}
