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
    public class MinuteRegistersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public MinuteRegistersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;
            this.configuration = config;
        }
        
       
        

        // GET: MinuteRegisters
        public async Task<IActionResult> Index()
        {
            string userID = HttpContext.Session.GetString("UserID");
            var Register = (from s in _context.MinuteRegister where s.UserID==userID && s.Status == "No" select s);

            return View(await Register.ToListAsync());
           
        }

        // GET: MinuteRegisters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuteRegister = await _context.MinuteRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuteRegister == null)
            {
                return NotFound();
            }

            return View(minuteRegister);
        }

        // GET: MinuteRegisters/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: MinuteRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MinuteTitle,Attendance,Id,MinuteNo,UserID,Status")] MinuteRegister minuteRegister)
        {
          
            if (ModelState.IsValid)
            {
                string userID = HttpContext.Session.GetString("UserID");
                string Station = HttpContext.Session.GetString("station");
                int iNo;
                string MinuteId = "";
                string MinuteNo = "";

                DALClass sign = new DALClass(configuration);
                MinuteNo = sign.MinuteNoAuto().ToString();

                if (MinuteNo.Equals("") || MinuteNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(MinuteNo);
                    iNo++;
                }
                if (iNo < 10) { MinuteId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { MinuteId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { MinuteId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { MinuteId = "0" + Convert.ToString(iNo); }
                else MinuteId = Convert.ToString(iNo);
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
                minuteRegister.Id = MinuteId;
                minuteRegister.Status = "No";
                minuteRegister.UserID = userID;
                _context.Add(minuteRegister);
               int i= await _context.SaveChangesAsync();
                if (i>0)
                {
                    MinuteOfMeeting Minute = new MinuteOfMeeting();
                    Minute.MinuteID = MinuteId;
                    Minute.MinuteTitle = minuteRegister.MinuteTitle;
                    Minute.Title="";
                    Minute.Contents = "";
                    Minute.MinuteNo = "Minute No";
                    Minute.Id = 0;
                    Minute.Date = DateTime.UtcNow.Date;
                    Minute.Dates = dates;
                    Minute.Yr = Convert.ToString(nYear);
                    Minute.Mnt = Convert.ToString(nMonth);
                    Minute.Day = Convert.ToString(nDay);
                    Minute.UserID = userID;
                    Minute.StationName = Station;
                    Minute.Status = "No";
                    _context.Add(Minute);
                     await _context.SaveChangesAsync();
                    Minute.MinuteID = MinuteId;
                    Minute.MinuteTitle = "";
                    Minute.Title = "ATTENDANCE";
                    Minute.Contents = minuteRegister.Attendance;
                    Minute.MinuteNo = minuteRegister.MinuteNo;
                    Minute.Id = 0;
                    Minute.Date = DateTime.UtcNow.Date;
                    Minute.Dates = dates;
                    Minute.Yr = Convert.ToString(nYear);
                    Minute.Mnt = Convert.ToString(nMonth);
                    Minute.Day = Convert.ToString(nDay);
                    Minute.UserID = userID;
                    Minute.StationName = Station;
                    Minute.Status = "No";
                    _contex.Add(Minute);
                    await _contex.SaveChangesAsync();
                    HttpContext.Session.SetString("MINUTEID", MinuteId);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(minuteRegister);
        }

        // GET: MinuteRegisters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var minuteRegister = await _context.MinuteRegister.FindAsync(id);
            if (minuteRegister == null)
            {
                return NotFound();
            }
            return View(minuteRegister);
        }

        // POST: MinuteRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MinuteTitle,Attendance,Id,MinuteNo,UserID,Status")] MinuteRegister minuteRegister)
        {

            if (id != minuteRegister.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
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
                    minuteRegister.Status = "No";
                    minuteRegister.UserID = userID;
                    _context.Update(minuteRegister);
                   int i= await _context.SaveChangesAsync();
                    if (i>0)
                    {
                        
                        _context.MinuteOfMeeting.Where(x => x.MinuteID== minuteRegister.Id && x.Status == "No" && x.UserID == userID && x.Title== "ATTENDANCE").ToList().ForEach(x =>
                        {
                            x.MinuteID = minuteRegister.Id;

                            x.Title = "ATTENDANCE";
                            x.Contents = minuteRegister.Attendance;
                            x.MinuteNo = minuteRegister.MinuteNo;
                            x.MinuteTitle = minuteRegister.MinuteTitle;
                            
                            x.Date = DateTime.UtcNow.Date;
                            x.Dates = dates;
                            x.Yr = Convert.ToString(nYear);
                            x.Mnt = Convert.ToString(nMonth);
                            x.Day = Convert.ToString(nDay);
                            x.UserID = userID;
                            x.StationName = Station;
                        });
                        _context.SaveChanges();
                        _contex.MinuteOfMeeting.Where(x => x.MinuteID == minuteRegister.Id && x.Status == "No" && x.UserID == userID && x.Title == "").ToList().ForEach(x =>
                        {
                            x.MinuteID = minuteRegister.Id;

                            x.Title = "";
                            x.Contents = "";
                            x.MinuteNo = "Minute No";
                            x.MinuteTitle = minuteRegister.MinuteTitle;

                            x.Date = DateTime.UtcNow.Date;
                            x.Dates = dates;
                            x.Yr = Convert.ToString(nYear);
                            x.Mnt = Convert.ToString(nMonth);
                            x.Day = Convert.ToString(nDay);
                            x.UserID = userID;
                            x.StationName = Station;
                        });
                        _contex.SaveChanges();
                        HttpContext.Session.SetString("MINUTEID", minuteRegister.Id);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinuteRegisterExists(minuteRegister.Id))
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
            return View(minuteRegister);
        }

        // GET: MinuteRegisters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuteRegister = await _context.MinuteRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuteRegister == null)
            {
                return NotFound();
            }

            return View(minuteRegister);
        }

        // POST: MinuteRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var minuteRegister = await _context.MinuteRegister.FindAsync(id);
            _context.MinuteRegister.Remove(minuteRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinuteRegisterExists(string id)
        {
            return _context.MinuteRegister.Any(e => e.Id == id);
        }
    }
}
