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
    public class unitsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public unitsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        private void PopulateDepartmentDropDownList()
        {
            List<department> departmentlist = new List<department>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            departmentlist = (from category in _context.department orderby category.Department ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            departmentlist.Insert(0, new department { DeptID = 0, Department = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofDept = departmentlist;
        }
        // GET: units
        public async Task<IActionResult> Index()
        {
            return View(await _context.unit.ToListAsync());
        }

        // GET: units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.unit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: units/Create
        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        // POST: units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitName,Department,Id")] unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unit);
                await _context.SaveChangesAsync();
                PopulateDepartmentDropDownList();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            var unit = await _context.unit.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitName,Department,Id")] unit unit)
        {
            if (id != unit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                   int i= await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                       

                        var sto = _context.useraccount.Where(u => (u.Unit == unit.UnitName)).FirstOrDefault();
                        if (sto != null)
                        {
                            sto.Unit = unit.UnitName;
                            _context.Entry(sto).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                        var sc = _context.scheduled.Where(u => (u.Unit == unit.UnitName)).FirstOrDefault();
                        if (sc != null)
                        {
                            sc.Unit = unit.UnitName;
                            _context.Entry(sc).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!unitExists(unit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateDepartmentDropDownList();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.unit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.unit.FindAsync(id);
            var stf = _context.useraccount.Where(u => (u.Unit == unit.UnitName)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }

            
            _context.unit.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool unitExists(int id)
        {
            return _context.unit.Any(e => e.Id == id);
        }
    }
}
