using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class ManPowersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public ManPowersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;
            this.configuration = config;
        }
        [HttpPost]
        public IActionResult FilterByDateDaily()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Request.Form["ToDate"].ToString()) || string.IsNullOrEmpty(HttpContext.Request.Form["ToDate"].ToString()) || HttpContext.Request.Form["ToDate"].ToString() == "")
            {

                ModelState.AddModelError("", "Please select To date");
                return View();
            }
            if (string.IsNullOrWhiteSpace(HttpContext.Request.Form["FrmDate"].ToString()) || string.IsNullOrEmpty(HttpContext.Request.Form["FrmDate"].ToString()) || HttpContext.Request.Form["FrmDate"].ToString() == "")
            {

                ModelState.AddModelError("", "Please select Frm date");
                return View();
            }
            
            return RedirectToAction("Index", "ManPowers", new { frmDate = Convert.ToDateTime(HttpContext.Request.Form["FrmDate"].ToString()), toDate = Convert.ToDateTime(HttpContext.Request.Form["ToDate"].ToString()) });
            //return RedirectToAction(nameof(Sales));
        }
        [NoDirectAccess]
        // GET: ManPowersController
        public async Task<ActionResult> Index(DateTime frmDate,DateTime toDate)
        {
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");
            ViewData["SubmitTo"] = new SelectList(_context.Users.Where(x => x.Department == "Admin"), "UserID", "StaffName");
            var bio = (from s in _context.ManPowers where s.Date>=frmDate && s.Date<=toDate &&  s.DoneBy == userID select s);

            return View(await bio.ToListAsync());
        }
        [HttpPost]
        public ActionResult ProccessSubmission(List<string> rows)
        {

            
            
      
            var strategy = _context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {


                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    try
                    {


            rows.ForEach(x =>
            {

                var row = x.Split('-');
                var Oga = row[0];
                var Id = row[1];
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1).Date;
                string formats = "dd/MM/yyyy";
                string format = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string dates = Convert.ToString(CurrentServerTime.ToString(format));
                string date = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                Int32 nYear = CurrentServerTime.Year;
                Int32 nMonth = CurrentServerTime.Month;
                Int32 nDay = CurrentServerTime.Day;
                string userID = HttpContext.Session.GetString("UserID");
               
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Data Collection for Man Power";
                myBox.Description = "Data Collection for Man Power";
                myBox.Actions = "DataCollection";
                myBox.Controllers = "Boxes";
                myBox.UController = "Users";
                myBox.UAction = "ApprovedData";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                 myBox.ReceiverID= Oga;
               
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                int id = int.Parse(Id);
                _context.ManPowers.Where(x => (x.Status == "No" || x.Status == "Waiting") && x.Id == id).ToList().ForEach(x =>
                {
                    x.RecieverId = Oga;
                    
                    x.BoxId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();



            });

                       transaction.Commit();


                   }
                                   catch (Exception ex)
                                   {
                                       transaction.Rollback();
                                        Console.WriteLine(ex.Message + "Error occurred.");
                                    }

            }
                            });
            return Json(Url.Action("Index", "ManPowers", new { frmDate = DateTime.UtcNow.AddHours(1).Date,toDate= DateTime.UtcNow.AddHours(1).Date }));
            
        }
        [NoDirectAccess]
        // GET: ManPowersController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp = await _context.ManPowers
                .FirstOrDefaultAsync(m => m.Id== id);
            if (mp == null)
            {
                return NotFound();
            }

            return View(mp);
        }
        [NoDirectAccess]
        // GET: ManPowersController/Create
        public ActionResult Create()
        {
            ViewData["Station"] = new SelectList(_context.station.Where(x => x.StationName != ""), "StationName", "StationName");
            ViewData["Cadre"] = new SelectList(_context.designation.Where(x => x.Cadre != ""), "Cadre", "Cadre");
            return View();
        }

        // POST: ManPowersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ManPower mp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mp.Date = DateTime.UtcNow.AddHours(1).Date;
                    mp.Status = "No";
                    mp.DoneBy = HttpContext.Session.GetString("UserID");
                    _context.Add(mp);
                    int i = await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "ManPowers", new { frmDate = DateTime.UtcNow.AddHours(1).Date, toDate = DateTime.UtcNow.AddHours(1).Date });
                }
                ViewData["Cadre"] = new SelectList(_context.designation.Where(x => x.Cadre != ""), "Cadre", "Cadre");
                ViewData["Station"] = new SelectList(_context.station.Where(x => x.StationName != ""), "StationName", "StationName");
                return View(mp);
                
            }
            catch
            {
                return View();
            }
        }
        [NoDirectAccess]
        // GET: ManPowersController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp = await _context.ManPowers.FindAsync(id);
            if (mp == null)
            {
                return NotFound();
            }
            ViewData["Station"] = new SelectList(_context.station.Where(x => x.StationName != ""), "StationName", "StationName");
            ViewData["Cadre"] = new SelectList(_context.designation.Where(x => x.Cadre != ""), "Cadre", "Cadre");
            return View(mp);
          
        }

        // POST: ManPowersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ManPower mp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mp.Date = DateTime.UtcNow.AddHours(1).Date;
                    mp.Status = "No";
                    mp.DoneBy = HttpContext.Session.GetString("UserID");
                    _context.Update(mp);
                    int i = await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "ManPowers", new { frmDate = DateTime.UtcNow.AddHours(1).Date, toDate = DateTime.UtcNow.AddHours(1).Date });
                }
                ViewData["Cadre"] = new SelectList(_context.designation.Where(x => x.Cadre != ""), "Cadre", "Cadre");
                ViewData["Station"] = new SelectList(_context.station.Where(x => x.StationName != ""), "StationName", "StationName");
                return View(mp);
            }
            catch
            {
                return View();
            }
        }
        [NoDirectAccess]
        // GET: ManPowersController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mp = await _context.ManPowers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mp == null)
            {
                return NotFound();
            }

            return View(mp);
        }

        // POST: ManPowersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ManPower mps)
        {
            try
            {
                var mp = await _context.ManPowers.FindAsync(id);
                if (mp.Status == "No")
                {
                    _context.ManPowers.Remove(mp);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", "ManPowers", new { frmDate = DateTime.UtcNow.AddHours(1).Date, toDate = DateTime.UtcNow.AddHours(1).Date });

            }
            catch
            {
                return View();
            }
        }
    }
}
