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
    public class bytransfersController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public bytransfersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        // GET: bytransfers
        public async Task<IActionResult> Index()
        {
            string sprpNo = HttpContext.Session.GetString("SPRP");

            var bytransfer = (from s in _context.bytransfers where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await bytransfer.ToListAsync());
        }

        // GET: bytransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bytransfers = await _context.bytransfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bytransfers == null)
            {
                return NotFound();
            }

            return View(bytransfers);
        }

        // GET: bytransfers/Create
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
                return View(new bytransfers());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var bytransfer = await _context.bytransfers.FindAsync(id);


                if (bytransfer.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(bytransfer);
            }
        }

        // POST: bytransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateOfTransfer,PensionOrContarct,AggregateServiceInNigeriaYrs,AggregateServiceInNigeriaMos,AggregateServiceInNigeriaDays,AggregateSalaryInNigeria,Status,Date,Dates,SprpNo,Id")] bytransfers bytransfers)
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
                string sprpNo = HttpContext.Session.GetString("SPRP"); bytransfers.DateOfTransfer = bytransfers.DateOfTransfer;
                bytransfers.PensionOrContarct = bytransfers.PensionOrContarct;
                bytransfers.AggregateServiceInNigeriaYrs = bytransfers.AggregateServiceInNigeriaYrs;
                bytransfers.AggregateServiceInNigeriaMos = bytransfers.AggregateServiceInNigeriaMos;
                bytransfers.AggregateServiceInNigeriaDays = bytransfers.AggregateServiceInNigeriaDays;
                bytransfers.AggregateSalaryInNigeria = bytransfers.AggregateSalaryInNigeria;
                bytransfers.Status = "No";
                bytransfers.Date = DateTime.UtcNow.Date;
                bytransfers.Dates = dates;
                bytransfers.SprpNo = sprpNo;

                    _context.Add(bytransfers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bytransfers);
        }

        // GET: bytransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var bytransfers = await _context.bytransfers.FindAsync(id);
            if (bytransfers == null)
            {
                return NotFound();
            }
            return View(bytransfers);
        }

        // POST: bytransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("DateOfTransfer,PensionOrContarct,AggregateServiceInNigeriaYrs,AggregateServiceInNigeriaMos,AggregateServiceInNigeriaDays,AggregateSalaryInNigeria,Status,Date,Dates,SprpNo,Id")] bytransfers bytransfers)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (id != bytransfers.Id)
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
                    string sprpNo = HttpContext.Session.GetString("SPRP"); bytransfers.DateOfTransfer = bytransfers.DateOfTransfer;
                    bytransfers.PensionOrContarct = bytransfers.PensionOrContarct;
                    bytransfers.AggregateServiceInNigeriaYrs = bytransfers.AggregateServiceInNigeriaYrs;
                    bytransfers.AggregateServiceInNigeriaMos = bytransfers.AggregateServiceInNigeriaMos;
                    bytransfers.AggregateServiceInNigeriaDays = bytransfers.AggregateServiceInNigeriaDays;
                    bytransfers.AggregateSalaryInNigeria = bytransfers.AggregateSalaryInNigeria;
                    bytransfers.Status = "No";
                    bytransfers.Date = DateTime.UtcNow.Date;
                    bytransfers.Dates = dates;
                    bytransfers.SprpNo = sprpNo;

                    _context.Add(bytransfers);
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
                        string statu = HttpContext.Session.GetString("status");
                        string sprpNo = HttpContext.Session.GetString("SPRP"); 
                        bytransfers.DateOfTransfer = bytransfers.DateOfTransfer;
                        bytransfers.PensionOrContarct = bytransfers.PensionOrContarct;
                        bytransfers.AggregateServiceInNigeriaYrs = bytransfers.AggregateServiceInNigeriaYrs;
                        bytransfers.AggregateServiceInNigeriaMos = bytransfers.AggregateServiceInNigeriaMos;
                        bytransfers.AggregateServiceInNigeriaDays = bytransfers.AggregateServiceInNigeriaDays;
                        bytransfers.AggregateSalaryInNigeria = bytransfers.AggregateSalaryInNigeria;
                        bytransfers.Status = statu;
                        bytransfers.Date = DateTime.UtcNow.Date;
                        bytransfers.Dates = dates;
                        bytransfers.SprpNo = sprpNo;
                        _context.Update(bytransfers);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!bytransfersExists(bytransfers.Id))
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
                var nx = (from s in _context.bytransfers where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", bytransfers) });
            
        }

        // GET: bytransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bytransfers = await _context.bytransfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bytransfers == null)
            {
                return NotFound();
            }

            return View(bytransfers);
        }

        // POST: bytransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bytransfers = await _context.bytransfers.FindAsync(id);
            if (bytransfers.Status == "No")
            {
                _context.bytransfers.Remove(bytransfers);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.bytransfers where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool bytransfersExists(int id)
        {
            return _context.bytransfers.Any(e => e.Id == id);
        }
    }
}
