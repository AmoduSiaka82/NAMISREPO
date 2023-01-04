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
    public class totalpreviousservicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public totalpreviousservicesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: totalpreviousservices
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var totalpreviousservice = (from s in _context.totalpreviousservice where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") select s);
            return View(await totalpreviousservice.ToListAsync());
        }

        // GET: totalpreviousservices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalpreviousservice = await _context.totalpreviousservice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (totalpreviousservice == null)
            {
                return NotFound();
            }

            return View(totalpreviousservice);
        }

        // GET: totalpreviousservices/Create
        public async Task<IActionResult> CreateEdit(int id=0)
        {
           
            if (id == 0)
            {
                return View(new totalpreviousservice());
            }
            else
            {
                var totalpreviousservice = await _context.totalpreviousservice.FindAsync(id);
                if (totalpreviousservice == null)
                {
                    return NotFound();
                }
                if (totalpreviousservice.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(totalpreviousservice);
            }
        }

        // POST: totalpreviousservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Yrs,Mos,Days,TotalAmountPay,SprpNo,Dates,Date,Status,ID")] totalpreviousservice totalpreviousservice)
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
               
                totalpreviousservice.Yrs = totalpreviousservice.Yrs;
                totalpreviousservice.Mos = totalpreviousservice.Mos;
                totalpreviousservice.Days = totalpreviousservice.Days;
                totalpreviousservice.TotalAmountPay = totalpreviousservice.TotalAmountPay;
                totalpreviousservice.SprpNo = sprpNo;
                totalpreviousservice.Dates = dates;
                totalpreviousservice.Date = DateTime.UtcNow.Date;
                totalpreviousservice.Status = "No";
                _context.Add(totalpreviousservice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(totalpreviousservice);
        }

        // GET: totalpreviousservices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var totalpreviousservice = await _context.totalpreviousservice.FindAsync(id);
            if (totalpreviousservice == null)
            {
                return NotFound();
            }
            return View(totalpreviousservice);
        }

        // POST: totalpreviousservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Yrs,Mos,Days,TotalAmountPay,SprpNo,Dates,Date,Status,ID")] totalpreviousservice totalpreviousservice)
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

                    totalpreviousservice.Yrs = totalpreviousservice.Yrs;
                    totalpreviousservice.Mos = totalpreviousservice.Mos;
                    totalpreviousservice.Days = totalpreviousservice.Days;
                    totalpreviousservice.TotalAmountPay = totalpreviousservice.TotalAmountPay;
                    totalpreviousservice.SprpNo = sprpNo;
                    totalpreviousservice.Dates = dates;
                    totalpreviousservice.Date = DateTime.UtcNow.Date;
                    totalpreviousservice.Status = "No";
                    totalpreviousservice.ID = 0;
                    _context.Add(totalpreviousservice);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        string statu = HttpContext.Session.GetString("status");
                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                        totalpreviousservice.Yrs = totalpreviousservice.Yrs;
                        totalpreviousservice.Mos = totalpreviousservice.Mos;
                        totalpreviousservice.Days = totalpreviousservice.Days;
                        totalpreviousservice.TotalAmountPay = totalpreviousservice.TotalAmountPay;
                        totalpreviousservice.SprpNo = sprpNo;
                        totalpreviousservice.Dates = dates;
                        totalpreviousservice.Date = DateTime.UtcNow.Date;
                        totalpreviousservice.Status = statu;
                        totalpreviousservice.ID = 0;
                        _context.Update(totalpreviousservice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!totalpreviousserviceExists(totalpreviousservice.ID))
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
                var nx = (from s in _context.totalpreviousservice where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", totalpreviousservice) });
        }

        // GET: totalpreviousservices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalpreviousservice = await _context.totalpreviousservice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (totalpreviousservice == null)
            {
                return NotFound();
            }

            return View(totalpreviousservice);
        }

        // POST: totalpreviousservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalpreviousservice = await _context.totalpreviousservice.FindAsync(id);
            if (totalpreviousservice.Status == "No")
            {
                _context.totalpreviousservice.Remove(totalpreviousservice);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.totalpreviousservice where  s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool totalpreviousserviceExists(int id)
        {
            return _context.totalpreviousservice.Any(e => e.ID == id);
        }
    }
}
