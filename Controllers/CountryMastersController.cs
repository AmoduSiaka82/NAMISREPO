using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class CountryMastersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public CountryMastersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
       

        // GET: CountryMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountryMaster.ToListAsync());
        }

        // GET: CountryMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            return View(countryMaster);
        }

        // GET: CountryMasters/Create
        public IActionResult Create()
        {
          
          
            return View();
        }

        // POST: CountryMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public IActionResult Create([FromForm] CountryMaster countryMaster)
        {
           
           
            if (ModelState.IsValid)
            {

                countryMaster.Natinality = countryMaster.Natinality;
                countryMaster.CountryCode = countryMaster.CountryCode;
                _context.Add(countryMaster);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(countryMaster);
        }

        // GET: CountryMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
           
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMaster.FindAsync(id);
            if (countryMaster == null)
            {
                return NotFound();
            }
            return View(countryMaster);
        }

        // POST: CountryMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Natinality,CountryCode")] CountryMaster countryMaster)
        {
           
           
            if (id != countryMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryMaster);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var stf = _context.biodata.Where(u => (u.Natinality == countryMaster.Natinality)).FirstOrDefault();
                        if (stf != null)
                        {

                            stf.Natinality = countryMaster.Natinality;
                            _context.Entry(stf).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryMasterExists(countryMaster.ID))
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
            return View(countryMaster);
        }

        // GET: CountryMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            return View(countryMaster);
        }

        // POST: CountryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryMaster = await _context.CountryMaster.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.Natinality == countryMaster.Natinality)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            
            _context.CountryMaster.Remove(countryMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryMasterExists(int id)
        {
            return _context.CountryMaster.Any(e => e.ID == id);
        }
    }
}
