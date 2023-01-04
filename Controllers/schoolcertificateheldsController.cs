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
    public class schoolcertificateheldsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public schoolcertificateheldsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: schoolcertificatehelds
        public async Task<IActionResult> Index()
        {
          
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var schoolcertificatehelds = (from s in _context.schoolcertificatehelds where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);
            return View(await schoolcertificatehelds.ToListAsync());
        }

        // GET: schoolcertificatehelds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolcertificatehelds = await _context.schoolcertificatehelds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolcertificatehelds == null)
            {
                return NotFound();
            }

            return View(schoolcertificatehelds);
        }

        // GET: schoolcertificatehelds/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            
            if (id == 0)
            {
                return View(new schoolcertificatehelds());
            }
            else
            {
                var schoolcertificatehelds = await _context.schoolcertificatehelds.FindAsync(id);
                if (schoolcertificatehelds == null)
                {
                    return NotFound();
                }
              
                if (schoolcertificatehelds.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(schoolcertificatehelds);
            }
        }

        // POST: schoolcertificatehelds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("schoolcertificateheld,CheckedBy,Date,Dates,Status,SprpNo,Id")] schoolcertificatehelds schoolcertificatehelds)
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
                schoolcertificatehelds.schoolcertificateheld = schoolcertificatehelds.schoolcertificateheld;
                schoolcertificatehelds.CheckedBy = userID;
                schoolcertificatehelds.Date = DateTime.UtcNow.Date;
                schoolcertificatehelds.Dates = dates;
                schoolcertificatehelds.Status = "No";
                schoolcertificatehelds.SprpNo = sprpNo;
                _context.Add(schoolcertificatehelds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolcertificatehelds);
        }

        // GET: schoolcertificatehelds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var schoolcertificatehelds = await _context.schoolcertificatehelds.FindAsync(id);
            if (schoolcertificatehelds == null)
            {
                return NotFound();
            }
            return View(schoolcertificatehelds);
        }

        // POST: schoolcertificatehelds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("schoolcertificateheld,CheckedBy,Date,Dates,Status,SprpNo,Id")] schoolcertificatehelds schoolcertificatehelds)
        {
           
            

            if (ModelState.IsValid)
            {
               
                   if (id==0)
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
                    schoolcertificatehelds.schoolcertificateheld = schoolcertificatehelds.schoolcertificateheld;
                    schoolcertificatehelds.CheckedBy = userID;
                    schoolcertificatehelds.Date = DateTime.UtcNow.Date;
                    schoolcertificatehelds.Dates = dates;
                    schoolcertificatehelds.Status = "No";
                    schoolcertificatehelds.SprpNo = sprpNo;
                    _context.Add(schoolcertificatehelds);
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
                        string userID = HttpContext.Session.GetString("UserID");
                        string statu = HttpContext.Session.GetString("status");
                        schoolcertificatehelds.schoolcertificateheld = schoolcertificatehelds.schoolcertificateheld;
                        schoolcertificatehelds.CheckedBy = userID;
                        schoolcertificatehelds.Date = DateTime.UtcNow.Date;
                        schoolcertificatehelds.Dates = dates;
                        schoolcertificatehelds.Status = statu;
                        schoolcertificatehelds.SprpNo = sprpNo;
                        _context.Update(schoolcertificatehelds);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!schoolcertificateheldsExists(schoolcertificatehelds.Id))
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
                var dp = (from s in _context.schoolcertificatehelds where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", schoolcertificatehelds) });
        }

        // GET: schoolcertificatehelds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolcertificatehelds = await _context.schoolcertificatehelds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolcertificatehelds == null)
            {
                return NotFound();
            }

            return View(schoolcertificatehelds);
        }

        // POST: schoolcertificatehelds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolcertificatehelds = await _context.schoolcertificatehelds.FindAsync(id);
            if (schoolcertificatehelds.Status == "No")
            {
                _context.schoolcertificatehelds.Remove(schoolcertificatehelds);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var dp = (from s in _context.schoolcertificatehelds where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", dp.ToList()) });
        }

        private bool schoolcertificateheldsExists(int id)
        {
            return _context.schoolcertificatehelds.Any(e => e.Id == id);
        }
    }
}
