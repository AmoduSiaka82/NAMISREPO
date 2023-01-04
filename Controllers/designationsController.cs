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
    public class designationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public designationsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
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
        // GET: designations
      
        public async Task<IActionResult> Index()
        {
            return View(await _context.designation.ToListAsync());
        }

        // GET: designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.designation
                .FirstOrDefaultAsync(m => m.DesignationID == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: designations/Create
        public IActionResult Create()
        {
           
            
            PopulateDepartmentDropDownList();
            return View();
        }

        // POST: designations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("Decoration,DesignationID,DeptID,Cadre")] designation designation)
        {
           
           
            if (ModelState.IsValid)
            {
                var stf = _context.designation.Where(u => (u.Decoration == designation.Decoration)).FirstOrDefault();
                if (stf != null)
                {
                    PopulateDepartmentDropDownList();

                  
                    ModelState.AddModelError("", "designation already In our Registered");

                    return View();
                }
                _context.Add(designation);
                await _context.SaveChangesAsync();
                PopulateDepartmentDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentDropDownList();
            return View(designation);
        }

        // GET: designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
           
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.designation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            return View(designation);
        }

        // POST: designations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Decoration,DesignationID,DeptID,Cadre")] designation designation)
        {
           
            
            if (id != designation.DesignationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designation);
                    await _context.SaveChangesAsync();
                    PopulateDepartmentDropDownList();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!designationExists(designation.DesignationID))
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
            PopulateDepartmentDropDownList();
            return View(designation);
        }

        // GET: designations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.designation
                .FirstOrDefaultAsync(m => m.DesignationID == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designation = await _context.designation.FindAsync(id);
            var stf = _context.biodata.Where(u => (u.Decoration == designation.Decoration)).FirstOrDefault();
            if (stf != null)
            {

                ModelState.AddModelError("", "Cannot Delete this record, It is in use");

                return View();
            }
         
          
            _context.designation.Remove(designation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool designationExists(int id)
        {
            return _context.designation.Any(e => e.DesignationID == id);
        }
    }
}
