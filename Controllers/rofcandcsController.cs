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
    public class rofcandcsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public rofcandcsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: rofcandcs
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var rofcandc = (from s in _context.rofcandcs where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CompiledBy == userID select s);
            return View(await rofcandc.ToListAsync());
        }

        // GET: rofcandcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rofcandcs = await _context.rofcandcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rofcandcs == null)
            {
                return NotFound();
            }

            return View(rofcandcs);
        }

        // GET: rofcandcs/Create
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
                return View(new rofcandcs());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var rofcandc = await _context.rofcandcs.FindAsync(id);


                if (rofcandc.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(rofcandc);
            }
        }

        // POST: rofcandcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Summary,CompiledBy,Date,Dates,SprpNo,Status,Id")] rofcandcs rofcandcs)
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
           
                rofcandcs.Summary = rofcandcs.Summary;
                string usId = HttpContext.Session.GetString("UserID");

                rofcandcs.CompiledBy = usId;
                rofcandcs.Date = DateTime.UtcNow.Date;
                rofcandcs.Dates = date;
                rofcandcs.SprpNo = sprpNo;
                rofcandcs.Status = "No";
                _context.Add(rofcandcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rofcandcs);
        }

        // GET: rofcandcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var rofcandcs = await _context.rofcandcs.FindAsync(id);
            if (rofcandcs == null)
            {
                return NotFound();
            }
            return View(rofcandcs);
        }

        // POST: rofcandcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Summary,CompiledBy,Date,Dates,SprpNo,Status,Id")] rofcandcs rofcandcs)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }

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

                    rofcandcs.Summary = rofcandcs.Summary;
                    string usId = HttpContext.Session.GetString("UserID");

                    rofcandcs.CompiledBy = usId;
                    rofcandcs.Date = DateTime.UtcNow.Date;
                    rofcandcs.Dates = date;
                    rofcandcs.SprpNo = sprpNo;
                    rofcandcs.Status = "No";
                    _context.Add(rofcandcs);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                        rofcandcs.Summary = rofcandcs.Summary;
                        string usId = HttpContext.Session.GetString("UserID");

                        rofcandcs.CompiledBy = usId;
                        rofcandcs.Date = DateTime.UtcNow.Date;
                        rofcandcs.Dates = date;
                        rofcandcs.SprpNo = sprpNo;
                        rofcandcs.Status = "No";

                        _context.Update(rofcandcs);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!rofcandcsExists(rofcandcs.Id))
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
                var nx = (from s in _context.rofcandcs where s.CompiledBy==userIDs && s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", rofcandcs) });
           
        }

        // GET: rofcandcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rofcandcs = await _context.rofcandcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rofcandcs == null)
            {
                return NotFound();
            }

            return View(rofcandcs);
        }

        // POST: rofcandcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
                var rofcandcs = await _context.rofcandcs.FindAsync(id);
            if (rofcandcs.Status == "No")
            {
                _context.rofcandcs.Remove(rofcandcs);

                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.rofcandcs where s.CompiledBy == userIDs && s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool rofcandcsExists(int id)
        {
            return _context.rofcandcs.Any(e => e.Id == id);
        }
    }
}
