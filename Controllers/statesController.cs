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
    public class statesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public statesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: states
        public async Task<IActionResult> Index()
        {
            return View(await _context.states.ToListAsync());
        }

        // GET: states/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.states
                .FirstOrDefaultAsync(m => m.state_id == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // GET: states/Create
        public IActionResult Create()
        {
            
           
            return View();
        }

        // POST: states/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("state_id,StateOfOrigin,CountryId")] states states)
        {
           
          
            if (ModelState.IsValid)
            {
                var stf = _context.states.Where(u => (u.StateOfOrigin == states.StateOfOrigin)).FirstOrDefault();
                if (stf != null)
                {



                    ModelState.AddModelError("", "State already In our Registered");

                    return View();
                }
                _context.Add(states);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(states);
        }

        // GET: states/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
           
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.states.FindAsync(id);
            if (states == null)
            {
                return NotFound();
            }
            return View(states);
        }

        // POST: states/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("state_id,StateOfOrigin,CountryId")] states states)
        {
         
          
            if (id != states.state_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(states);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var stf = _context.biodata.Where(u => (u.StateOfOrigin == states.StateOfOrigin)).FirstOrDefault();
                        if (stf != null)
                        {

                            stf.StateOfOrigin = states.StateOfOrigin;
                            _context.Entry(stf).State = EntityState.Modified;
                            _context.SaveChanges();
                        }

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!statesExists(states.state_id))
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
            return View(states);
        }

        // GET: states/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var states = await _context.states
                .FirstOrDefaultAsync(m => m.state_id == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // POST: states/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var states = await _context.states.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.StateOfOrigin == states.StateOfOrigin)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
          
            _context.states.Remove(states);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool statesExists(int id)
        {
            return _context.states.Any(e => e.state_id == id);
        }
    }
}
