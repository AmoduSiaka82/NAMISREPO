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
    public class dpqsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public dpqsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
      

        // GET: dpqs
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var dpq = (from s in _context.dpq where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);
            return View(await dpq.ToListAsync());
        }

        // GET: dpqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dpq = await _context.dpq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dpq == null)
            {
                return NotFound();
            }

            return View(dpq);
        }

        // GET: dpqs/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            
            if (id == 0)
            {
                ViewData["Dpqs"] = new SelectList(_context.Qualifications, "Qualify", "Qualify");
                return View(new dpq());
            }
            else
            {
                var dpq = await _context.dpq.FindAsync(id);
                if (dpq == null)
                {
                    return NotFound();
                }
               if (dpq.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                ViewData["Dpqs"] = new SelectList(_context.Qualifications, "Qualify", "Qualify");
                return View(dpq);
            }
        }

        // POST: dpqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dpq,CheckedBy,Date,Dates,SprpNo,Status,Id")] dpq dpqs)
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
                string userID = HttpContext.Session.GetString("UserID");
                dpqs.Dpq = dpqs.Dpq;
                dpqs.CheckedBy = userID;
                dpqs.Date = DateTime.UtcNow.Date;
                dpqs.Dates = dates;
                dpqs.SprpNo = sprpNo;
                dpqs.Status = "No";
                _context.Add(dpqs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dpqs);
        }

        // GET: dpqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var dpq = await _context.dpq.FindAsync(id);
            if (dpq == null)
            {
                return NotFound();
            }
            ViewData["Dpqs"] = new SelectList(_context.Qualifications, "Qualify", "Qualify");
            return View(dpq);
        }

        // POST: dpqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Dpq,CheckedBy,Date,Dates,SprpNo,Status,Id")] dpq dpqs)
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
                    string userID = HttpContext.Session.GetString("UserID");
                    dpqs.Dpq = dpqs.Dpq;
                    dpqs.CheckedBy = userID;
                    dpqs.Date = DateTime.UtcNow.Date;
                    dpqs.Dates = dates;
                    dpqs.SprpNo = sprpNo;
                    dpqs.Status = "No";
                    _context.Add(dpqs);
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
                        string userID = HttpContext.Session.GetString("UserID");
                        dpqs.Dpq = dpqs.Dpq;
                        dpqs.CheckedBy = userID;
                        dpqs.Date = DateTime.UtcNow.Date;
                        dpqs.Dates = dates;
                        dpqs.SprpNo = sprpNo;
                        dpqs.Status = statu;

                        _context.Update(dpqs);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!dpqExists(dpqs.Id))
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
                ViewData["Dpqs"] = new SelectList(_context.Qualifications, "Qualify", "Qualify");
                var dp = (from s in _context.dpq where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", dpqs) });
        

    }

    // GET: dpqs/Delete/5
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dpq = await _context.dpq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dpq == null)
            {
                return NotFound();
            }

            return View(dpq);
        }

        // POST: dpqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dpq = await _context.dpq.FindAsync(id);
            if (dpq.Status == "No")
            {
                _context.dpq.Remove(dpq);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var dp = (from s in _context.dpq where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
        }

        private bool dpqExists(int id)
        {
            return _context.dpq.Any(e => e.Id == id);
        }
    }
}
