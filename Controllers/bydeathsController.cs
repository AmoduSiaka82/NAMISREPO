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
    public class bydeathsController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
     
        public bydeathsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: bydeaths
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");

            var bydeath = (from s in _context.bydeaths where s.SprpNo == sprpNo && (s.Status=="No" || s.Status == "Editting")  select s);
            return View(await bydeath.ToListAsync());
        }

        // GET: bydeaths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bydeaths = await _context.bydeaths
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bydeaths == null)
            {
                return NotFound();
            }

            return View(bydeaths);
        }

        // GET: bydeaths/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new bydeaths());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var bydeath = await _context.bydeaths.FindAsync(id);


                if (bydeath.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(bydeath);
            }
        }
        // POST: bydeaths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfDeath,GratuityPaidToEstate,WindowsPensionPaid,OrphansPensionPaid,Date,Dates,Status,SprpNo,ID")] bydeaths bydeaths)
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
                bydeaths.DateOfDeath = bydeaths.DateOfDeath;
                bydeaths.GratuityPaidToEstate = bydeaths.GratuityPaidToEstate;
                bydeaths.WindowsPensionPaid = bydeaths.WindowsPensionPaid;
                bydeaths.OrphansPensionPaid = bydeaths.OrphansPensionPaid;
                bydeaths.Date = DateTime.UtcNow.Date;
                bydeaths.Dates = dates;
                bydeaths.Status = "No";
                bydeaths.SprpNo = sprpNo;
                    _context.Add(bydeaths);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bydeaths);
        }

        // GET: bydeaths/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var bydeaths = await _context.bydeaths.FindAsync(id);
            if (bydeaths == null)
            {
                return NotFound();
            }
            return View(bydeaths);
        }

        // POST: bydeaths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateOfDeath,GratuityPaidToEstate,WindowsPensionPaid,OrphansPensionPaid,Date,Dates,Status,SprpNo,ID")] bydeaths bydeaths)
        {
         
           

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
                    bydeaths.DateOfDeath = bydeaths.DateOfDeath;
                    bydeaths.GratuityPaidToEstate = bydeaths.GratuityPaidToEstate;
                    bydeaths.WindowsPensionPaid = bydeaths.WindowsPensionPaid;
                    bydeaths.OrphansPensionPaid = bydeaths.OrphansPensionPaid;
                    bydeaths.Date = DateTime.UtcNow.Date;
                    bydeaths.Dates = dates;
                    bydeaths.Status = "No";
                    bydeaths.SprpNo = sprpNo;
                    _context.Add(bydeaths);
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
                        bydeaths.DateOfDeath = bydeaths.DateOfDeath;
                        bydeaths.GratuityPaidToEstate = bydeaths.GratuityPaidToEstate;
                        bydeaths.WindowsPensionPaid = bydeaths.WindowsPensionPaid;
                        bydeaths.OrphansPensionPaid = bydeaths.OrphansPensionPaid;
                        bydeaths.Date = DateTime.UtcNow.Date;
                        bydeaths.Dates = dates;
                        bydeaths.Status = statu;
                        bydeaths.SprpNo = sprpNo;
                        _context.Update(bydeaths);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!bydeathsExists(bydeaths.ID))
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
                var nx = (from s in _context.bydeaths where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", bydeaths) });
           
        }

        // GET: bydeaths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
        
            if (id == null)
            {
                return NotFound();
            }

            var bydeaths = await _context.bydeaths
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bydeaths == null)
            {
                return NotFound();
            }

            return View(bydeaths);
        }

        // POST: bydeaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        
            var bydeaths = await _context.bydeaths.FindAsync(id);
            if (bydeaths.Status == "No")
            {
                _context.bydeaths.Remove(bydeaths);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.bydeaths where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool bydeathsExists(int id)
        {
            return _context.bydeaths.Any(e => e.ID == id);
        }
    }
}
