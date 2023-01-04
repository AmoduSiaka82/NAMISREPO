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
    public class createschedulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public createschedulesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

       

        // GET: createschedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.createschedule.ToListAsync());
        }

        // GET: createschedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createschedule = await _context.createschedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (createschedule == null)
            {
                return NotFound();
            }

            return View(createschedule);
        }

        // GET: createschedules/Create
        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            PopulateUnitDropDownList();
            return View();
        }

        // POST: createschedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduledName,Id,Department,Unit,ForWho,Controllers,Actions,Description")] createschedule createschedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createschedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentDropDownList();
            PopulateUnitDropDownList();
            return View(createschedule);
        }

        // GET: createschedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createschedule = await _context.createschedule.FindAsync(id);
            if (createschedule == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            PopulateUnitDropDownList();
            return View(createschedule);
        }

        // POST: createschedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduledName,Id,Department,Unit,ForWho,Controllers,Actions,Description")] createschedule createschedule)
        {
            if (id != createschedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(createschedule);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                       

                        var sto = _context.scheduled.Where(u => (u.Schedule == createschedule.ScheduledName)).FirstOrDefault();
                        if (sto != null)
                        {
                            sto.Schedule = createschedule.ScheduledName;
                            sto.Controllers = createschedule.Controllers;
                            sto.Actions = createschedule.Actions;
                            sto.Description = createschedule.Description;
                            _context.Entry(sto).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!createscheduleExists(createschedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateDepartmentDropDownList();
                PopulateUnitDropDownList();
                return RedirectToAction(nameof(Index));
            }
            return View(createschedule);
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
        private void PopulateUnitDropDownList()
        {
            List<unit> unitlist = new List<unit>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            unitlist = (from category in _context.unit orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id = 0, UnitName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUnit = unitlist;
        }
        // GET: createschedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createschedule = await _context.createschedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (createschedule == null)
            {
                return NotFound();
            }

            return View(createschedule);
        }

        // POST: createschedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var createschedule = await _context.createschedule.FindAsync(id);
            var sto = _context.scheduled.Where(u => (u.Schedule == createschedule.ScheduledName)).FirstOrDefault();
            if (sto != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            _context.createschedule.Remove(createschedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool createscheduleExists(int id)
        {
            return _context.createschedule.Any(e => e.Id == id);
        }
    }
}
