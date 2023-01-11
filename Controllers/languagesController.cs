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
    public class languagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public languagesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
      

        // GET: languages
        public async Task<IActionResult> Index()
        {
          
            
            string sprpNos = HttpContext.Session.GetString("SPRP");
           
            string userIDs = HttpContext.Session.GetString("UserID");
            var language = (from s in _context.languages where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await _context.languages.ToListAsync());
        }

        // GET: languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.languages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // GET: languages/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (id == 0)
            {
                return View(new languages());
            }
            else
            {
                var languages = await _context.languages.FindAsync(id);
                if (languages == null)
                {
                    return NotFound();
                }
                if (languages.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(languages);
            }
        }

        // POST: languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Language,Spoken,Written,ExamQualified,CheckedBy,Dates,Date,Status,ID,SprpNo")] languages languages)
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
                languages.CheckedBy = usId;
                languages.Date = DateTime.UtcNow.Date;
                languages.Dates = dates;
                languages.SprpNo = sprpNo;
                languages.Status = "No";
                _context.Add(languages);
                await _context.SaveChangesAsync();
                
                    
                return RedirectToAction(nameof(Index));
            }
            return View(languages);
        }

        // GET: languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.languages.FindAsync(id);
            if (languages == null)
            {
                return NotFound();
            }
            return View(languages);
        }

        // POST: languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Language,Spoken,Written,ExamQualified,CheckedBy,Dates,Date,Status,ID,SprpNo")] languages languages)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (id != languages.ID)
            {
                return NotFound();
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
                    languages.CheckedBy = usId;
                    languages.Date = DateTime.UtcNow.Date;
                    languages.Dates = dates;
                    languages.SprpNo = sprpNo;
                    languages.Status = "No";
                    _context.Add(languages);
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
                        string usId = HttpContext.Session.GetString("UserID");
                        string statu = HttpContext.Session.GetString("status");
                        languages.CheckedBy = usId;
                        languages.Date = DateTime.UtcNow.Date;
                        languages.Dates = dates;
                        languages.SprpNo = sprpNo;
                        languages.Status = statu;

                        _context.Update(languages);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!languagesExists(languages.ID))
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
                var lg = (from s in _context.languages where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy==userIDs select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", lg.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", languages) });
        }

        // GET: languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.languages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // POST: languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languages = await _context.languages.FindAsync(id);
            if (languages.Status == "No")
            {
                _context.languages.Remove(languages);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var lg = (from s in _context.languages where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userIDs select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", lg.ToList()) });
        }

        private bool languagesExists(int id)
        {
            return _context.languages.Any(e => e.ID == id);
        }
    }
}
