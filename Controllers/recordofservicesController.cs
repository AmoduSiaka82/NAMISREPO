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
    public class recordofservicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public recordofservicesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: recordofservices
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var recordofservice = (from s in _context.recordofservice where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedByAndStamp == userID select s);
            return View(await recordofservice.ToListAsync());
        }

        // GET: recordofservices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var recordofservice = await _context.recordofservice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recordofservice == null)
            {
                return NotFound();
            }

            return View(recordofservice);
        }

        // GET: recordofservices/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new recordofservice());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var recordofservice = await _context.recordofservice.FindAsync(id);


                if (recordofservice.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(recordofservice);
            }
        }

        // POST: recordofservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfEntery,Detail,Signature,CheckedByAndStamp,SprpNo,ID")] recordofservice recordofservice)
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
                string usId = HttpContext.Session.GetString("UserID");
                recordofservice.CheckedByAndStamp = usId;
                recordofservice.DateOfEntery = recordofservice.DateOfEntery;
                recordofservice.Detail = recordofservice.Detail;
                recordofservice.Signature = recordofservice.Signature;
                
                recordofservice.Dates = dates;
                recordofservice.Status = "No";
                recordofservice.SprpNo = sprpNo;
                _context.Add(recordofservice);
                await _context.SaveChangesAsync();
               
                    return RedirectToAction(nameof(Index));
            }
            return View(recordofservice);
        }

        // GET: recordofservices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var recordofservice = await _context.recordofservice.FindAsync(id);
            if (recordofservice == null)
            {
                return NotFound();
            }
            return View(recordofservice);
        }

        // POST: recordofservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateOfEntery,Detail,Signature,CheckedByAndStamp,SprpNo,ID")] recordofservice recordofservice)
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
                    string usId = HttpContext.Session.GetString("UserID");
                    recordofservice.CheckedByAndStamp = usId;
                    recordofservice.DateOfEntery = recordofservice.DateOfEntery;
                    recordofservice.Detail = recordofservice.Detail;
                    recordofservice.Signature = recordofservice.Signature;

                    recordofservice.Dates = dates;
                    recordofservice.Status = "No";
                    recordofservice.SprpNo = sprpNo;
                    _context.Add(recordofservice);
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
                        string usId = HttpContext.Session.GetString("UserID");
                        recordofservice.CheckedByAndStamp = usId;
                        recordofservice.DateOfEntery = recordofservice.DateOfEntery;
                        recordofservice.Detail = recordofservice.Detail;
                        recordofservice.Signature = recordofservice.Signature;

                        recordofservice.Dates = dates;
                        recordofservice.Status = statu;
                        recordofservice.SprpNo = sprpNo;
                        _context.Update(recordofservice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!recordofserviceExists(recordofservice.ID))
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
                var nx = (from s in _context.recordofservice where  s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", recordofservice) });
            
        }

        // GET: recordofservices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordofservice = await _context.recordofservice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recordofservice == null)
            {
                return NotFound();
            }

            return View(recordofservice);
        }

        // POST: recordofservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordofservice = await _context.recordofservice.FindAsync(id);
            if (recordofservice.Status == "No")
            {
                _context.recordofservice.Remove(recordofservice);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.recordofservice where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool recordofserviceExists(int id)
        {
            return _context.recordofservice.Any(e => e.ID == id);
        }
    }
}
