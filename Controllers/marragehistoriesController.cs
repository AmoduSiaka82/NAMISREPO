using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class marragehistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public marragehistoriesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: marragehistories
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string sprpNos = HttpContext.Session.GetString("SPRP");
            
            var marragehistory = (from s in _context.marragehistory where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await _context.marragehistory.ToListAsync());
        }

        // GET: marragehistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marragehistory = await _context.marragehistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marragehistory == null)
            {
                return NotFound();
            }

            return View(marragehistory);
        }

        // GET: marragehistories/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            
            if (id == 0)
            {
                return View(new marragehistory());
            }
            else
            {
                var marragehistory = await _context.marragehistory.FindAsync(id);
                if (marragehistory == null)
                {
                    return NotFound();
                }
                
              
                if (marragehistory.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(marragehistory);
            }
        }

        // POST: marragehistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaritalStatus,DateOfMarriage,NameOfWife,WifeDateOfBirth,SprpNo,Date,Dates,Id,Status")] marragehistory marragehistory)
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
                marragehistory.MaritalStatus = marragehistory.MaritalStatus;
                marragehistory.DateOfMarriage = marragehistory.DateOfMarriage;
                marragehistory.NameOfWife = marragehistory.NameOfWife;
                marragehistory.WifeDateOfBirth = marragehistory.WifeDateOfBirth;
                marragehistory.SprpNo = sprpNo;
                marragehistory.Dates = dates;
                marragehistory.Date =  DateTime.UtcNow.Date;
                marragehistory.Status = "No";
                _context.Add(marragehistory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "particularofchildrens");
            }
            return View(marragehistory);
        }

        // GET: marragehistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var marragehistory = await _context.marragehistory.FindAsync(id);
            if (marragehistory == null)
            {
                return NotFound();
            }
            return View(marragehistory);
        }

        // POST: marragehistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("MaritalStatus,DateOfMarriage,NameOfWife,WifeDateOfBirth,SprpNo,Date,Dates,Id,Status")] marragehistory marragehistory)
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
                    marragehistory.MaritalStatus = marragehistory.MaritalStatus;
                    marragehistory.DateOfMarriage = marragehistory.DateOfMarriage;
                    marragehistory.NameOfWife = marragehistory.NameOfWife;
                    marragehistory.WifeDateOfBirth = marragehistory.WifeDateOfBirth;
                    marragehistory.SprpNo = sprpNo;
                    marragehistory.Dates = dates;
                    marragehistory.Date = DateTime.UtcNow.Date;
                    marragehistory.Status = "No";
                    _context.Add(marragehistory);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string statu = HttpContext.Session.GetString("status");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                        marragehistory.MaritalStatus = marragehistory.MaritalStatus;
                        marragehistory.DateOfMarriage = marragehistory.DateOfMarriage;
                        marragehistory.NameOfWife = marragehistory.NameOfWife;
                        marragehistory.WifeDateOfBirth = marragehistory.WifeDateOfBirth;
                        marragehistory.SprpNo = sprpNo;
                        marragehistory.Dates = dates;
                        marragehistory.Date =  DateTime.UtcNow.Date;
                        marragehistory.Status = statu;

                        _context.Update(marragehistory);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!marragehistoryExists(marragehistory.Id))
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
                var mhx = (from s in _context.marragehistory where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting")  select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", mhx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", marragehistory) });
        }

        // GET: marragehistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marragehistory = await _context.marragehistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marragehistory == null)
            {
                return NotFound();
            }

            return View(marragehistory);
        }

        // POST: marragehistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marragehistory = await _context.marragehistory.FindAsync(id);
            if (marragehistory.Status == "No")
            {
                _context.marragehistory.Remove(marragehistory);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var mhx = (from s in _context.marragehistory where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", mhx.ToList()) });
        }

        private bool marragehistoryExists(int id)
        {
            return _context.marragehistory.Any(e => e.Id == id);
        }
    }
}
