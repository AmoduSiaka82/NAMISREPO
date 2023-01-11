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
    public class rofgpmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public rofgpmsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        // GET: rofgpms
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var rofgpm = (from s in _context.rofgpm where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);
            return View(await rofgpm.ToListAsync());
        }

        // GET: rofgpms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rofgpm = await _context.rofgpm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rofgpm == null)
            {
                return NotFound();
            }

            return View(rofgpm);
        }

        // GET: rofgpms/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new rofgpm());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var rofgpm = await _context.rofgpm.FindAsync(id);


                if (rofgpm.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(rofgpm);
            }
        }


        // POST: rofgpms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfPayment,FrmDate,ToDate,Yrs,Mos,Days,RatePerAnum,AmountPaid,FilePageRef,CheckedBy,Status,Date,Dates,SprpNo,Id")] rofgpm rofgpm)
        {
           
            if (ModelState.IsValid)
            {
            

                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string sprpNo = HttpContext.Session.GetString("SPRP");
                rofgpm.DateOfPayment = rofgpm.DateOfPayment;
                rofgpm.FrmDate = rofgpm.FrmDate;
                rofgpm.ToDate = rofgpm.ToDate;
                rofgpm.Yrs = rofgpm.Yrs;
                rofgpm.Mos = rofgpm.Mos;
                rofgpm.Days = rofgpm.Days;
                rofgpm.RatePerAnum = rofgpm.RatePerAnum;
                rofgpm.AmountPaid = rofgpm.AmountPaid;
                rofgpm.FilePageRef = rofgpm.FilePageRef;
                string usId = HttpContext.Session.GetString("UserID");

                rofgpm.CheckedBy = usId;
                rofgpm.Status = "No";
                rofgpm.Date = DateTime.UtcNow.Date;
                rofgpm.Dates = dates;
                rofgpm.SprpNo = sprpNo;
                _context.Add(rofgpm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rofgpm);
        }

        // GET: rofgpms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var rofgpm = await _context.rofgpm.FindAsync(id);
            if (rofgpm == null)
            {
                return NotFound();
            }
            return View(rofgpm);
        }

        // POST: rofgpms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateOfPayment,FrmDate,ToDate,Yrs,Mos,Days,RatePerAnum,AmountPaid,FilePageRef,CheckedBy,Status,Date,Dates,SprpNo,Id")] rofgpm rofgpm)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    rofgpm.DateOfPayment = rofgpm.DateOfPayment;
                    rofgpm.FrmDate = rofgpm.FrmDate;
                    rofgpm.ToDate = rofgpm.ToDate;
                    rofgpm.Yrs = rofgpm.Yrs;
                    rofgpm.Mos = rofgpm.Mos;
                    rofgpm.Days = rofgpm.Days;
                    rofgpm.RatePerAnum = rofgpm.RatePerAnum;
                    rofgpm.AmountPaid = rofgpm.AmountPaid;
                    rofgpm.FilePageRef = rofgpm.FilePageRef;
                    string usId = HttpContext.Session.GetString("UserID");

                    rofgpm.CheckedBy = usId;
                    rofgpm.Status = "No";
                    rofgpm.Date = DateTime.UtcNow.Date;
                    rofgpm.Dates = dates;
                    rofgpm.SprpNo = sprpNo;
                    _context.Add(rofgpm);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string statu = HttpContext.Session.GetString("status");
                        rofgpm.DateOfPayment = rofgpm.DateOfPayment;
                        rofgpm.FrmDate = rofgpm.FrmDate;
                        rofgpm.ToDate = rofgpm.ToDate;
                        rofgpm.Yrs = rofgpm.Yrs;
                        rofgpm.Mos = rofgpm.Mos;
                        rofgpm.Days = rofgpm.Days;
                        rofgpm.RatePerAnum = rofgpm.RatePerAnum;
                        rofgpm.AmountPaid = rofgpm.AmountPaid;
                        rofgpm.FilePageRef = rofgpm.FilePageRef;
                        string usId = HttpContext.Session.GetString("UserID");

                        rofgpm.CheckedBy = usId;
                        rofgpm.Status = statu;
                        rofgpm.Date = DateTime.UtcNow.Date;
                        rofgpm.Dates = dates;
                        rofgpm.SprpNo = sprpNo;
                        _context.Update(rofgpm);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!rofgpmExists(rofgpm.Id))
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
                var nx = (from s in _context.rofgpm where s.CheckedBy == userIDs && s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", rofgpm) });
           
        }

        // GET: rofgpms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rofgpm = await _context.rofgpm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rofgpm == null)
            {
                return NotFound();
            }

            return View(rofgpm);
        }

        // POST: rofgpms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rofgpm = await _context.rofgpm.FindAsync(id);
            if (rofgpm.Status == "No")
            {
                _context.rofgpm.Remove(rofgpm);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.rofgpm where s.CheckedBy == userIDs && s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool rofgpmExists(int id)
        {
            return _context.rofgpm.Any(e => e.Id == id);
        }
    }
}
