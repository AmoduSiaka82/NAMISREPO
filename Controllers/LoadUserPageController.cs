using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class LoadUserPageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public LoadUserPageController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            string userID = HttpContext.Session.GetString("UserID");

            var box = (from s in _context.Box where s.UserID == userID && (s.Status == "Approved" || s.Status == "Read") && s.UserStatus == "Waiting" orderby s.Id select s);
            ViewBag.dat = box.ToList();
            int nMeassage = 0;
            foreach (var item in ViewBag.dat)
            {
                nMeassage = nMeassage + 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(nMeassage));
            var sch = (from s in _context.scheduled where s.UserID == userID select s);
            var usr = _context.scheduled.Where(u => (u.UserID == userID && u.SectionRole == "Section Head")).FirstOrDefault();
            if (usr != null)
            {
                
                HttpContext.Session.SetString("sectionName", usr.SectionName);
                HttpContext.Session.SetString("section", "Section Head");
                HttpContext.Session.SetString("unit",usr.Unit);
            }
            else
            {
                //HttpContext.Session.SetString("sectionName", usr.SectionName);
                HttpContext.Session.SetString("section", "Section Member");
                //HttpContext.Session.SetString("unit", usr.Unit);
            }
              
                return View(await _context.LoadUserPage.ToListAsync());
            
        }
        private void PopulateScheduledDropDownList()
        {
            List<createschedule> scheduledlist = new List<createschedule>();
            string dpt = HttpContext.Session.GetString("Department");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            scheduledlist = (from category in _context.createschedule where category.Department == dpt && category.ForWho == "Staff" orderby category.Department ascending select category).ToList();
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
            string section = HttpContext.Session.GetString("sectionName");
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            sectionslist = (from category in _context.sections where category.Department == dpt && category.UnitName == unit && category.SectionName==section orderby category.SectionName ascending select category).ToList();
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
            useraccountlist = (from category in _context.useraccount where category.Department == dpt && category.RoleID == "Staff" orderby category.StaffName ascending select category).ToList();
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
            unitlist = (from category in _context.unit where category.Department == dpt orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id = 0, UnitName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUnit = unitlist;
        }
        [NoDirectAccess]
        public IActionResult ScheduledIndex()
        {
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
           // string Sec = HttpContext.Session.GetString("sec");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.createschedule where s.Department == dpt && s.ForWho == "Staff" && s.Unit == unit select s);
            return View( sch.ToList());
        }
        [NoDirectAccess]
        public IActionResult ScheduledsIndex()
        {
            string staffName = HttpContext.Session.GetString("StaffName");
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.scheduled where s.Department == dpt && s.AllocatedBy == staffName && s.Unit == unit orderby s.StaffName ascending select s);
            return View(sch.ToList());
        }
        [HttpPost]
        public IActionResult Scheduleds([Bind("StaffName,Department,Unit,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role,SectionName")] scheduled scheduled)
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
            HttpContext.Session.SetString("sectionRoles", "Section Member");



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
            return RedirectToAction(nameof(ScheduledIndex));

            //PopulateSectionDropDownList();
            //PopulateScheduledDropDownList();
            //PopulateUnitDropDownList();
            //PopulateStaffNameDropDownList();
            //return View(scheduled);
        }
        [NoDirectAccess]
        public IActionResult Scheduleds()
        {



            PopulateSectionDropDownList();
            PopulateScheduledDropDownList();
            PopulateUnitDropDownList();
            PopulateStaffNameDropDownList();
            return View();
        }
    }
}
