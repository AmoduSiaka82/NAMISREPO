using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SuperAdmin,ED")]
    public class ExecutiveDirectorController : Controller
    {
      
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        public ExecutiveDirectorController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;

            this.configuration = config;
        }
       
        [NoDirectAccess]
        public IActionResult ShowAll()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {

                var biodatas = (from s in _context.biodata select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.StationName== stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult Promotion()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var biodatas = (from s in _context.biodata where s.ProStatus == "Due" select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.ProStatus == "Due" && s.StationName==stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult Retirement()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var biodatas = (from s in _context.biodata where s.RStatus == "Due" select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.RStatus == "Due" && s.StationName == stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult Training()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var biodatas = (from s in _context.biodata where s.TrainingStatus == "On Training" select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.TrainingStatus == "On Training" && s.StationName==stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]









        public IActionResult Researchers()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var biodatas = (from s in _context.biodata where s.Carder == "Research Officer" select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.Carder == "Research Officer" && s.StationName==stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult NoneResearchers()
        {
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var biodatas = (from s in _context.biodata where s.Carder != "Research Officer" select s);


                return View(biodatas.ToList());
            }
            else
            {
                var biodatas = (from s in _context.biodata where s.Carder != "Research Officer" && s.StationName==stationName select s);


                return View(biodatas.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult ShowIndex(string searchString)
        {

            var biodatas = (from s in _context.biodata where s.SprpNo == searchString select s);
           
            ViewBag.data = biodatas.ToList();
           
            HttpContext.Session.SetString("SPRP", searchString);

            if (biodatas != null)
            {
                return RedirectToAction("Index", "ShowDeatail");
            }
            else
            {
                return RedirectToAction("Index", "ExecutiveDirector");
            }
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


        private void GetStaff()
        {
            List<useraccount> userlist = new List<useraccount>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            userlist = (from category in _context.useraccount where (category.RoleID == "Unit Head" || category.RoleID == "HOD" || category.RoleID == "Director" || category.RoleID == "Zonal Head") orderby category.StaffName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            userlist.Insert(0, new useraccount { UserID = "", StaffName = "---Select---" });

            ViewBag.ListofStaff = userlist;

         
        }
        private void GetUnit()
        {
            List<unit> unitlist = new List<unit>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            unitlist = (from category in _context.unit  orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id=0, UnitName = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------

            ViewBag.ListofUnit = unitlist;
           
        }

        private void GetSection(string Unit)
        {
            List<sections> sectionlist = new List<sections>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            sectionlist = (from category in _context.sections  orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            sectionlist.Insert(0, new sections { Id = 0, SectionName = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------


            ViewBag.ListofSection = sectionlist;
        }
        [NoDirectAccess]
        public IActionResult Index()
        {
            string usId = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Box where s.ReceiverID == usId && s.Status == "Waiting" orderby s.Id descending select s);
            ViewBag.dat = box.ToList();
            int nMeassage = 0;
            foreach (var item in ViewBag.dat)
            {
                nMeassage = nMeassage + 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(nMeassage));
            var biodatas = (from s in _context.biodata  select s);
            
          ViewBag.data = biodatas.ToList();
            decimal total = 0;
            decimal totalR = 0;
            decimal totalNR = 0;
            decimal totalT = 0;
            decimal totalD = 0;
            decimal totalRT = 0;
            foreach (var item in ViewBag.data)
               {
                total = total + 1;
               if (item.Carder== "Research Officer")
               {
                    totalR = totalR + 1;
               }
               else
                {
                   totalNR = totalNR + 1;

                }
              if (item.TrainingStatus == "On Training")
                {
                   totalT = totalT + 1;
                }
                if (item.ProStatus == "Due")
                {
                    totalD = totalD + 1;
                }
               if (item.RStatus == "Due")
               {
                   totalRT= totalRT + 1;
                }
            }
                HttpContext.Session.SetString("Fin", "Ok");
                HttpContext.Session.SetString("Total", Convert.ToString(total));
            HttpContext.Session.SetString("TotalR", Convert.ToString(totalR));
            HttpContext.Session.SetString("TotalNR", Convert.ToString(totalNR));

            HttpContext.Session.SetString("TotalT", Convert.ToString(totalT));
            HttpContext.Session.SetString("TotalD", Convert.ToString(totalD));
            HttpContext.Session.SetString("TotalRT", Convert.ToString(totalRT));
            return View(biodatas.ToList());
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (biodata == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("SPRP", biodata.SprpNo);
            return View(biodata);
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
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            sectionslist = (from category in _context.sections  orderby category.SectionName ascending select category).ToList();
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
            useraccountlist = (from category in _context.useraccount where category.RoleID == "Director" || category.RoleID == "Zonal Head" ||  category.RoleID == "Unit Head" || category.RoleID == "HOD" orderby category.StaffName ascending select category).ToList();
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
            unitlist = (from category in _context.unit  orderby category.UnitName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            unitlist.Insert(0, new unit { Id = 0, UnitName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofUnit = unitlist;
        }
        [NoDirectAccess]
        public async Task<IActionResult> ScheduledIndex()
        {
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // string Sec = HttpContext.Session.GetString("sec");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.createschedule  select s);
            return View(await sch.ToListAsync());
        }
        [NoDirectAccess]
        public IActionResult ScheduledsIndex()
        {
            string staffName = HttpContext.Session.GetString("StaffName");
            string dpt = HttpContext.Session.GetString("Department");
            string unit = HttpContext.Session.GetString("unit");
            // ------- Getting Data from Database Using EntityFrameworkCore -------

            var sch = (from s in _context.scheduled where  s.AllocatedBy == staffName  orderby s.StaffName ascending select s);
            return View(sch.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Scheduleds([Bind("StaffName,Department,Unit,Schedule,UserID,ID,Date,AllocatedBy,ScheduledType,Expire,Status,Role,SectionName,AllocatedUserID,SectionRole,Controllers, Actions,Description")] scheduled schedulede)
        {

           
            string userID = HttpContext.Session.GetString("UserID");
            var stf = _context.useraccount.Where(u => (u.StaffName == schedulede.StaffName)).FirstOrDefault();
            if (stf == null)
            {
                PopulateSectionDropDownList();
                PopulateScheduledDropDownList();
                PopulateDepartmentDropDownList();
                PopulateStaffNameDropDownList();
                PopulateUnitDropDownList();
                ModelState.AddModelError("", "Staff already In our Registered");

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
                PopulateDepartmentDropDownList();
                PopulateStaffNameDropDownList();
                PopulateUnitDropDownList();
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
            //string dpt = HttpContext.Session.GetString("Department");
            //HttpContext.Session.SetString("date", date);
            //HttpContext.Session.SetString("staff", schedulede.StaffName);
            //HttpContext.Session.SetString("role", "Staff");
            //HttpContext.Session.SetString("status", "Active");
            //HttpContext.Session.SetString("userid", stf.UserID);
            //HttpContext.Session.SetString("scheduleType", schedulede.ScheduledType);
            //HttpContext.Session.SetString("expire", schedulede.Expire);
            //HttpContext.Session.SetString("sectionName", schedulede.SectionName);
            //HttpContext.Session.SetString("expire", schedulede.Expire);
            string Rol = "";
            if (HttpContext.Request.Form["sectionRole"].ToString() == "HOD")
            {
                Rol = "HOD";
            }
            else if (HttpContext.Request.Form["sectionRole"].ToString() == "HOD")
            {
                Rol = "Head";
            }
            else if (HttpContext.Request.Form["sectionRole"].ToString() == "Section Head")
            {
                Rol = "Section Head";
            }
            else if (HttpContext.Request.Form["sectionRole"].ToString() == "Zonal Head")
            {
                Rol = "Zonal Head";
            }
            schedulede.Date = DateTime.UtcNow.Date;

            schedulede.Role =Rol;
            schedulede.Schedule = Rol;
                schedulede.AllocatedBy = staffName;
                schedulede.Status = "Active";
                schedulede.UserID = stf.UserID;
            schedulede.AllocatedUserID = userID;
            schedulede.Actions = "";
            schedulede.Controllers = "";
            schedulede.Description = "";
            schedulede.SectionRole = HttpContext.Request.Form["sectionRole"].ToString();
            _context.Add(schedulede);
           await _context.SaveChangesAsync();
            PopulateSectionDropDownList();
            PopulateScheduledDropDownList();
            PopulateDepartmentDropDownList();
            PopulateStaffNameDropDownList();
            PopulateUnitDropDownList();
            return RedirectToAction(nameof(ScheduledsIndex));

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
            PopulateDepartmentDropDownList();
            PopulateStaffNameDropDownList();
            PopulateUnitDropDownList();
            return View();
        }
    }
}
