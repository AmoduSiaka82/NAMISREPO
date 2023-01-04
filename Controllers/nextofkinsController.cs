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
    public class nextofkinsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public nextofkinsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
            _contex = context;
        }
        
        
        

        // GET: nextofkins
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            if ((string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("SPRP"))))
            {
                return RedirectToAction("Login", "useraccounts");
            }
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
            var nxKin = (from s in _context.nextofkin where s.SprpNo == sprpNo && (s.Status == "No" || s.Status == "Editting")  select s);
            return View(await nxKin.ToListAsync());
        }

        // GET: nextofkins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            var nextofkin = await _context.nextofkin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nextofkin == null)
            {
                return NotFound();
            }

            return View(nextofkin);
        }

        // GET: nextofkins/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id=0)
        {
          
            ViewBag.SPRP =  HttpContext.Session.GetString("SPRP");
            if (id == 0)
            {
                return View(new nextofkin());
            }
            else
            {
                ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
                var nextofkin = await _context.nextofkin.FindAsync(id);
                HttpContext.Session.SetString("SPRP", nextofkin.SprpNo);
                if (nextofkin == null)
                {
                    return NotFound();
                }
                if (nextofkin.Status == "Editting")
                {
                    HttpContext.Session.SetString("status", "Waiting");
                }
                else
                {
                    HttpContext.Session.SetString("status", "No");
                }
                return View(nextofkin);
            }
        }

        // POST: nextofkins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,Address,Relationship,SprpNo,Date,Status,ID")] nextofkin nextofkin)
        {
            if (ModelState.IsValid)
            {

                string sprpNo = HttpContext.Session.GetString("SPRP");
                var NextLis = (from s in _context.nextofkin where s.SprpNo == sprpNo select s);

               
                ViewBag.datas = NextLis.ToList();

                int ik = 0;
                foreach (var item in ViewBag.datas)
                {
                    ik = ik + 1;
                }
                if (ik>1)
                {
                    ModelState.AddModelError("", "Only Two next of Kin Allow");
                    return View();
                }
                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                
                nextofkin.Surname = nextofkin.Surname;
                nextofkin.MiddleName = nextofkin.MiddleName;
                nextofkin.FirstName = nextofkin.FirstName;
                nextofkin.Address = nextofkin.Address;
                nextofkin.Relationship = nextofkin.Relationship;
                nextofkin.SprpNo = sprpNo;
                nextofkin.Date = DateTime.UtcNow.Date;
                nextofkin.Status = "No";
                _context.Add(nextofkin);
                await _context.SaveChangesAsync();
               
    var NextList = (from s in _context.nextofkin where s.SprpNo== sprpNo select s);
                
                ViewBag.data = NextList.ToList();

                int i = 0;
                foreach (var item in ViewBag.data)
                {
                    i = i + 1;
                }
                if (i == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Create", "marragehistories");
                }
                
            }
            return View(nextofkin);
        }

        // GET: nextofkins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            var nextofkin = await _context.nextofkin.FindAsync(id);
            HttpContext.Session.SetString("SPRP", nextofkin.SprpNo);
            if (nextofkin == null)
            {
                return NotFound();
            }
            return View(nextofkin);
        }

        // POST: nextofkins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("Surname,MiddleName,FirstName,Address,Relationship,SprpNo,Date,Status,ID")] nextofkin nextofkin)
        {
           
            if (id != nextofkin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string sprpNo = HttpContext.Session.GetString("SPRP");
                if (id == 0)
                {
                   
                    var NextLis = (from s in _context.nextofkin where s.SprpNo == sprpNo select s);


                    ViewBag.datas = NextLis.ToList();

                    int ik = 0;
                    foreach (var item in ViewBag.datas)
                    {
                        ik = ik + 1;
                    }
                    if (ik > 1)
                    {
                        ModelState.AddModelError("", "Only Two next of Kin Allow");
                        return View();
                    }
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                    nextofkin.Surname = nextofkin.Surname;
                    nextofkin.MiddleName = nextofkin.MiddleName;
                    nextofkin.FirstName = nextofkin.FirstName;
                    nextofkin.Address = nextofkin.Address;
                    nextofkin.Relationship = nextofkin.Relationship;
                    nextofkin.SprpNo = sprpNo;
                    nextofkin.Date = DateTime.UtcNow.Date;
                    nextofkin.Status = "No";
                    _context.Add(nextofkin);
                    await _context.SaveChangesAsync();

                 
                }
                else
                {
                    try
                    {
                        string statu = HttpContext.Session.GetString("status");
                        string formats = "MM/dd/yyyy";
                        string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                        string format = "dd/MM/yyyy";
                        DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                        Int32 Yr = CurrentServerTime.Year;
                        string date = Convert.ToString(CurrentServerTime.ToString(format));
                        string dates = Convert.ToString(CurrentServerTime.ToString(formats));

                        nextofkin.Surname = nextofkin.Surname;
                        nextofkin.MiddleName = nextofkin.MiddleName;
                        nextofkin.FirstName = nextofkin.FirstName;
                        nextofkin.Address = nextofkin.Address;
                        nextofkin.Relationship = nextofkin.Relationship;
                        nextofkin.SprpNo = sprpNo;
                        nextofkin.Date = DateTime.UtcNow.Date;
                        nextofkin.Status = statu;

                        _context.Update(nextofkin);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!nextofkinExists(nextofkin.ID))
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
                var nx = (from s in _context.nextofkin where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting")  select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", nextofkin) });
        }

        // GET: nextofkins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            var nextofkin = await _context.nextofkin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nextofkin == null)
            {
                return NotFound();
            }

            return View(nextofkin);
        }

        // POST: nextofkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nextofkin = await _context.nextofkin.FindAsync(id);
            if (nextofkin.Status == "No")
            {
                _context.nextofkin.Remove(nextofkin);
                await _context.SaveChangesAsync();
            }
            string sprpNos = HttpContext.Session.GetString("SPRP");
            string userIDs = HttpContext.Session.GetString("UserID");
            var nx = (from s in _context.nextofkin where s.SprpNo == sprpNos && (s.Status == "No" || s.Status == "Editting") select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", nx.ToList()) });
        }

        private bool nextofkinExists(int id)
        {
            return _context.nextofkin.Any(e => e.ID == id);
        }
    }
}
