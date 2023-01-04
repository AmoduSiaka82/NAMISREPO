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
    public class localsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public localsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: locals
        public async Task<IActionResult> Index()
        {
            return View(await _context.locals.ToListAsync());
        }

        // GET: locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.locals
                .FirstOrDefaultAsync(m => m.local_id == id);
            if (locals == null)
            {
                return NotFound();
            }

            return View(locals);
        }

        // GET: locals/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("local_id,state_id,LGAOrigin")] locals locals)
        {
            
            if (ModelState.IsValid)
            {
                var stf = _context.locals.Where(u => (u.LGAOrigin == locals.LGAOrigin)).FirstOrDefault();
                if (stf != null)
                {



                    ModelState.AddModelError("", "LGA already In our Registered");

                    return View();
                }
                _context.Add(locals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locals);
        }

        // GET: locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.locals.FindAsync(id);
            if (locals == null)
            {
                return NotFound();
            }
            return View(locals);
        }

        // POST: locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("local_id,state_id,LGAOrigin")] locals locals)
        {
         
            if (id != locals.local_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locals);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var stf = _context.biodata.Where(u => (u.LGAOrigin == locals.LGAOrigin)).FirstOrDefault();
                        if (stf != null)
                        {

                            stf.LGAOrigin = locals.LGAOrigin;
                            _context.Entry(stf).State = EntityState.Modified;
                            _context.SaveChanges();
                        }

                    }
                    }
                catch (DbUpdateConcurrencyException)
                {
                    if (!localsExists(locals.local_id))
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
            return View(locals);
        }

        // GET: locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.locals
                .FirstOrDefaultAsync(m => m.local_id == id);
            if (locals == null)
            {
                return NotFound();
            }

            return View(locals);
        }

        // POST: locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locals = await _context.locals.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.LGAOrigin == locals.LGAOrigin)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            
            _context.locals.Remove(locals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool localsExists(int id)
        {
            return _context.locals.Any(e => e.local_id == id);
        }
    }
}
