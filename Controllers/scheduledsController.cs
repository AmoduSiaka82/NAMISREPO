using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;


namespace NAMIS.Controllers
{
    public class scheduledsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public scheduledsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: scheduleds
        public async Task<IActionResult> Index()
        {
            string staffName = HttpContext.Session.GetString("StaffName");
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.scheduled where s.Department == dpt && s.AllocatedBy == staffName && s.Unit == unit orderby s.StaffName ascending select s);
            return View(await sch.ToListAsync());
        }
        public async Task<IActionResult> ScheduleIndex()
        {
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.createschedule where s.Department == dpt && s.ForWho == "Staff" && s.Unit == unit select s);
            return View(await sch.ToListAsync());
        }
        // GET: scheduleds/Details/5
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
        
         
        // GET: scheduleds/Create
        public IActionResult Create()
        {
        


            PopulateSectionDropDownList();
             PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View();
        }
       
            [HttpPost]
        public JsonResult RemoveSchedule(int id)
        {

            
            scheduled tbl_scheduled = new scheduled
            {
                ID = id
                
            };

            var scheduled = _context.scheduled.Find(tbl_scheduled.ID);
            _context.scheduled.Remove(scheduled);
            _context.SaveChanges();

            return Json(tbl_scheduled);
        }
        [HttpPost]
        public JsonResult InsertSchedule(string schedulednames, string controllers, string actions, string description)
        {

            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            string staffName = HttpContext.Session.GetString("StaffName");
            DateTime date = Convert.ToDateTime(HttpContext.Session.GetString("date"));
            string staff = HttpContext.Session.GetString("staff");
            string userid = HttpContext.Session.GetString("userid");
            string scheduleType = HttpContext.Session.GetString("scheduleType");
            DateTime expire = Convert.ToDateTime(HttpContext.Session.GetString("expire"));
            string sectionRoles = HttpContext.Session.GetString("sectionRoles");
            string sectionName = HttpContext.Session.GetString("sectionName");
           
            string allocatedID = HttpContext.Session.GetString("UserID");
            scheduled tbl_scheduled = new scheduled
            {
                Schedule = schedulednames.Trim(),
                Controllers = controllers.Trim(),
                Actions = actions.Trim(),
                Description = description.Trim(),
                Department = dpt,
                Unit = unit,
                AllocatedBy = staffName,
                Date = date,
                StaffName = staff,
                Role = "Staff",
                Status = "Active",
                UserID = userid,
                ScheduledType = scheduleType,
                Expire = expire,
                SectionRole = sectionRoles,
                SectionName = sectionName,
                AllocatedUserID = allocatedID
            };
            var usr = _context.scheduled.Where(u => u.UserID == tbl_scheduled.UserID && u.Schedule == tbl_scheduled.Schedule).FirstOrDefault();
            if (usr == null)
            {
                DALClass sign = new DALClass(configuration);

                sign.NewScheduled(tbl_scheduled.StaffName, tbl_scheduled.Department, tbl_scheduled.Unit, tbl_scheduled.Schedule, tbl_scheduled.UserID, tbl_scheduled.ID, tbl_scheduled.Date, tbl_scheduled.AllocatedBy, tbl_scheduled.ScheduledType, tbl_scheduled.Expire, tbl_scheduled.Status, tbl_scheduled.Role, tbl_scheduled.SectionName, tbl_scheduled.Controllers, tbl_scheduled.Actions, tbl_scheduled.Description, tbl_scheduled.SectionRole, tbl_scheduled.AllocatedUserID);
            }          
            return Json(tbl_scheduled);





        }
        // POST: scheduleds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StaffName,Department,Unit,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role,SectionName")] scheduled scheduled)
        {
            
               
                //string unit = HttpContext.Session.GetString("UserID");
                var stf = _context.useraccount.Where(u => (u.StaffName == scheduled.StaffName)).FirstOrDefault();
                if (stf == null)
                {
                    PopulateSectionDropDownList();
                    PopulateScheduledDropDownList();
                    PopulateUnitDropDownList();
                    PopulateStaffNameDropDownList();
                    ModelState.AddModelError("", "SPRP already In our Registered");

                    return View();
                }
            //var stfUnit = _context.scheduled.Where(u => (u.Unit == unit)).FirstOrDefault();
            //if (stfUnit == null)
            //{
            //    PopulateSectionDropDownList();
            //    PopulateScheduledDropDownList();
            //    PopulateUnitDropDownList();
            //    PopulateStaffNameDropDownList();
            //    ModelState.AddModelError("", "Not allocated unit In our Registered");

            //    return View();
            //}
            if (HttpContext.Request.Form["sectionRole"].ToString() == "")
            {
                PopulateSectionDropDownList();
                PopulateScheduledDropDownList();
                PopulateUnitDropDownList();
                PopulateStaffNameDropDownList();
                ModelState.AddModelError("", "Please Select Create As");
                return View();
            }
            if (HttpContext.Request.Form["sectionRole"].ToString() != "")
            {
                HttpContext.Session.SetString("sectionRoles", HttpContext.Request.Form["sectionRole"].ToString());
            }
                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            string staffName = HttpContext.Session.GetString("StaffName");
            string dpt = HttpContext.Session.GetString("Department");
            HttpContext.Session.SetString("date", date);
            HttpContext.Session.SetString("staff", scheduled.StaffName);
            HttpContext.Session.SetString("role", "Staff");
            HttpContext.Session.SetString("status", "Active");
            HttpContext.Session.SetString("userid", stf.UserID);
            HttpContext.Session.SetString("scheduleType", scheduled.ScheduledType);
            HttpContext.Session.SetString("expire", Convert.ToString(scheduled.Expire));
            HttpContext.Session.SetString("sectionName", scheduled.SectionName);
            HttpContext.Session.SetString("expire", Convert.ToString(scheduled.Expire));

            HttpContext.Session.SetString("sectionRoles", HttpContext.Request.Form["sectionRole"].ToString());
            //scheduled.Date = date;
            //    scheduled.Role = "Staff";
            //    scheduled.Department = dpt;
            //    scheduled.AllocatedBy = staffName;
            //    scheduled.Status = "Active";
            //    scheduled.UserID = stf.UserID;
            //scheduled.Unit = stfUnit.Unit;
            //_context.Add(scheduled);
            //await _context.SaveChangesAsync();
            PopulateSectionDropDownList();
                PopulateScheduledDropDownList();
                PopulateUnitDropDownList();
                PopulateStaffNameDropDownList();
                return RedirectToAction(nameof(ScheduleIndex));
            
            //PopulateSectionDropDownList();
            //PopulateScheduledDropDownList();
            //PopulateUnitDropDownList();
            //PopulateStaffNameDropDownList();
            //return View(scheduled);
        }

        // GET: scheduleds/Edit/5
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
            PopulateSectionDropDownList();
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View(scheduled);
        }
        private void PopulateScheduledDropDownList()
        {
            List<createschedule> scheduledlist = new List<createschedule>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            scheduledlist = (from category in _context.createschedule where category.Department == dpt && category.ForWho=="Staff" orderby category.Department ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            scheduledlist.Insert(0, new createschedule { Id = 0, ScheduledName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofScheduled = scheduledlist;
        }
        private void PopulateSectionDropDownList()
        {
            List<sections> sectionslist = new List<sections>();
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            sectionslist = (from category in _context.sections where category.Department == dpt && category.UnitName == unit orderby category.SectionName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            sectionslist.Insert(0, new sections { Id = 0, SectionName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofSections = sectionslist;
        }
        private void PopulateStaffNameDropDownList()
        {
            List<useraccount> useraccountlist = new List<useraccount>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            useraccountlist = (from category in _context.useraccount where category.Department == dpt && category.RoleID=="Staff" orderby category.StaffName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            useraccountlist.Insert(0, new useraccount { UserID = "", StaffName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUseraccount = useraccountlist;
        }
        // PO
        private void PopulateUnitDropDownList()
        {
            List<unit> unitlist = new List<unit>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            unitlist = (from category in _context.unit where category.Department==dpt orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id = 0, UnitName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUnit = unitlist;
        }
        // POST: scheduleds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffName,Department,SectionName,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role")] scheduled scheduled)
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
                        PopulateSectionDropDownList();
                        PopulateScheduledDropDownList();
                        PopulateUnitDropDownList();
                        PopulateStaffNameDropDownList();
                        ModelState.AddModelError("", "SPRP already In our Registered");

                        return View();
                    }
                    string staffName = HttpContext.Session.GetString("StaffName");
                    string dpt = HttpContext.Session.GetString("Department");
                    scheduled.Date = DateTime.UtcNow.Date;
                    scheduled.Role = "Staff";
                    scheduled.Department = dpt;
                    scheduled.AllocatedBy = staffName;
                    scheduled.Status = "Active";
                    scheduled.UserID = stf.UserID;
                    _context.Update(scheduled);
                    await _context.SaveChangesAsync();
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
                PopulateSectionDropDownList();
                PopulateScheduledDropDownList();
                PopulateUnitDropDownList();
                PopulateStaffNameDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateSectionDropDownList();
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View(scheduled);
        }

        // GET: scheduleds/Delete/5
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

        // POST: scheduleds/Delete/5
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
