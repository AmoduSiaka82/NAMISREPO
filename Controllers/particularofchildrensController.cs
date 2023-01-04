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
using Org.BouncyCastle.Asn1.Cms;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class particularofchildrensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public particularofchildrensController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: particularofchildrens
        public async Task<IActionResult> Index()
        {
          
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var particularofchildren = (from s in _context.particularofchildren where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID  select s);
            return View(await particularofchildren.ToListAsync());
        }

        // GET: particularofchildrens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particularofchildren = await _context.particularofchildren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (particularofchildren == null)
            {
                return NotFound();
            }

            return View(particularofchildren);
        }

        // GET: particularofchildrens/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
            
            if (id == 0)
            {
                return View( new particularofchildren());
            }
            else
            {
               

                var particularofchildren = await _context.particularofchildren.FindAsync(id);
                if (particularofchildren == null)
                {
                    return NotFound();
                }
                if (particularofchildren.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(particularofchildren);
            }
        }

        // POST: particularofchildrens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,Sex,DateOfBirth,CheckedBy,SprpNo,Date,Status,Time,Id")] particularofchildren particularofchildren)
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
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                string usId = HttpContext.Session.GetString("UserID");
                particularofchildren.CheckedBy = usId;
                particularofchildren.Surname = particularofchildren.Surname;
                particularofchildren.MiddleName = particularofchildren.MiddleName;
                particularofchildren.FirstName = particularofchildren.FirstName;
                particularofchildren.Sex = particularofchildren.Sex;
                particularofchildren.DateOfBirth = particularofchildren.DateOfBirth;
              
                particularofchildren.SprpNo = sprpNo;
                particularofchildren.Date = DateTime.UtcNow.Date;
                particularofchildren.Status = "No";
                particularofchildren.Time = time;
                _context.Add(particularofchildren);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "languages");
            }
            return View(particularofchildren);
        }

        // GET: particularofchildrens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var particularofchildren = await _context.particularofchildren.FindAsync(id);
            if (particularofchildren == null)
            {
                return NotFound();
            }
            return View(particularofchildren);
        }

        // POST: particularofchildrens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Surname,MiddleName,FirstName,Sex,DateOfBirth,CheckedBy,SprpNo,Date,Status,Time,Id")] particularofchildren particularofchildren)
        {
          
            if (id != particularofchildren.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {if (id == 0)
                {
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    var NextList = (from s in _context.particularofchildren where s.SprpNo == sprpNo select s);

                    ViewBag.data = NextList.ToList();

                    int i = 0;
                    foreach (var item in ViewBag.data)
                    {
                        i = i + 1;
                    }
                    if (i == 4)
                    {
                        ModelState.AddModelError("", "Children cannot be More than Four");
                        return View();
                    }

                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                    string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                    string usId = HttpContext.Session.GetString("UserID");
                    particularofchildren.CheckedBy = usId;
                    particularofchildren.Surname = particularofchildren.Surname;
                    particularofchildren.MiddleName = particularofchildren.MiddleName;
                    particularofchildren.FirstName = particularofchildren.FirstName;
                    particularofchildren.Sex = particularofchildren.Sex;
                    particularofchildren.DateOfBirth = particularofchildren.DateOfBirth;

                    particularofchildren.SprpNo = sprpNo;
                    particularofchildren.Date = DateTime.UtcNow.Date;
                    particularofchildren.Status = "No";
                    particularofchildren.Time = time;
                    _context.Add(particularofchildren);
                    await _context.SaveChangesAsync();
                    
                }
                else
                {
                    try
                    {
                        string sprpNo = HttpContext.Session.GetString("SPRP");
                        string statu = HttpContext.Session.GetString("status");

                        // var particularofchildrens = await _context.particularofchildren.FindAsync(id);
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                        string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                        string usId = HttpContext.Session.GetString("UserID");
                        particularofchildren.CheckedBy = usId;
                        particularofchildren.Surname = particularofchildren.Surname;
                        particularofchildren.MiddleName = particularofchildren.MiddleName;
                        particularofchildren.FirstName = particularofchildren.FirstName;
                        particularofchildren.Sex = particularofchildren.Sex;
                        particularofchildren.DateOfBirth = particularofchildren.DateOfBirth;

                        particularofchildren.SprpNo = sprpNo;
                        particularofchildren.Date = DateTime.UtcNow.Date;
                        particularofchildren.Status = statu;
                        particularofchildren.Time = time;

                        _context.Update(particularofchildren);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!particularofchildrenExists(particularofchildren.Id))
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
                

                var particularofchildrens = (from s in _context.particularofchildren where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", particularofchildrens.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", particularofchildren) });
        }

        // GET: particularofchildrens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particularofchildren = await _context.particularofchildren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (particularofchildren == null)
            {
                return NotFound();
            }

            return View(particularofchildren);
        }

        // POST: particularofchildrens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var particularofchildren = await _context.particularofchildren.FindAsync(id);
            if (particularofchildren.Status == "No")
            {
                _context.particularofchildren.Remove(particularofchildren);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            var particularofchildrens = (from s in _context.particularofchildren where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") && s.CheckedBy == userID select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", particularofchildrens.ToList()) });
        }

        private bool particularofchildrenExists(int id)
        {
            return _context.particularofchildren.Any(e => e.Id == id);
        }
    }
}
