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
    public class LeavesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public LeavesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leaves.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaves == null)
            {
                return NotFound();
            }

            return View(leaves);
        }

        // GET: Leaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Department,LeaveType,StartDate,EndDate,Status,Dates,Date,Yr,Mnt,Day,Body,Address,Addresse,Salutation,Id,NoOfDays,EDate,SDate")] Leaves leaves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaves);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves.FindAsync(id);
            HttpContext.Session.SetString("Grd", leaves.GradeLevel);
           
            HttpContext.Session.SetString("Stp", leaves.Step);
            if (leaves == null)
            {
                return NotFound();
            }
            return View(leaves);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LeaveType,StartDate,EndDate,Dates,Date,Yr,Mnt,Day,NoOfDays,EDate,SDate,ResumeDate,RDate,GradeLevel,Step,StationName")] Leaves leaves)
        {
            
            if (id != leaves.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (leaves.LeaveType == "")
                    {
                        ModelState.AddModelError("", "Please Select Leave Type");
                        return View();
                    }
                    if (HttpContext.Request.Form["StartDate"].ToString() == "")
                    {
                        ModelState.AddModelError("", "Please Select Start Date");
                        return View();
                    }

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
                    string dat = "09/30/2020";
                    DateTime endDate = Convert.ToDateTime(dat);
                    DateTime startDate = Convert.ToDateTime(HttpContext.Request.Form["StartDate"].ToString());
                  
                    DateTime ResumtionDate;
                    DateTime rDate;
                    string userID = HttpContext.Session.GetString("UserID");
                    string grd = HttpContext.Session.GetString("Stp");
                    string stp = HttpContext.Session.GetString("Grd");
                    string Fap = HttpContext.Session.GetString("fap");
                    string Station = HttpContext.Session.GetString("station");
                    DateTime FirstAp = Convert.ToDateTime(Fap);
                    int noofmonth = (startDate - FirstAp).Days;
                    if (noofmonth < 120)
                    {
                        // ModelState.AddModelError("", "Not Due for leave,the staff can only go for Pro rata Leave");
                        // return View();
                    }
                    if (leaves.LeaveType == "Pro rata Leave")
                    {
                        int diff = 0;
                        if (grd == "CON_R 1" || grd == "CON_R 2" || grd == "CON_R 3" || grd == "CON_R 4" || grd == "CON_R 5")
                        {
                            endDate = startDate.AddDays(7);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 7)
                            {

                                diff = noofDay - 7;
                                noofDay = 7;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 7)
                            {

                                diff = 7 - noofDay;
                                noofDay = 7;
                                endDate = endDate.AddDays(diff);
                            }

                        }
                        else if (grd == "CON_R 6" || grd == "CON_R 7")
                        {
                            endDate = startDate.AddDays(14);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 14)
                            {

                                diff = noofDay - 14;
                                noofDay = 14;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 14)
                            {

                                diff = 14 - noofDay;
                                noofDay = 14;
                                endDate = endDate.AddDays(diff);
                            }
                        }
                        else
                        {
                            endDate = startDate.AddDays(21);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 21)
                            {

                                diff = noofDay - 21;
                                noofDay = 21;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 21)
                            {

                                diff = 21 - noofDay;
                                noofDay = 21;
                                endDate = endDate.AddDays(diff);
                            }
                        }
                    }
                    else if(leaves.LeaveType == "Annual Leave")
                    {

                        int diff = 0;
                        if (grd == "CON_R 1" || grd == "CON_R 2" || grd == "CON_R 3" || grd == "CON_R 4" || grd == "CON_R 5")
                        {
                            endDate = startDate.AddDays(14);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 14)
                            {

                                diff = noofDay - 14;
                                noofDay = 14;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 14)
                            {

                                diff = 14 - noofDay;
                                noofDay = 14;
                                endDate = endDate.AddDays(diff);
                            }

                        }
                        else if (grd == "CON_R 6")
                        {
                            endDate = startDate.AddDays(21);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 21)
                            {

                                diff = noofDay - 21;
                                noofDay = 21;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 21)
                            {

                                diff = 21 - noofDay;
                                noofDay = 21;
                                endDate = endDate.AddDays(diff);
                            }
                        }
                        else
                        {
                            endDate = startDate.AddMonths(1);
                            noofDay = (endDate - startDate).Days;
                            if (noofDay > 30)
                            {

                                diff = noofDay - 30;
                                noofDay = 30;
                                endDate = endDate.AddDays(-diff);
                            }
                            else if (noofDay < 30)
                            {

                                diff = 30 - noofDay;
                                noofDay = 30;
                                endDate = endDate.AddDays(diff);
                            }
                        }
                    }
                    else if (leaves.LeaveType == "Casual Leave")
                    {
                        endDate = startDate.AddDays(7);
                        noofDay = (endDate - startDate).Days;
                        int diff = 0;
                        if (noofDay > 7)
                        {

                            diff = noofDay - 7;
                            noofDay = 7;
                            endDate = endDate.AddDays(-diff);
                        }
                        else if (noofDay < 7)
                        {

                            diff = 7 - noofDay;
                            noofDay = 7;
                            endDate = endDate.AddDays(diff);
                        }

                    }
                    else if (leaves.LeaveType == "Sabbatical Leave")
                    {

                        endDate = startDate.AddMonths(12);
                        noofDay = (endDate - startDate).Days;

                    }
                    else if (leaves.LeaveType == "Maternity Leave")
                    {
                        endDate = startDate.AddMonths(4);
                        noofDay = (endDate - startDate).Days;
                        int diff = 0;
                        if (noofDay > 120)
                        {

                            diff = noofDay - 120;
                            noofDay = 120;
                            endDate = endDate.AddDays(-diff);
                        }
                        else if (noofDay < 120)
                        {

                            diff = 120 - noofDay;
                            noofDay = 120;
                            endDate = endDate.AddDays(diff);
                        }

                    }
                    else if (leaves.LeaveType == "Study Leave")
                    {
                        if (HttpContext.Request.Form["EndDate"].ToString() == "")
                        {
                            ModelState.AddModelError("", "Please Select End date");
                            return View();
                        }
                        endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                        noofDay = (endDate - startDate).Days;

                    }
                    else if (leaves.LeaveType == "Leave Of Absence")
                    {

                        if (HttpContext.Request.Form["EndDate"].ToString() == "")
                        {
                            ModelState.AddModelError("", "Please Select End date");
                            return View();
                        }
                        endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                        noofDay = (endDate - startDate).Days;


                    }

                    else if (leaves.LeaveType == "Sick Leave")
                    {
                        if (HttpContext.Request.Form["EndDate"].ToString() == "")
                        {
                            ModelState.AddModelError("", "Please Select End date");
                            return View();
                        }
                        endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                        noofDay = (endDate - startDate).Days;

                    }
                    else if (leaves.LeaveType == "Pre Retirement Leave")
                    {
                        endDate = startDate.AddMonths(3);
                        noofDay = (endDate - startDate).Days;
                        int diff = 0;
                        if (noofDay > 90)
                        {

                            diff = noofDay - 90;
                            noofDay = 90;
                            endDate = endDate.AddDays(-diff);
                        }
                        else if (noofDay < 90)
                        {

                            diff = 90 - noofDay;
                            noofDay = 90;
                            endDate = endDate.AddDays(diff);
                        }

                    }
                    ResumtionDate = endDate.AddDays(1);
                    rDate = endDate.AddDays(1);
                    string sdate = Convert.ToString(startDate.ToString(format));
                    string edate = Convert.ToString(endDate.ToString(format));

                    string startdate = Convert.ToString(startDate.ToString(formats));
                    string enddate = Convert.ToString(endDate.ToString(formats));
                    
                    Leaves lv = new Leaves();
                    
                    leaves.LeaveType = leaves.LeaveType;
                    leaves.EndDate = endDate;
                    leaves.StartDate = startDate;
                    leaves.EDate = endDate;
                    leaves.SDate = startDate;
                    leaves.Date = DateTime.UtcNow.Date;
                    leaves.Dates = dates;
                    leaves.Yr = Convert.ToString(nYear);
                    leaves.Mnt = Convert.ToString(nMonth);
                    leaves.Day = Convert.ToString(nDay);
                    leaves.NoOfDays = Convert.ToString(noofDay);
                    
                   
                    leaves.ResumeDate = ResumtionDate;
                    leaves.RDate = rDate;
                   
                    leaves.GradeLevel = grd;
                    leaves.Step = stp;
                    leaves.StationName = Station;
                   
                    

                    _context.Update(leaves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavesExists(leaves.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UsersController.LeaveRoster));
            }
            return View(leaves);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaves == null)
            {
                return NotFound();
            }

            return View(leaves);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leaves = await _context.Leaves.FindAsync(id);
            _context.Leaves.Remove(leaves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavesExists(string id)
        {
            return _context.Leaves.Any(e => e.Id == id);
        }
    }
}
