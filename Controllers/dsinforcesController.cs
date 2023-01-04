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
    public class dsinforcesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public dsinforcesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
       

        // GET: dsinforces
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");

            var dsinforce = (from s in _context.dsinforce where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await dsinforce.ToListAsync());
        }

        // GET: dsinforces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dsinforce = await _context.dsinforce
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dsinforce == null)
            {
                return NotFound();
            }

            return View(dsinforce);
        }

        // GET: dsinforces/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
           
            if (id == 0)
            {
                return View(new dsinforce());
            }
            else
            {
                var dsinforce = await _context.dsinforce.FindAsync(id);
                if (dsinforce == null)
                {
                    return NotFound();
                }
                if (dsinforce.Status=="Ëditting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(dsinforce);
            }
        }

        // POST: dsinforces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArmOfService,ServiceNo,ReasonForLeave,LastUnit,Date,Dates,Status,SprpNo,ID")] dsinforce dsinforce)
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
                dsinforce.ArmOfService = dsinforce.ArmOfService;
                dsinforce.ServiceNo = dsinforce.ServiceNo;
                dsinforce.ReasonForLeave = dsinforce.ReasonForLeave;
                dsinforce.LastUnit = dsinforce.LastUnit;
                dsinforce.Date = DateTime.UtcNow.Date;
                dsinforce.Dates = dates;
                dsinforce.Status = "No";
                dsinforce.SprpNo = sprpNo;
                _context.Add(dsinforce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dsinforce);
        }

        // GET: dsinforces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var dsinforce = await _context.dsinforce.FindAsync(id);
            if (dsinforce == null)
            {
                return NotFound();
            }
            return View(dsinforce);
        }

        // POST: dsinforces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("ArmOfService,ServiceNo,ReasonForLeave,LastUnit,SprpNo,ID")] dsinforce dsinforce)
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
                    dsinforce.ArmOfService = dsinforce.ArmOfService;
                    dsinforce.ServiceNo = dsinforce.ServiceNo;
                    dsinforce.ReasonForLeave = dsinforce.ReasonForLeave;
                    dsinforce.LastUnit = dsinforce.LastUnit;
                    dsinforce.Date = DateTime.UtcNow.Date;
                    dsinforce.Dates = dates;
                    dsinforce.Status = "No";
                    dsinforce.SprpNo = sprpNo;
                    _context.Add(dsinforce);
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
                        dsinforce.ArmOfService = dsinforce.ArmOfService;
                        dsinforce.ServiceNo = dsinforce.ServiceNo;
                        dsinforce.ReasonForLeave = dsinforce.ReasonForLeave;
                        dsinforce.LastUnit = dsinforce.LastUnit;
                        dsinforce.Date = DateTime.UtcNow.Date;
                        dsinforce.Dates = dates;
                        dsinforce.Status = statu;
                        dsinforce.SprpNo = sprpNo;
                        _context.Update(dsinforce);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!dsinforceExists(dsinforce.ID))
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


                var df = (from s in _context.dsinforce where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting")  select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", df.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", dsinforce) });
        }

        // GET: dsinforces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dsinforce = await _context.dsinforce
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dsinforce == null)
            {
                return NotFound();
            }

            return View(dsinforce);
        }

        // POST: dsinforces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dsinforce = await _context.dsinforce.FindAsync(id);
            if (dsinforce.Status == "No")
            {
                _context.dsinforce.Remove(dsinforce);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");


            var df = (from s in _context.dsinforce where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", df.ToList()) });
        }

        private bool dsinforceExists(int id)
        {
            return _context.dsinforce.Any(e => e.ID == id);
        }
    }
}
