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
    public class byresignationorinvalidatingsController : Controller
    {
        

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public byresignationorinvalidatingsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        // GET: byresignationorinvalidatings
        public async Task<IActionResult> Index()
        {
            
            string sprpNo = HttpContext.Session.GetString("SPRP");

            var byresignationorinvalidating = (from s in _context.byresignationorinvalidating where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") select s);
            return View(await byresignationorinvalidating.ToListAsync());
        }

        // GET: byresignationorinvalidatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var byresignationorinvalidating = await _context.byresignationorinvalidating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (byresignationorinvalidating == null)
            {
                return NotFound();
            }

            return View(byresignationorinvalidating);
        }

        // GET: byresignationorinvalidatings/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
         
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new byresignationorinvalidating());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var byresignationorinvalidatin= await _context.byresignationorinvalidating.FindAsync(id);


                if (byresignationorinvalidatin.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(byresignationorinvalidatin);
            }
        }


        // POST: byresignationorinvalidatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateTerminated,PensionOrContarct,PensionOf,GrantuityOf,ContractGratuity,Date,Dates,Status,SprpNo,Id")] byresignationorinvalidating byresignationorinvalidating)
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
                byresignationorinvalidating.DateTerminated = byresignationorinvalidating.DateTerminated;
                byresignationorinvalidating.PensionOrContarct = byresignationorinvalidating.PensionOrContarct;
                byresignationorinvalidating.PensionOf = byresignationorinvalidating.PensionOf;
                byresignationorinvalidating.GrantuityOf = byresignationorinvalidating.GrantuityOf;
                byresignationorinvalidating.ContractGratuity = byresignationorinvalidating.ContractGratuity;
                byresignationorinvalidating.Date = DateTime.UtcNow.Date;
                byresignationorinvalidating.Dates = dates;
                byresignationorinvalidating.Status = "No";
                byresignationorinvalidating.SprpNo = sprpNo;
                _context.Add(byresignationorinvalidating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(byresignationorinvalidating);
        }

        // GET: byresignationorinvalidatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var byresignationorinvalidating = await _context.byresignationorinvalidating.FindAsync(id);
            if (byresignationorinvalidating == null)
            {
                return NotFound();
            }
            return View(byresignationorinvalidating);
        }

        // POST: byresignationorinvalidatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateTerminated,PensionOrContarct,PensionOf,GrantuityOf,ContractGratuity,Date,Dates,Status,SprpNo,Id")] byresignationorinvalidating byresignationorinvalidating)
        {
            
            if (id != byresignationorinvalidating.Id)
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
                    byresignationorinvalidating.DateTerminated = byresignationorinvalidating.DateTerminated;
                    byresignationorinvalidating.PensionOrContarct = byresignationorinvalidating.PensionOrContarct;
                    byresignationorinvalidating.PensionOf = byresignationorinvalidating.PensionOf;
                    byresignationorinvalidating.GrantuityOf = byresignationorinvalidating.GrantuityOf;
                    byresignationorinvalidating.ContractGratuity = byresignationorinvalidating.ContractGratuity;
                    byresignationorinvalidating.Date = DateTime.UtcNow.Date;
                    byresignationorinvalidating.Dates = dates;
                    byresignationorinvalidating.Status = "No";
                    byresignationorinvalidating.SprpNo = sprpNo;
                    _context.Add(byresignationorinvalidating);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        //var byresignationorinvalidatin = await _context.byresignationorinvalidating.FindAsync(id);
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string statu = HttpContext.Session.GetString("status");
                        byresignationorinvalidating.DateTerminated = byresignationorinvalidating.DateTerminated;
                        byresignationorinvalidating.PensionOrContarct = byresignationorinvalidating.PensionOrContarct;
                        byresignationorinvalidating.PensionOf = byresignationorinvalidating.PensionOf;
                        byresignationorinvalidating.GrantuityOf = byresignationorinvalidating.GrantuityOf;
                        byresignationorinvalidating.ContractGratuity = byresignationorinvalidating.ContractGratuity;
                        byresignationorinvalidating.Date = DateTime.UtcNow.Date;
                        byresignationorinvalidating.Dates = dates;
                        byresignationorinvalidating.Status = statu;
                        byresignationorinvalidating.SprpNo = sprpNo;
                        _context.Update(byresignationorinvalidating);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!byresignationorinvalidatingExists(byresignationorinvalidating.Id))
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
                var nx = (from s in _context.byresignationorinvalidating where  s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", byresignationorinvalidating) });
       
        }

        // GET: byresignationorinvalidatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var byresignationorinvalidating = await _context.byresignationorinvalidating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (byresignationorinvalidating == null)
            {
                return NotFound();
            }

            return View(byresignationorinvalidating);
        }

        // POST: byresignationorinvalidatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var byresignationorinvalidating = await _context.byresignationorinvalidating.FindAsync(id);
            if (byresignationorinvalidating.Status == "No")
            {
                _context.byresignationorinvalidating.Remove(byresignationorinvalidating);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.byresignationorinvalidating where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool byresignationorinvalidatingExists(int id)
        {
            return _context.byresignationorinvalidating.Any(e => e.Id == id);
        }
    }
}
