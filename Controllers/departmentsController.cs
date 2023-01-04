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
    public class departmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public departmentsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        

        // GET: departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.department.ToListAsync());
        }

        // GET: departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.department
                .FirstOrDefaultAsync(m => m.DeptID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: departments/Create
        public IActionResult Create()
        {
         
           
            return View();
        }

        // POST: departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptID,Department")] department departments)
        {
           
            if (ModelState.IsValid)
            {
                var stf = _context.department.Where(u => (u.Department == departments.Department)).FirstOrDefault();
                if (stf != null)
                {
                    


                    ModelState.AddModelError("", "department already In our Registered");

                    return View();
                }
                _context.Add(departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }

        // GET: departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
           
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptID,Department")] department departments)
        {
          
          
            if (id != departments.DeptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(departments);
                   int i= await _context.SaveChangesAsync();
                    if (i>0)
                    {
                        var stf = _context.biodata.Where(u => (u.Department == departments.Department)).FirstOrDefault();
                        if (stf != null)
                        {

                            stf.Department = departments.Department;
                            _context.Entry(stf).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        var std = _context.designation.Where(u => (u.DeptID == departments.Department)).FirstOrDefault();
                        if (std != null)
                        {

                            std.DeptID = departments.Department;
                            _context.Entry(std).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        var sto = _context.useraccount.Where(u => (u.Department == departments.Department)).FirstOrDefault();
                        if (sto != null)
                        {
                            sto.Department = departments.Department;
                            _context.Entry(sto).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departmentExists(departments.DeptID))
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
            return View(departments);
        }

        // GET: departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.department
                .FirstOrDefaultAsync(m => m.DeptID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var department = await _context.department.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.Department == department.Department)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            var std = _context.designation.Where(u => (u.DeptID == department.Department)).FirstOrDefault();
            if (std != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            var sto = _context.useraccount.Where(u => (u.Department == department.Department)).FirstOrDefault();
            if (sto != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
            _context.department.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departmentExists(int id)
        {
            return _context.department.Any(e => e.DeptID == id);
        }
    }
}
