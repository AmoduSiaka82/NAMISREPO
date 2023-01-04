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
    public class StaffPostingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public StaffPostingsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
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
        private void PopulateStationDropDownList()
        {
            List<station> stationlist = new List<station>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            stationlist = (from category in _context.station orderby category.StationName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            stationlist.Insert(0, new station { StationID = 0, StationName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofStation = stationlist;
        }
        // GET: StaffPostings
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffPosting.ToListAsync());
        }

        // GET: StaffPostings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffPosting = await _context.StaffPosting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffPosting == null)
            {
                return NotFound();
            }

            return View(staffPosting);
        }

        // GET: StaffPostings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffPostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfFirstAppointment,DateDue,DateF,DateD,SprpNo,GradeLevel,StationName,Remark,Dates,Date,Status,Id,Yr,Mnt,Day,YrC,Sex,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark1,Remark2,Remark3,Remark4,UserID,PDepartment")] StaffPosting staffPosting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffPosting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffPosting);
        }

        // GET: StaffPostings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffPosting = await _context.StaffPosting.FindAsync(id);
            if (staffPosting == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            PopulateStationDropDownList();
            return View(staffPosting);
        }

        // POST: StaffPostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Surname,MiddleName,FirstName,CurrentAppointment,Department,DateOfFirstAppointment,DateDue,DateF,DateD,SprpNo,GradeLevel,StationName,Remark,Dates,Date,Status,Id,Yr,Mnt,Day,YrC,Sex,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId,Remark1,Remark2,Remark3,Remark4,UserID,PDepartment")] StaffPosting staffPosting)
        {
            if (id != staffPosting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffPosting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffPostingExists(staffPosting.Id))
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
            return View(staffPosting);
        }

        // GET: StaffPostings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffPosting = await _context.StaffPosting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffPosting == null)
            {
                return NotFound();
            }

            return View(staffPosting);
        }

        // POST: StaffPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffPosting = await _context.StaffPosting.FindAsync(id);
            _context.StaffPosting.Remove(staffPosting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffPostingExists(int id)
        {
            return _context.StaffPosting.Any(e => e.Id == id);
        }
    }
}
