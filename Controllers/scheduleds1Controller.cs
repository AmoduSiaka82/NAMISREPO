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
    public class scheduleds1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public scheduleds1Controller(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: scheduleds1
        public async Task<IActionResult> Index()
        {
            return View(await _context.scheduled.ToListAsync());
        }

        // GET: scheduleds1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduled = await _context.scheduled
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scheduled == null)
            {
                return NotFound();
            }

            return View(scheduled);
        }

        // GET: scheduleds1/Create
        public IActionResult Create()
        {
           



           
            PopulateStaffNameDropDownList();
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            return View();
        }

        // POST: scheduleds1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffName,Department,Unit,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role,AllocatedUserID")] scheduled scheduled)
        {
            if (ModelState.IsValid)
            {
             


                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                var stf = _context.useraccount.Where(u => (u.StaffName == scheduled.StaffName)).FirstOrDefault();
                if (stf == null)
                {
                    PopulateScheduledDropDownList();
                    PopulateUnitDropDownList();
                    PopulateStaffNameDropDownList();
                    ModelState.AddModelError("", "SPRP already In our Registered");

                    return View();
                }
                var sc = _context.scheduled.Where(u => (u.UserID == scheduled.UserID && u.Role!="HOD")).FirstOrDefault();
                if (sc != null)
                {
                    PopulateScheduledDropDownList();
                    PopulateUnitDropDownList();
                    PopulateStaffNameDropDownList();
                    ModelState.AddModelError("", "Already created for the staff");

                    return View();
                }
                    string staffName = HttpContext.Session.GetString("StaffName");
                string allocatedID = HttpContext.Session.GetString("UserID");
                string dpt = HttpContext.Session.GetString("Department");
                string Station = HttpContext.Session.GetString("station");
                var sch = _context.scheduled.Where(u => (u.UserID == scheduled.UserID && u.Role == "HOD")).FirstOrDefault();
                if (sch == null)
                {

                    if (Station== "Headqauaters Ilorin")
                    {
                        var sche = _context.useraccount.Where(u => (u.RoleID == "Executive Director")).FirstOrDefault();
                        if (sche != null)
                        {

                            scheduled.Date = DateTime.UtcNow.Date;
                            scheduled.Role = "HOD";
                            scheduled.Department = dpt;
                            scheduled.AllocatedBy = sche.StaffName;
                            scheduled.Status = "Active";
                            scheduled.UserID = allocatedID;
                            scheduled.AllocatedUserID = sche.UserID;
                            _context.Add(scheduled);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        var sche = _context.useraccount.Where(u => (u.RoleID == "Zonal Head" && u.StationName==Station)).FirstOrDefault();
                        if (sche != null)
                        {

                            scheduled.Date = DateTime.UtcNow.Date;
                            scheduled.Role = "HOD";
                            scheduled.Department = dpt;
                            scheduled.AllocatedBy = sche.StaffName;
                            scheduled.Status = "Active";
                            scheduled.UserID = allocatedID;
                            scheduled.AllocatedUserID = sche.UserID;
                            _context.Add(scheduled);
                            await _context.SaveChangesAsync();
                        }
                    }
                    
                   
                }
                scheduled.Date = DateTime.UtcNow.Date;
                scheduled.Role = "Head";
                scheduled.Department = dpt;
                scheduled.AllocatedBy = staffName;
                scheduled.Status = "Active";
                scheduled.UserID = stf.UserID;
                scheduled.AllocatedUserID = allocatedID;
                _context.Add(scheduled);
                await _context.SaveChangesAsync();

                PopulateScheduledDropDownList();
                PopulateUnitDropDownList();
                PopulateStaffNameDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View(scheduled);
        }

        // GET: scheduleds1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           

            
            if (id == null)
            {
                return NotFound();
            }

            var scheduled = await _context.scheduled.FindAsync(id);
            if (scheduled == null)
            {
                return NotFound();
            }
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View(scheduled);
        }
        private void PopulateStaffNameDropDownList()
        {
            List<useraccount> useraccountlist = new List<useraccount>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            useraccountlist = (from category in _context.useraccount where category.Department == dpt && category.RoleID == "Unit Head" orderby category.StaffName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            useraccountlist.Insert(0, new useraccount { UserID = "", StaffName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUseraccount = useraccountlist;
        }
        private void PopulateScheduledDropDownList()
        {
            List<createschedule> scheduledlist = new List<createschedule>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            scheduledlist = (from category in _context.createschedule where category.Department == dpt && category.ForWho == "Head" orderby category.Department ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            scheduledlist.Insert(0, new createschedule { Id = 0, ScheduledName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofScheduled = scheduledlist;
        }
        private void PopulateUnitDropDownList()
        {
            List<unit> unitlist = new List<unit>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            unitlist = (from category in _context.unit where category.Department == dpt orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id = 0, UnitName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUnit = unitlist;
        }
        // POST: scheduleds1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffName,Department,Unit,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role")] scheduled scheduled)
        {
          

            string formats = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string format = "dd/MM/yyyy";
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            Int32 Yr = CurrentServerTime.Year;
            string date = Convert.ToString(CurrentServerTime.ToString(format));
            string dates = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            if (id != scheduled.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stf = _context.useraccount.Where(u => (u.StaffName == scheduled.StaffName)).FirstOrDefault();
                    if (stf == null)
                    {
                        PopulateScheduledDropDownList();
                        PopulateUnitDropDownList();
                        PopulateStaffNameDropDownList();
                        ModelState.AddModelError("", "SPRP already In our Registered");

                        return View();
                    }
                    string staffName = HttpContext.Session.GetString("StaffName");
                    string dpt = HttpContext.Session.GetString("Department");
                    scheduled.Date = DateTime.UtcNow.Date;
                    scheduled.Role = "Head";
                    scheduled.Department = dpt;
                    scheduled.AllocatedBy = staffName;
                    scheduled.Status = "Active";
                    scheduled.UserID = stf.UserID;
                    _context.Update(scheduled);
                    await _context.SaveChangesAsync();
                    PopulateScheduledDropDownList();
                    PopulateUnitDropDownList();
                    PopulateStaffNameDropDownList();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!scheduledExists(scheduled.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateScheduledDropDownList();
                PopulateUnitDropDownList();
                PopulateStaffNameDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View(scheduled);
        }

        // GET: scheduleds1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduled = await _context.scheduled
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scheduled == null)
            {
                return NotFound();
            }

            return View(scheduled);
        }

        // POST: scheduleds1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduled = await _context.scheduled.FindAsync(id);
            _context.scheduled.Remove(scheduled);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool scheduledExists(int id)
        {
            return _context.scheduled.Any(e => e.ID == id);
        }
    }
}
