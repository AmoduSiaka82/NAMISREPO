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
    public class tourandleaverecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public tourandleaverecordsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: tourandleaverecords
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var tourandleaverecord = (from s in _context.tourandleaverecord where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await tourandleaverecord.ToListAsync());
        }

        // GET: tourandleaverecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourandleaverecord = await _context.tourandleaverecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourandleaverecord == null)
            {
                return NotFound();
            }

            return View(tourandleaverecord);
        }

        // GET: tourandleaverecords/Create

        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
        
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new tourandleaverecord());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var tourandleave = await _context.tourandleaverecord.FindAsync(id);
                
                
                if (tourandleave.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(tourandleave);
            }
        }
       
        // POST: tourandleaverecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateStarted,GazetteNoticeNo,LengthOfTourForAge,DateDueForLeave,DateDepartedOnLeave,GazetteNoticeNumber,DateExtentionGranted,SalaryRuleForExtention,DateResumedDuty,PassageBySeaOrAirToUk,PassageBySeaOrAirFrmUk,ResidentMonths,ResidentDays,LeaveMonths,LeaveDays,Date,Dates,SprpNo,Status,Id")] tourandleaverecord tourandleaverecord)
        {
           
            if (ModelState.IsValid)
            {
                string sprpNo = HttpContext.Session.GetString("SPRP");
              

                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
               
                tourandleaverecord.DateStarted = tourandleaverecord.DateStarted;
                tourandleaverecord.GazetteNoticeNo = tourandleaverecord.GazetteNoticeNo;
                tourandleaverecord.LengthOfTourForAge = tourandleaverecord.LengthOfTourForAge;
                tourandleaverecord.DateDueForLeave = tourandleaverecord.DateDueForLeave;
                tourandleaverecord.DateDepartedOnLeave = tourandleaverecord.DateDepartedOnLeave;
                tourandleaverecord.GazetteNoticeNumber = tourandleaverecord.GazetteNoticeNumber;
                tourandleaverecord.DateExtentionGranted = tourandleaverecord.DateExtentionGranted;
                tourandleaverecord.SalaryRuleForExtention = tourandleaverecord.SalaryRuleForExtention;
                tourandleaverecord.DateResumedDuty = tourandleaverecord.DateResumedDuty;
                tourandleaverecord.PassageBySeaOrAirFrmUk = tourandleaverecord.PassageBySeaOrAirFrmUk;
                tourandleaverecord.PassageBySeaOrAirToUk = tourandleaverecord.PassageBySeaOrAirToUk;
                tourandleaverecord.ResidentMonths = tourandleaverecord.ResidentMonths;
                tourandleaverecord.ResidentDays = tourandleaverecord.ResidentDays;
                tourandleaverecord.LeaveMonths = tourandleaverecord.LeaveMonths;
                tourandleaverecord.LeaveDays = tourandleaverecord.LeaveDays;
                tourandleaverecord.Date = DateTime.UtcNow.Date;
                tourandleaverecord.Dates = dates;
                tourandleaverecord.SprpNo = sprpNo;
                tourandleaverecord.Status = "No";
                _context.Add(tourandleaverecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourandleaverecord);
        }

        // GET: tourandleaverecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var tourandleaverecord = await _context.tourandleaverecord.FindAsync(id);
            if (tourandleaverecord == null)
            {
                return NotFound();
            }
            return View(tourandleaverecord);
        }

        // POST: tourandleaverecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateStarted,GazetteNoticeNo,LengthOfTourForAge,DateDueForLeave,DateDepartedOnLeave,GazetteNoticeNumber,DateExtentionGranted,SalaryRuleForExtention,DateResumedDuty,PassageBySeaOrAirToUk,PassageBySeaOrAirFrmUk,ResidentMonths,ResidentDays,LeaveMonths,LeaveDays,Date,Dates,SprpNo,Status,Id")] tourandleaverecord tourandleaverecord)
        {
          
           

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    string sprpNo = HttpContext.Session.GetString("SPRP");


                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                    tourandleaverecord.DateStarted = tourandleaverecord.DateStarted;
                    tourandleaverecord.GazetteNoticeNo = tourandleaverecord.GazetteNoticeNo;
                    tourandleaverecord.LengthOfTourForAge = tourandleaverecord.LengthOfTourForAge;
                    tourandleaverecord.DateDueForLeave = tourandleaverecord.DateDueForLeave;
                    tourandleaverecord.DateDepartedOnLeave = tourandleaverecord.DateDepartedOnLeave;
                    tourandleaverecord.GazetteNoticeNumber = tourandleaverecord.GazetteNoticeNumber;
                    tourandleaverecord.DateExtentionGranted = tourandleaverecord.DateExtentionGranted;
                    tourandleaverecord.SalaryRuleForExtention = tourandleaverecord.SalaryRuleForExtention;
                    tourandleaverecord.DateResumedDuty = tourandleaverecord.DateResumedDuty;
                    tourandleaverecord.PassageBySeaOrAirFrmUk = tourandleaverecord.PassageBySeaOrAirFrmUk;
                    tourandleaverecord.PassageBySeaOrAirToUk = tourandleaverecord.PassageBySeaOrAirToUk;
                    tourandleaverecord.ResidentMonths = tourandleaverecord.ResidentMonths;
                    tourandleaverecord.ResidentDays = tourandleaverecord.ResidentDays;
                    tourandleaverecord.LeaveMonths = tourandleaverecord.LeaveMonths;
                    tourandleaverecord.LeaveDays = tourandleaverecord.LeaveDays;
                    tourandleaverecord.Date = DateTime.UtcNow.Date;
                    tourandleaverecord.Dates = dates;
                    tourandleaverecord.SprpNo = sprpNo;
                    tourandleaverecord.Status = "No";
                    _context.Add(tourandleaverecord);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    try
                    {

                       

                        string statu = HttpContext.Session.GetString("status");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                        tourandleaverecord.DateStarted = tourandleaverecord.DateStarted;
                        tourandleaverecord.GazetteNoticeNo = tourandleaverecord.GazetteNoticeNo;
                        tourandleaverecord.LengthOfTourForAge = tourandleaverecord.LengthOfTourForAge;
                        tourandleaverecord.DateDueForLeave = tourandleaverecord.DateDueForLeave;
                        tourandleaverecord.DateDepartedOnLeave = tourandleaverecord.DateDepartedOnLeave;
                        tourandleaverecord.GazetteNoticeNumber = tourandleaverecord.GazetteNoticeNumber;
                        tourandleaverecord.DateExtentionGranted = tourandleaverecord.DateExtentionGranted;
                        tourandleaverecord.SalaryRuleForExtention = tourandleaverecord.SalaryRuleForExtention;
                        tourandleaverecord.DateResumedDuty = tourandleaverecord.DateResumedDuty;
                        tourandleaverecord.PassageBySeaOrAirFrmUk = tourandleaverecord.PassageBySeaOrAirFrmUk;
                        tourandleaverecord.PassageBySeaOrAirToUk = tourandleaverecord.PassageBySeaOrAirToUk;
                        tourandleaverecord.ResidentMonths = tourandleaverecord.ResidentMonths;
                        tourandleaverecord.ResidentDays = tourandleaverecord.ResidentDays;
                        tourandleaverecord.LeaveMonths = tourandleaverecord.LeaveMonths;
                        tourandleaverecord.LeaveDays = tourandleaverecord.LeaveDays;
                        tourandleaverecord.Date = DateTime.UtcNow.Date;
                        tourandleaverecord.Dates = dates;
                        tourandleaverecord.SprpNo = sprpNo;
                        tourandleaverecord.Status = statu;
                        _context.Update(tourandleaverecord);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!tourandleaverecordExists(tourandleaverecord.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                string sprpNos = HttpContext.Session.GetString("SPRP");
                string userIDs = HttpContext.Session.GetString("UserID");
                var nx = (from s in _context.tourandleaverecord where  s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", tourandleaverecord) });
           
        }

        // GET: tourandleaverecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourandleaverecord = await _context.tourandleaverecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourandleaverecord == null)
            {
                return NotFound();
            }

            return View(tourandleaverecord);
        }

        // POST: tourandleaverecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourandleaverecord = await _context.tourandleaverecord.FindAsync(id);
            _context.tourandleaverecord.Remove(tourandleaverecord);
            await _context.SaveChangesAsync();
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.tourandleaverecord where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool tourandleaverecordExists(int id)
        {
            return _context.tourandleaverecord.Any(e => e.Id == id);
        }
    }
}
