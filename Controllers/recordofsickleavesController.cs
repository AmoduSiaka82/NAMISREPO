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
    public class recordofsickleavesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public recordofsickleavesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: recordofsickleaves
        public async Task<IActionResult> Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var recordofsickleave = (from s in _context.recordofsickleaves where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") select s);
            return View(await recordofsickleave.ToListAsync());
        }

        // GET: recordofsickleaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordofsickleaves = await _context.recordofsickleaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordofsickleaves == null)
            {
                return NotFound();
            }

            return View(recordofsickleaves);
        }

        // GET: recordofsickleaves/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
           
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new recordofsickleaves());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var recordofsickleave = await _context.recordofsickleaves.FindAsync(id);


                if (recordofsickleave.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(recordofsickleave);
            }
        }


        // POST: recordofsickleaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfLeave,FrmDate,ToDate,NoOfDays,Date,FilePageNo,Dates,SprpNo,Id,Status")] recordofsickleaves recordofsickleaves)
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
             
                recordofsickleaves.TypeOfLeave = recordofsickleaves.TypeOfLeave;
                recordofsickleaves.FrmDate = recordofsickleaves.FrmDate;
                recordofsickleaves.ToDate = recordofsickleaves.ToDate;
                recordofsickleaves.NoOfDays = recordofsickleaves.NoOfDays;
                recordofsickleaves.Date = DateTime.UtcNow.Date;
                recordofsickleaves.Dates = dates;
                recordofsickleaves.FilePageNo = recordofsickleaves.FilePageNo;
                recordofsickleaves.SprpNo = sprpNo;
                recordofsickleaves.Status = "No";
                _context.Add(recordofsickleaves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordofsickleaves);
        }

        // GET: recordofsickleaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var recordofsickleaves = await _context.recordofsickleaves.FindAsync(id);
            if (recordofsickleaves == null)
            {
                return NotFound();
            }
            return View(recordofsickleaves);
        }

        // POST: recordofsickleaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("TypeOfLeave,FrmDate,ToDate,NoOfDays,Date,FilePageNo,Dates,SprpNo,Id,Status")] recordofsickleaves recordofsickleaves)
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

                    recordofsickleaves.TypeOfLeave = recordofsickleaves.TypeOfLeave;
                    recordofsickleaves.FrmDate = recordofsickleaves.FrmDate;
                    recordofsickleaves.ToDate = recordofsickleaves.ToDate;
                    recordofsickleaves.NoOfDays = recordofsickleaves.NoOfDays;
                    recordofsickleaves.Date = DateTime.UtcNow.Date;
                    recordofsickleaves.Dates = dates;
                    recordofsickleaves.FilePageNo = recordofsickleaves.FilePageNo;
                    recordofsickleaves.SprpNo = sprpNo;
                    recordofsickleaves.Status = "No";
                    _context.Add(recordofsickleaves);
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

                        recordofsickleaves.TypeOfLeave = recordofsickleaves.TypeOfLeave;
                        recordofsickleaves.FrmDate = recordofsickleaves.FrmDate;
                        recordofsickleaves.ToDate = recordofsickleaves.ToDate;
                        recordofsickleaves.NoOfDays = recordofsickleaves.NoOfDays;
                        recordofsickleaves.Date = DateTime.UtcNow.Date;
                        recordofsickleaves.Dates = dates;
                        recordofsickleaves.FilePageNo = recordofsickleaves.FilePageNo;
                        recordofsickleaves.SprpNo = sprpNo;
                        recordofsickleaves.Status = statu;

                        _context.Update(recordofsickleaves);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!recordofsickleavesExists(recordofsickleaves.Id))
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
                var nx = (from s in _context.recordofsickleaves where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", recordofsickleaves) });
           
        }

        // GET: recordofsickleaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordofsickleaves = await _context.recordofsickleaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordofsickleaves == null)
            {
                return NotFound();
            }

            return View(recordofsickleaves);
        }

        // POST: recordofsickleaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordofsickleaves = await _context.recordofsickleaves.FindAsync(id);
            if (recordofsickleaves.Status == "No")
            {
                _context.recordofsickleaves.Remove(recordofsickleaves);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.recordofsickleaves where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool recordofsickleavesExists(int id)
        {
            return _context.recordofsickleaves.Any(e => e.Id == id);
        }
    }
}
