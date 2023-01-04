using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class VehicleRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public VehicleRecordsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: VehicleRecords
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleRecord.ToListAsync());
        }

        // GET: VehicleRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRecord = await _context.VehicleRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleRecord == null)
            {
                return NotFound();
            }

            return View(vehicleRecord);
        }

        // GET: VehicleRecords/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            
            if (id==0)
            { 

            return View(new VehicleRecord());
             }
            else
            {
                var vehicleRecord = await _context.VehicleRecord.FindAsync(id);
                if (vehicleRecord == null)
                {
                    return NotFound();
                }
                return View(vehicleRecord);
            }
        }

        // POST: VehicleRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleNo,Id,TankCapacity,Make")] VehicleRecord vehicleRecord)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRecord);
        }

        // GET: VehicleRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRecord = await _context.VehicleRecord.FindAsync(id);
            if (vehicleRecord == null)
            {
                return NotFound();
            }
            return View(vehicleRecord);
        }

        // POST: VehicleRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("VehicleNo,Id,TankCapacity,Make")] VehicleRecord vehicleRecord)
        {
          
           
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(vehicleRecord);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(vehicleRecord);
                        await _context.SaveChangesAsync();
                        id = 0;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VehicleRecordExists(vehicleRecord.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                   
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.VehicleRecord.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", vehicleRecord) });
        }

        // GET: VehicleRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRecord = await _context.VehicleRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleRecord == null)
            {
                return NotFound();
            }

            return View(vehicleRecord);
        }

        // POST: VehicleRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRecord = await _context.VehicleRecord.FindAsync(id);
            _context.VehicleRecord.Remove(vehicleRecord);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.VehicleRecord.ToList()) });
        }

        private bool VehicleRecordExists(int id)
        {
            return _context.VehicleRecord.Any(e => e.Id == id);
        }
    }
}
