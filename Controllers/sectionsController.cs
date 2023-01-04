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
    public class sectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public sectionsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        // GET: sections
        public async Task<IActionResult> Index()
        {
            return View(await _context.sections.ToListAsync());
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
        // GET: sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.sections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // GET: sections/Create
        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            PopulateUnitDropDownList();
            return View();
        }

        // POST: sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Department,UnitName,SectionName,Id")] sections sections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sections);
                await _context.SaveChangesAsync();
                PopulateDepartmentDropDownList();
                PopulateUnitDropDownList();
                return RedirectToAction(nameof(Index));
            }
            return View(sections);
        }

        // GET: sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.sections.FindAsync(id);
            if (sections == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            PopulateUnitDropDownList();
            return View(sections);
        }

        // POST: sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Department,UnitName,SectionName,Id")] sections sections)
        {
            if (id != sections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sections);
                   int i= await _context.SaveChangesAsync();
                    if (i > 0)
                    {


                        var sto = _context.scheduled.Where(u => (u.SectionName == sections.SectionName)).FirstOrDefault();
                        if (sto != null)
                        {
                            sto.SectionName = sections.SectionName;
                            _context.Entry(sto).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sectionsExists(sections.Id))
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
            return View(sections);
        }

        // GET: sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.sections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // POST: sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sections = await _context.sections.FindAsync(id);
            _context.sections.Remove(sections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sectionsExists(int id)
        {
            return _context.sections.Any(e => e.Id == id);
        }
    }
}
