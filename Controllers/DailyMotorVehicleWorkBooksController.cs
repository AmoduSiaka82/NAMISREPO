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
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class DailyMotorVehicleWorkBooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public DailyMotorVehicleWorkBooksController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        

        // GET: DailyMotorVehicleWorkBooks
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            string stationName = HttpContext.Session.GetString("station");
            string userID = HttpContext.Session.GetString("UserID");
            var Daily = (from s in _context.DailyMotorVehicleWorkBook where s.UserID ==userID && s.Status=="No" && s.StationName==stationName select s);
            return View(await Daily.ToListAsync());
            
        }

        // GET: DailyMotorVehicleWorkBooks/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMotorVehicleWorkBook = await _context.DailyMotorVehicleWorkBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyMotorVehicleWorkBook == null)
            {
                return NotFound();
            }

            return View(dailyMotorVehicleWorkBook);
        }

        // GET: DailyMotorVehicleWorkBooks/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            
            if (id == 0)
            {
                PopulateVehicleDropDownList();
                PopulateTankCapacityDropDownList();
                PopulateMakeDropDownList();

                return View(new DailyMotorVehicleWorkBook());
            }
            else
            {
                PopulateVehicleDropDownList();
                PopulateTankCapacityDropDownList();
                PopulateMakeDropDownList();
                var dmvb = await _context.DailyMotorVehicleWorkBook.FindAsync(id);
                if (dmvb.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(dmvb);
            }
        }

        // POST: DailyMotorVehicleWorkBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleNo,Id,TankCapacity,Make,Date,Dates,TimeIn,TimeOut,SpeedometerOut,From,To,SpeedometerReadsIn,TotalMilesKmRun,PetrolOilReceived,AuthorityforJourney,UserSign,DriverName,UserID,StationName,Status,Yr,Mnt,Day")] DailyMotorVehicleWorkBook dailyMotorVehicleWorkBook)
        {
            if (ModelState.IsValid)
            {
                string stationName = HttpContext.Session.GetString("station");
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                string formats = "dd/MM/yyyy";
                string format = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string dates = Convert.ToString(CurrentServerTime.ToString(format));
                string date = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
               
                string userID = HttpContext.Session.GetString("UserID");
                
                    Int32 nYear = CurrentServerTime.Year;
                     Int32 nMonth = CurrentServerTime.Month;
                      Int32 nDay = CurrentServerTime.Day;
                
                    dailyMotorVehicleWorkBook.Yr = Convert.ToString(nYear);
                    dailyMotorVehicleWorkBook.Mnt = Convert.ToString(nMonth);
                    dailyMotorVehicleWorkBook.Day = Convert.ToString(nDay);
                    dailyMotorVehicleWorkBook.StationName = stationName;
                  
                    dailyMotorVehicleWorkBook.Dates = dates;
                    dailyMotorVehicleWorkBook.Id = 0;                  
                    dailyMotorVehicleWorkBook.Status = "No";                  
                    dailyMotorVehicleWorkBook.UserID = userID;
                    _context.Add(dailyMotorVehicleWorkBook);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(dailyMotorVehicleWorkBook);
        }

        // GET: DailyMotorVehicleWorkBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var dailyMotorVehicleWorkBook = await _context.DailyMotorVehicleWorkBook.FindAsync(id);
            if (dailyMotorVehicleWorkBook == null)
            {
                return NotFound();
            }
            return View(dailyMotorVehicleWorkBook);
        }

        // POST: DailyMotorVehicleWorkBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("VehicleNo,Id,TankCapacity,Make,Date,Dates,TimeIn,TimeOut,SpeedometerOut,Frm,Tos,SpeedometerReadsIn,TotalMilesKmRun,PetrolOilReceived,AuthorityforJourney,UserSign,DriverName,UserID,StationName,Status,Yr,Mnt,Day")] DailyMotorVehicleWorkBook dailyMotorVehicleWorkBook)
        {
       

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    string stationName = HttpContext.Session.GetString("station");
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    string formats = "dd/MM/yyyy";
                    string format = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string dates = Convert.ToString(CurrentServerTime.ToString(format));
                    string date = Convert.ToString(CurrentServerTime.ToString(formats));
                    string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                    
                    string userID = HttpContext.Session.GetString("UserID");
                    string statu = HttpContext.Session.GetString("status");
                    Int32 nYear = CurrentServerTime.Year;
                    Int32 nMonth = CurrentServerTime.Month;
                    Int32 nDay = CurrentServerTime.Day;

                    dailyMotorVehicleWorkBook.Yr = Convert.ToString(nYear);
                    dailyMotorVehicleWorkBook.Mnt = Convert.ToString(nMonth);
                    dailyMotorVehicleWorkBook.Day = Convert.ToString(nDay);
                    dailyMotorVehicleWorkBook.StationName = stationName;
                    dailyMotorVehicleWorkBook.Date = DateTime.UtcNow.Date;
                    dailyMotorVehicleWorkBook.Dates = dates;
                    dailyMotorVehicleWorkBook.Id = 0;
                    dailyMotorVehicleWorkBook.Status = "No";
                    dailyMotorVehicleWorkBook.UserID = userID;
                    _context.Add(dailyMotorVehicleWorkBook);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        string stationName = HttpContext.Session.GetString("station");
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        string formats = "dd/MM/yyyy";
                        string format = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string dates = Convert.ToString(CurrentServerTime.ToString(format));
                        string date = Convert.ToString(CurrentServerTime.ToString(formats));
                        string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));

                        string userID = HttpContext.Session.GetString("UserID");
                        string statu = HttpContext.Session.GetString("status");
                        Int32 nYear = CurrentServerTime.Year;
                        Int32 nMonth = CurrentServerTime.Month;
                        Int32 nDay = CurrentServerTime.Day;

                        dailyMotorVehicleWorkBook.Yr = Convert.ToString(nYear);
                        dailyMotorVehicleWorkBook.Mnt = Convert.ToString(nMonth);
                        dailyMotorVehicleWorkBook.Day = Convert.ToString(nDay);
                        dailyMotorVehicleWorkBook.StationName = stationName;
                        dailyMotorVehicleWorkBook.Date = DateTime.UtcNow.Date;
                        dailyMotorVehicleWorkBook.Dates = dates;
                        dailyMotorVehicleWorkBook.Id = 0;
                        dailyMotorVehicleWorkBook.Status = statu;
                        dailyMotorVehicleWorkBook.UserID = userID;
                        _context.Update(dailyMotorVehicleWorkBook);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DailyMotorVehicleWorkBookExists(dailyMotorVehicleWorkBook.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                PopulateVehicleDropDownList();
                PopulateTankCapacityDropDownList();
                PopulateMakeDropDownList();
                string stationNames = HttpContext.Session.GetString("station");
                string userIDs = HttpContext.Session.GetString("UserID");
                var Daily = (from s in _context.DailyMotorVehicleWorkBook where s.UserID == userIDs && s.Status == "No" && s.StationName == stationNames select s);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", Daily.ToList()) });
            }
            PopulateVehicleDropDownList();
            PopulateTankCapacityDropDownList();
            PopulateMakeDropDownList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", dailyMotorVehicleWorkBook) });
           
        }
        private void PopulateTankCapacityDropDownList()
        {

            List<VehicleRecord> vehiclelist = new List<VehicleRecord>();


            vehiclelist = (from category in _context.VehicleRecord orderby category.VehicleNo descending select category).ToList();
            // ------- Inserting Select Item in List -------
            vehiclelist.Insert(0, new VehicleRecord { VehicleNo = "", TankCapacity = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofCapacity = vehiclelist;
        }
        private void PopulateMakeDropDownList()
        {

            List<VehicleRecord> vehiclelist = new List<VehicleRecord>();


            vehiclelist = (from category in _context.VehicleRecord orderby category.VehicleNo descending select category).ToList();
            // ------- Inserting Select Item in List -------
            vehiclelist.Insert(0, new VehicleRecord { TankCapacity = "", Make = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofMake = vehiclelist;
        }
        private void PopulateVehicleDropDownList()
        {

            List<VehicleRecord> vehiclelist = new List<VehicleRecord>();

           
            vehiclelist = (from category in _context.VehicleRecord orderby category.VehicleNo descending select category).ToList();
            // ------- Inserting Select Item in List -------
            vehiclelist.Insert(0, new VehicleRecord { TankCapacity = "", VehicleNo = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofVehicle = vehiclelist;
        }
        // GET: DailyMotorVehicleWorkBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMotorVehicleWorkBook = await _context.DailyMotorVehicleWorkBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyMotorVehicleWorkBook == null)
            {
                return NotFound();
            }

            return View(dailyMotorVehicleWorkBook);
        }

        // POST: DailyMotorVehicleWorkBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyMotorVehicleWorkBook = await _context.DailyMotorVehicleWorkBook.FindAsync(id);
            if (dailyMotorVehicleWorkBook.Status == "No")
            {
                _context.DailyMotorVehicleWorkBook.Remove(dailyMotorVehicleWorkBook);
                await _context.SaveChangesAsync();
            }
            string stationNames = HttpContext.Session.GetString("station");
            string userIDs = HttpContext.Session.GetString("UserID");
            var Daily = (from s in _context.DailyMotorVehicleWorkBook where s.UserID == userIDs && (s.Status == "No" || s.Status == "Editting") && s.StationName == stationNames select s);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", Daily.ToList()) });
        }

        private bool DailyMotorVehicleWorkBookExists(int id)
        {
            return _context.DailyMotorVehicleWorkBook.Any(e => e.Id == id);
        }
    }
}
