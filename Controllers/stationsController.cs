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
    public class stationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public stationsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: stations
        public async Task<IActionResult> Index()
        {
            return View(await _context.station.ToListAsync());
        }

        // GET: stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.station
                .FirstOrDefaultAsync(m => m.StationID == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: stations/Create
        public IActionResult Create()
        {
           
           
            return View();
        }

        // POST: stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationName,StationID")] station station)
        {
            
           
            if (ModelState.IsValid)
            {
                var stf = _context.station.Where(u => (u.StationName == station.StationName)).FirstOrDefault();
                if (stf != null)
                {



                    ModelState.AddModelError("", "Station already In our Registered");

                    return View();
                }
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
         
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.station.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StationName,StationID")] station station)
        {
           
            
            if (id != station.StationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var stf = _context.biodata.Where(u => (u.StationName == station.StationName)).FirstOrDefault();
                        if (stf != null)
                        {

                            stf.StationName = station.StationName;
                            _context.Entry(stf).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                     
                        var sto = _context.useraccount.Where(u => (u.StationName == station.StationName)).FirstOrDefault();
                        if (sto != null)
                        {
                            sto.StationName = station.StationName;
                            _context.Entry(sto).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!stationExists(station.StationID))
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
            return View(station);
        }

        // GET: stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.station
                .FirstOrDefaultAsync(m => m.StationID == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var station = await _context.station.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.StationName == station.StationName)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
          
            var sto = _context.useraccount.Where(u => (u.StationName == station.StationName)).FirstOrDefault();
            if (sto != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            _context.station.Remove(station);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool stationExists(int id)
        {
            return _context.station.Any(e => e.StationID == id);
        }
    }
}
