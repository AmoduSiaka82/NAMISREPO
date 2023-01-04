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
    public class itstudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public itstudentsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

       

        // GET: itstudents
        public async Task<IActionResult> Index()
        {
          string userID= HttpContext.Session.GetString("UserID");
            string stationName = HttpContext.Session.GetString("station");
            var bio = (from s in _context.itstudent where s.UserID == userID && s.StationName == stationName && s.Status == "No" select s);

            return View(await bio.ToListAsync());
           
        }

        // GET: itstudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itstudent = await _context.itstudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itstudent == null)
            {
                return NotFound();
            }

            return View(itstudent);
        }

        // GET: itstudents/Create
        public IActionResult Create()
        {
           
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();
            return View();
        }

        // POST: itstudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Date,Dates,Time,SDate,SDates,EDate,EDates,NoOfDays,UserID,Status,QualificationInView,Id,TrainingDescription,Yr,Mnt,Day,EmailID,PhoneNo,School,Contact,HighestQualification,Body,Department,StationName")] itstudent itstudent)
        {
           
            if (ModelState.IsValid)
            {
                //if (itstudent.Surname == string.Empty || itstudent.MiddleName == "" || itstudent.FirstName == "" || itstudent.SprpNo == "")
                //{
                //    ModelState.AddModelError("", "Check Some Enteries Missing");
                //    PopulateDepartmentDropDownList();

                //    PopulateStationDropDownList();
                //    return View();
                //}
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                string formats = "dd/MM/yyyy";
                string format = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string dates = Convert.ToString(CurrentServerTime.ToString(format));
                string date = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                Int32 nYear = CurrentServerTime.Year;
                Int32 nMonth = CurrentServerTime.Month;
                Int32 nDay = CurrentServerTime.Day;
                Int32 noofDay = 0;
                Int32 noofDays = 0;

                string userID = HttpContext.Session.GetString("UserID");
                DateTime SD = Convert.ToDateTime(itstudent.SDate);
                string SDates = Convert.ToString(SD.ToString(format));
                string SDate = Convert.ToString(SD.ToString(formats));
                DateTime eD = Convert.ToDateTime(itstudent.EDate);
                string eDates = Convert.ToString(eD.ToString(format));
                string eDate = Convert.ToString(eD.ToString(formats));
                string Station = HttpContext.Session.GetString("station");
                Int32 sYear = SD.Year;
                Int32 sMonth = SD.Month;
                Int32 sDay = SD.Day;

                Int32 eYear = eD.Year;
                Int32 eMonth = eD.Month;
                Int32 eDay = eD.Day;
                if (sYear<nYear)
                {

                    ModelState.AddModelError("", "Selected Start Year cannot be less than the current Year");
                    PopulateDepartmentDropDownList();

                    PopulateStationDropDownList();
                    return View();
                }
                if (eYear < nYear)
                {
                    ModelState.AddModelError("", "Selected Completion Year cannot be less than the current Year");
                    PopulateDepartmentDropDownList();

                    PopulateStationDropDownList();
                    return View();
                }
                noofDay = (eD - SD).Days;
                noofDays = (SD - CurrentServerTime).Days;
                if (noofDay < 0)
                {
                    ModelState.AddModelError("", "Please Check Date Of Completion must be grater than Start Date");
                    PopulateDepartmentDropDownList();

                    PopulateStationDropDownList();
                    return View();
                }
                itstudent.Date = DateTime.UtcNow.Date ;
                itstudent.Dates = dates;
                itstudent.Time = DateTime.UtcNow.ToLongTimeString();
                itstudent.SDate = itstudent.SDate;
                itstudent.SDates = SDates;
                itstudent.EDate = itstudent.EDate;
                itstudent.EDates = eDates;
                itstudent.Status = "No";
                itstudent.Yr = Convert.ToString(nYear);
                itstudent.Mnt = Convert.ToString(nMonth);
                itstudent.Day = Convert.ToString(nDay);
                itstudent.NoOfDays = Convert.ToString(noofDay);
                itstudent.Id = 0;
                itstudent.UserID = userID;
                _context.Add(itstudent);
                await _context.SaveChangesAsync();
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentDropDownList();
            PopulateStationDropDownList();
            return View(itstudent);
        }

        // GET: itstudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var itstudent = await _context.itstudent.FindAsync(id);
            if (itstudent == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();
            return View(itstudent);
        }

        // POST: itstudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Surname,MiddleName,FirstName,SprpNo,Date,Dates,Time,SDate,SDates,EDate,EDates,NoOfDays,UserID,Status,QualificationInView,Id,TrainingDescription,Yr,Mnt,Day,EmailID,PhoneNo,School,Contact,HighestQualification,Body,Department,StationName")] itstudent itstudent)
        {
          
            if (id != itstudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    string formats = "dd/MM/yyyy";
                    string format = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string dates = Convert.ToString(CurrentServerTime.ToString(format));
                    string date = Convert.ToString(CurrentServerTime.ToString(formats));
                    string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                    Int32 nYear = CurrentServerTime.Year;
                    Int32 nMonth = CurrentServerTime.Month;
                    Int32 nDay = CurrentServerTime.Day;
                    Int32 noofDay = 0;
                    Int32 noofDays = 0;

                    string userID = HttpContext.Session.GetString("UserID");
                    DateTime SD = Convert.ToDateTime(itstudent.SDate);
                    string SDates = Convert.ToString(SD.ToString(format));
                    string SDate = Convert.ToString(SD.ToString(formats));
                    DateTime eD = Convert.ToDateTime(itstudent.EDate);
                    string eDates = Convert.ToString(eD.ToString(format));
                    string eDate = Convert.ToString(eD.ToString(formats));
                    string Station = HttpContext.Session.GetString("station");

                    noofDay = (eD - SD).Days;
                    noofDays = (SD - CurrentServerTime).Days;
                    if (noofDay < 0)
                    {
                        ModelState.AddModelError("", "Please Check Date Of Completion must be grater than Start Date");
                        PopulateDepartmentDropDownList();

                        PopulateStationDropDownList();
                        return View();
                    }
                    itstudent.Date = DateTime.UtcNow.Date;
                    itstudent.Dates = dates;
                    itstudent.Time = DateTime.UtcNow.ToLongTimeString();
                    itstudent.SDate = itstudent.SDate;
                    itstudent.SDates = SDates;
                    itstudent.EDate = itstudent.EDate;
                    itstudent.EDates = eDates;
                    itstudent.Status = "No";
                    itstudent.Yr = Convert.ToString(nYear);
                    itstudent.Mnt = Convert.ToString(nMonth);
                    itstudent.Day = Convert.ToString(nDay);
                    itstudent.NoOfDays = Convert.ToString(noofDay);
                    itstudent.Id = 0;
                    itstudent.UserID = userID;
                    _context.Update(itstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!itstudentExists(itstudent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateDepartmentDropDownList();

                PopulateStationDropDownList();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();
            return View(itstudent);
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
        // GET: itstudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var itstudent = await _context.itstudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itstudent == null)
            {
                return NotFound();
            }

            return View(itstudent);
        }

        // POST: itstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            var itstudent = await _context.itstudent.FindAsync(id);
            if (itstudent.Status == "No")
            {
                _context.itstudent.Remove(itstudent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool itstudentExists(int id)
        {
            return _context.itstudent.Any(e => e.Id == id);
        }
    }
}
