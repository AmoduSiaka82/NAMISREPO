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
    public class recordofemolumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public recordofemolumentsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: recordofemoluments
        public async Task<IActionResult> Index()
        {
          
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var recordofemolument = (from s in _context.recordofemolument where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await recordofemolument.ToListAsync());
        }

        // GET: recordofemoluments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordofemolument = await _context.recordofemolument
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recordofemolument == null)
            {
                return NotFound();
            }

            return View(recordofemolument);
        }

        // GET: recordofemoluments/Create
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
                return View(new recordofemolument());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var recordofemolument = await _context.recordofemolument.FindAsync(id);


                if (recordofemolument.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(recordofemolument);
            }
        }

        // POST: recordofemoluments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfEntery,SalaryScale,BasicSalaryPA,InducementPayPA,DatePaidFrm,IncriminisDateM,IncriminisDateYr,Authority,Signature,NameAndStamp,Dates,Status,SprpNo,ID")] recordofemolument recordofemolument)
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
                
                 recordofemolument.DateOfEntery=   recordofemolument.DateOfEntery;
                recordofemolument.SalaryScale = recordofemolument.SalaryScale;
                recordofemolument.BasicSalaryPA = recordofemolument.BasicSalaryPA;
                recordofemolument.InducementPayPA = recordofemolument.InducementPayPA;
                recordofemolument.DatePaidFrm = recordofemolument.DatePaidFrm;
                recordofemolument.IncriminisDateM = recordofemolument.IncriminisDateM;
                recordofemolument.IncriminisDateYr = recordofemolument.IncriminisDateYr;
                recordofemolument.Authority = recordofemolument.Authority;
                recordofemolument.Signature = recordofemolument.Signature;
                recordofemolument.NameAndStamp = recordofemolument.NameAndStamp;
                recordofemolument.Status = "No";
                recordofemolument.Dates = dates;
                recordofemolument.SprpNo = sprpNo;

                _context.Add(recordofemolument);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "registers");
            }
            return View(recordofemolument);
        }

        // GET: recordofemoluments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var recordofemolument = await _context.recordofemolument.FindAsync(id);
            if (recordofemolument == null)
            {
                return NotFound();
            }
            return View(recordofemolument);
        }

        // POST: recordofemoluments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateOfEntery,SalaryScale,BasicSalaryPA,InducementPayPA,DatePaidFrm,IncriminisDateM,IncriminisDateYr,Authority,Signature,NameAndStamp,Dates,Status,SprpNo,ID")] recordofemolument recordofemolument)
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

                    recordofemolument.DateOfEntery = recordofemolument.DateOfEntery;
                    recordofemolument.SalaryScale = recordofemolument.SalaryScale;
                    recordofemolument.BasicSalaryPA = recordofemolument.BasicSalaryPA;
                    recordofemolument.InducementPayPA = recordofemolument.InducementPayPA;
                    recordofemolument.DatePaidFrm = recordofemolument.DatePaidFrm;
                    recordofemolument.IncriminisDateM = recordofemolument.IncriminisDateM;
                    recordofemolument.IncriminisDateYr = recordofemolument.IncriminisDateYr;
                    recordofemolument.Authority = recordofemolument.Authority;
                    recordofemolument.Signature = recordofemolument.Signature;
                    recordofemolument.NameAndStamp = recordofemolument.NameAndStamp;
                    recordofemolument.Status = "No";
                    recordofemolument.Dates = dates;
                    recordofemolument.SprpNo = sprpNo;

                    _context.Add(recordofemolument);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string statu = HttpContext.Session.GetString("status");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                        recordofemolument.DateOfEntery = recordofemolument.DateOfEntery;
                        recordofemolument.SalaryScale = recordofemolument.SalaryScale;
                        recordofemolument.BasicSalaryPA = recordofemolument.BasicSalaryPA;
                        recordofemolument.InducementPayPA = recordofemolument.InducementPayPA;
                        recordofemolument.DatePaidFrm = recordofemolument.DatePaidFrm;
                        recordofemolument.IncriminisDateM = recordofemolument.IncriminisDateM;
                        recordofemolument.IncriminisDateYr = recordofemolument.IncriminisDateYr;
                        recordofemolument.Authority = recordofemolument.Authority;
                        recordofemolument.Signature = recordofemolument.Signature;
                        recordofemolument.NameAndStamp = recordofemolument.NameAndStamp;
                        recordofemolument.Status = statu;
                        recordofemolument.Dates = dates;
                        recordofemolument.SprpNo = sprpNo;
                        _context.Update(recordofemolument);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!recordofemolumentExists(recordofemolument.ID))
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
                var nx = (from s in _context.recordofemolument where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", recordofemolument) });
            
        }

        // GET: recordofemoluments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordofemolument = await _context.recordofemolument
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recordofemolument == null)
            {
                return NotFound();
            }

            return View(recordofemolument);
        }

        // POST: recordofemoluments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordofemolument = await _context.recordofemolument.FindAsync(id);
            if (recordofemolument.Status == "No")
            {
                _context.recordofemolument.Remove(recordofemolument);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.recordofemolument where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool recordofemolumentExists(int id)
        {
            return _context.recordofemolument.Any(e => e.ID == id);
        }
        [HttpPost]
        public IActionResult Submitting(int id = 0)
        {
           
            return RedirectToAction("Index", "Summaries");
        }
    }
}
