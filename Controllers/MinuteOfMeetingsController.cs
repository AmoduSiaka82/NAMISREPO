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
    public class MinuteOfMeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public MinuteOfMeetingsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: MinuteOfMeetings
        [NoDirectAccess]
        public async Task<IActionResult> ViewMinuteOfMeetings(string Id)
        {
            var Register = (from s in _context.MinuteOfMeeting where s.MinuteID == Id orderby s.Id ascending select s);

            return View(await Register.ToListAsync());
            
        }
        [NoDirectAccess]
        public async Task<IActionResult> Index(string Id)
        {
            var Register = (from s in _context.MinuteOfMeeting where s.MinuteID == Id orderby s.Id ascending select s);
            HttpContext.Session.SetString("MINUTEID", Id);
            return View(await Register.ToListAsync());
        }

        // GET: MinuteOfMeetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuteOfMeeting = await _context.MinuteOfMeeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuteOfMeeting == null)
            {
                return NotFound();
            }

            return View(minuteOfMeeting);
        }

        // GET: MinuteOfMeetings/Create
        [NoDirectAccess]
        public IActionResult Create(string Id)
        {
           
            HttpContext.Session.SetString("MINUTEID", Id);
            return View(new MinuteOfMeeting());
        }
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
           
            if (id == 0)
            {
                return View(new MinuteOfMeeting());
            }
            else
            {
               
                var mn = await _context.MinuteOfMeeting.FindAsync(id);


                if (mn.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(mn);
            }
        }
        // POST: MinuteOfMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Contents,MinuteNo,Id,Date,Dates,UserID,StationName,MinuteID,Status,Yr,Mnt,Day")] MinuteOfMeeting minuteOfMeeting)
        {
           
            if (ModelState.IsValid)
            {
                
                string userID = HttpContext.Session.GetString("UserID");
                string Station = HttpContext.Session.GetString("station");
                string minuteID = HttpContext.Session.GetString("MINUTEID");
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
                minuteOfMeeting.Date = DateTime.UtcNow.Date;
                minuteOfMeeting.Dates = dates;
                minuteOfMeeting.UserID = userID;
                minuteOfMeeting.Yr = Convert.ToString(nYear);
                minuteOfMeeting.Mnt = Convert.ToString(nMonth);
                minuteOfMeeting.Day = Convert.ToString(nDay);
                minuteOfMeeting.Status = "No";
                minuteOfMeeting.MinuteID = minuteID;
                minuteOfMeeting.StationName = Station;
                minuteOfMeeting.Id = 0;
                minuteOfMeeting.MinuteTitle = "";
                _context.Add(minuteOfMeeting);
                await _context.SaveChangesAsync();
                var Register = (from s in _context.MinuteOfMeeting where s.MinuteID == minuteID orderby s.Id ascending select s);
                HttpContext.Session.SetString("MINUTEID", minuteID);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", Register.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", minuteOfMeeting) });
        
            
        }

        // GET: MinuteOfMeetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var minuteOfMeeting = await _context.MinuteOfMeeting.FindAsync(id);
            if (minuteOfMeeting == null)
            {
                return NotFound();
            }
            return View(minuteOfMeeting);
        }

        // POST: MinuteOfMeetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Title,Contents,MinuteNo,Id,Date,Dates,UserID,StationName,MinuteID,Status,Yr,Mnt,Day")] MinuteOfMeeting minuteOfMeeting)
        {
            
            if (id != minuteOfMeeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string minuteID = HttpContext.Session.GetString("MINUTEID");
                try
                {

                    string userID = HttpContext.Session.GetString("UserID");
                    string Station = HttpContext.Session.GetString("station");
                   
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
                    minuteOfMeeting.Date = DateTime.UtcNow.Date;
                    minuteOfMeeting.Dates = dates;
                    minuteOfMeeting.UserID = userID;
                    minuteOfMeeting.Yr = Convert.ToString(nYear);
                    minuteOfMeeting.Mnt = Convert.ToString(nMonth);
                    minuteOfMeeting.Day = Convert.ToString(nDay);
                    minuteOfMeeting.Status = "No";
                    minuteOfMeeting.MinuteID = minuteID;
                    minuteOfMeeting.StationName = Station;
                    minuteOfMeeting.Id = 0;
                    minuteOfMeeting.MinuteTitle = "";
                    _context.Update(minuteOfMeeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinuteOfMeetingExists(minuteOfMeeting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var Register = (from s in _context.MinuteOfMeeting where s.MinuteID == minuteID orderby s.Id ascending select s);
                HttpContext.Session.SetString("MINUTEID", minuteID);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", Register.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", minuteOfMeeting) });
        }

        // GET: MinuteOfMeetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuteOfMeeting = await _context.MinuteOfMeeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuteOfMeeting == null)
            {
                return NotFound();
            }

            return View(minuteOfMeeting);
        }

        // POST: MinuteOfMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var minuteOfMeeting = await _context.MinuteOfMeeting.FindAsync(id);
            var Register = (from s in _context.MinuteOfMeeting where s.MinuteID == minuteOfMeeting.MinuteID orderby s.Id ascending select s);
            HttpContext.Session.SetString("MINUTEID", minuteOfMeeting.MinuteID);
            if (minuteOfMeeting.Status == "No")
            {
                _context.MinuteOfMeeting.Remove(minuteOfMeeting);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
           
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", Register.ToList()) });
        
           
        }

        private bool MinuteOfMeetingExists(int id)
        {
            return _context.MinuteOfMeeting.Any(e => e.Id == id);
        }
    }
}
