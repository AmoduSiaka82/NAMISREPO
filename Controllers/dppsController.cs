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
    public class dppsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public dppsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
       

        // GET: dpps
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var dpp = (from s in _context.dpps where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.Checkedby==userID select s);
            return View(await dpp.ToListAsync());
        }

        // GET: dpps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dpps = await _context.dpps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dpps == null)
            {
                return NotFound();
            }

            return View(dpps);
        }

        // GET: dpps/Create
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (id == 0)
            {
                return View(new dpps());
            }
            else
            {
                var dpps = await _context.dpps.FindAsync(id);
                if (dpps == null)
                {
                    return NotFound();
                }
                if (dpps.Status == "Ëditting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(dpps);
            }
        }

        // POST: dpps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Psemployer,FrmDate,ToDate,SprpNo,Id,FilePageRef,Checkedby")] dpps dpps)
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
                dpps.Psemployer = dpps.Psemployer;
                dpps.FrmDate = dpps.FrmDate;
                dpps.ToDate = dpps.ToDate;
                dpps.SprpNo = sprpNo;
                dpps.FilePageRef = dpps.FilePageRef;
                dpps.Checkedby = dpps.Checkedby;
                dpps.Status = "No";
                _context.Add(dpps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dpps);
        }

        // GET: dpps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var dpps = await _context.dpps.FindAsync(id);
            if (dpps == null)
            {
                return NotFound();
            }
            return View(dpps);
        }

        // POST: dpps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Psemployer,FrmDate,ToDate,SprpNo,Id,FilePageRef,Checkedby")] dpps dpps)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    string userIDi = HttpContext.Session.GetString("UserID");
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    dpps.Psemployer = dpps.Psemployer;
                    dpps.FrmDate = dpps.FrmDate;
                    dpps.ToDate = dpps.ToDate;
                    dpps.SprpNo = sprpNo;
                    dpps.FilePageRef = dpps.FilePageRef;
                    dpps.Checkedby = userIDi;
                    dpps.Status = "No";
                    _context.Add(dpps);
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
                        string userIDi = HttpContext.Session.GetString("UserID");
                        string statu = HttpContext.Session.GetString("status");
                        dpps.Psemployer = dpps.Psemployer;
                        dpps.FrmDate = dpps.FrmDate;
                        dpps.ToDate = dpps.ToDate;
                        dpps.SprpNo = sprpNo;
                        dpps.FilePageRef = dpps.FilePageRef;
                        dpps.Checkedby = userIDi;
                        dpps.Status = statu;

                        _context.Update(dpps);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!dppsExists(dpps.Id))
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
                string userID = HttpContext.Session.GetString("UserID");


                var dp = (from s in _context.dpps where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", dpps) });
        }

        // GET: dpps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dpps = await _context.dpps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dpps == null)
            {
                return NotFound();
            }

            return View(dpps);
        }

        // POST: dpps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dpps = await _context.dpps.FindAsync(id);
            if (dpps.Status=="No")
            { 
            _context.dpps.Remove(dpps);
            await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");


            var dp = (from s in _context.dpps where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
        }

        private bool dppsExists(int id)
        {
            return _context.dpps.Any(e => e.Id == id);
        }
    }
}
