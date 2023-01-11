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
    public class educationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public educationsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
       

        // GET: educations
        public async Task<IActionResult> Index()
        {
          
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var education = (from s in _context.educations where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);
            return View(await education.ToListAsync());
        }

        // GET: educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.educations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // GET: educations/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (id == 0)
            {
                return View(new educations());
            }
            else
            {
                var educations = await _context.educations.FindAsync(id);
                if (educations == null)
                {
                    return NotFound();
                }
                if (educations.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(educations);
            }
        }

        // POST: educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfSchool,FrmDate,ToDate,CheckedBy,Dates,Date,Status,Id,SprpNo")] educations educations)
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
                string usId = HttpContext.Session.GetString("UserID");
                educations.CheckedBy = usId;
                educations.TypeOfSchool = educations.TypeOfSchool;
                educations.FrmDate = educations.FrmDate;
                educations.ToDate = educations.ToDate;
                
                educations.Date = DateTime.UtcNow.Date;
                educations.Dates = dates;
                educations.Status = "No";
                educations.SprpNo = sprpNo;
                _context.Add(educations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educations);
        }

        // GET: educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.educations.FindAsync(id);
            if (educations == null)
            {
                return NotFound();
            }
            return View(educations);
        }

        // POST: educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("TypeOfSchool,FrmDate,ToDate,CheckedBy,Dates,Date,Status,Id,SprpNo")] educations educations)
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
                    string usId = HttpContext.Session.GetString("UserID");
                    educations.CheckedBy = usId;
                    educations.TypeOfSchool = educations.TypeOfSchool;
                    educations.FrmDate = educations.FrmDate;
                    educations.ToDate = educations.ToDate;

                    educations.Date = DateTime.UtcNow.Date;
                    educations.Dates = dates;
                    educations.Status = "No";
                    educations.SprpNo = sprpNo;
                    _context.Add(educations);
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
                        string usId = HttpContext.Session.GetString("UserID");
                        educations.CheckedBy = usId;
                        educations.TypeOfSchool = educations.TypeOfSchool;
                        educations.FrmDate = educations.FrmDate;
                        educations.ToDate = educations.ToDate;

                        educations.Date = DateTime.UtcNow.Date;
                        educations.Dates = dates;
                        educations.Status = statu;
                        educations.SprpNo = sprpNo;

                        _context.Update(educations);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!educationsExists(educations.Id))
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
                var educationing = (from s in _context.educations where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", educationing.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", educations) });

        }

        // GET: educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.educations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // POST: educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educations = await _context.educations.FindAsync(id);
            if (educations.Status == "No")
            {
                _context.educations.Remove(educations);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var educationing = (from s in _context.educations where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", educationing.ToList()) });
        }

        private bool educationsExists(int id)
        {
            return _context.educations.Any(e => e.Id == id);
        }
    }
}
