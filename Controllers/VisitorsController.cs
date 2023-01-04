using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace NAMIS.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public VisitorsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: Visitors
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            string stationName = HttpContext.Session.GetString("station");
           DateTime date= DateTime.Now.Date.AddHours(1);
                var biodatas = (from s in _context.Visitor where s.Date == date && s.StationName == stationName select s);
                return View(await biodatas.ToListAsync());
        }

        // GET: Visitors/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // GET: Visitors/Create
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
           
            if (id == 0)
            {

                return View(new Visitor());
            }
            else
            {
                var Visito = await _context.Visitor.FindAsync(id);
                if (Visito == null)
                {
                    return NotFound();
                }
                return View(Visito);
            }
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitorName,Id,PhoneNo,EmailID,PurposeOfVisit,WhoToVisit,DidKnow,Date,Dates,TimeOfVisit,Status,VisitID,StationName")] Visitor visitor)
        {
           
            if (ModelState.IsValid)
            {
                string stationName = HttpContext.Session.GetString("station");
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                string formats = "dd/MM/yyyy";
                string format = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string dates = Convert.ToString(CurrentServerTime.ToString(format));
                string date = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                var bx = _context.Box.Where(u => (u.Date == DateTime.UtcNow.Date && u.Subject == "Visitors")).FirstOrDefault();
                if (bx == null)
                {
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
            }
                else
                {
                    BoxId = bx.IdNo;
                }
                Int32 nYear = CurrentServerTime.Year;
                Int32 nMonth = CurrentServerTime.Month;
                Int32 nDay = CurrentServerTime.Day;
                string userID = HttpContext.Session.GetString("UserID");
                var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Visitor").FirstOrDefault();
                if (sch != null)
                {
                    Box myBox = new Box();
                    myBox.Subject = "Visitors";
                    myBox.Description = "Visitor List Prepared for View";
                    myBox.Actions = "VisitorList";
                    myBox.Controllers = "Boxes";
                    myBox.UAction = "ApprovedVisitor";
                    myBox.UController = "Users";
                    myBox.UserID = userID;
                    myBox.UserStatus = "Waiting";
                    myBox.ReceiverID = "00010";
                    myBox.ReceiverID1 = "00011";
                    myBox.ReceiverID2 = sch.AllocatedUserID;
                    myBox.ReceiverID3 = sch.AllocatedUserID;
                    myBox.ReceiverID4 = sch.AllocatedUserID;
                    myBox.Status = "Waiting";
                    myBox.Status1 = "Waiting";
                    myBox.Status2 = "Waiting";
                    myBox.Status3 = "Waiting";
                    myBox.Status4 = "Waiting";
                    myBox.IdNo = BoxId;
                    myBox.Date = DateTime.UtcNow.Date.AddHours(1);
                    myBox.Dates = dates;
                    myBox.Yr = Convert.ToString(nYear);
                    myBox.Mnt = Convert.ToString(nMonth);
                    myBox.Dy = Convert.ToString(nDay);
                    _context.Add(myBox);
                    int i = _context.SaveChanges();
                    visitor.StationName = stationName;
                    visitor.Date = DateTime.UtcNow.Date;
                    visitor.Dates = dates;
                    visitor.Id = 0;
                    visitor.VisitID = BoxId;
                    visitor.Status = "Approved";
                    visitor.ReceiverID = "00010";
                    visitor.ReceiverID1 = sch.AllocatedUserID;
                    visitor.ReceiverID2 = sch.AllocatedUserID;
                    visitor.ReceiverID3 = sch.AllocatedUserID;
                    visitor.ReceiverID4 = sch.AllocatedUserID;
                    visitor.UserID = userID;
                    _context.Add(visitor);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int id, [Bind("VisitorName,Id,PhoneNo,EmailID,PurposeOfVisit,WhoToVisit,DidKnow,Date,Dates,TimeOfVisit,Status,VisitID,StationName")] Visitor visitor)
        {
           
         
            if (ModelState.IsValid)
            {
                string stationName = HttpContext.Session.GetString("station");
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                string formats = "dd/MM/yyyy";
                string format = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string dates = Convert.ToString(CurrentServerTime.ToString(format));
                string date = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                string statu = HttpContext.Session.GetString("status");
                if (id == 0)
                {
                    
                    int iNo;
                    string BoxId = "";
                    string BoxNo = "";
                    var bx = _context.Box.Where(u => (u.Date == DateTime.UtcNow.Date && u.Subject == "Visitors")).FirstOrDefault();
                    if (bx == null)
                    {
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
                    }
                    else
                    {
                        BoxId = bx.IdNo;
                    }
                    Int32 nYear = CurrentServerTime.Year;
                    Int32 nMonth = CurrentServerTime.Month;
                    Int32 nDay = CurrentServerTime.Day;
                    string userID = HttpContext.Session.GetString("UserID");
                    var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Visitor").FirstOrDefault();
                    if (sch != null)
                    {
                        Box myBox = new Box();
                        myBox.Subject = "Visitors";
                        myBox.Description = "Visitor List Prepared for View";
                        myBox.Actions = "VisitorList";
                        myBox.Controllers = "Boxes";
                        myBox.UAction = "ApprovedVisitor";
                        myBox.UController = "Users";
                        myBox.UserID = userID;
                        myBox.UserStatus = "Waiting";
                        myBox.ReceiverID = "00010";
                        myBox.ReceiverID1 = "00011";
                        myBox.ReceiverID2 = sch.AllocatedUserID;
                        myBox.ReceiverID3 = sch.AllocatedUserID;
                        myBox.ReceiverID4 = sch.AllocatedUserID;
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
                        int i = _context.SaveChanges();
                        visitor.StationName = stationName;
                        visitor.Date = DateTime.UtcNow.Date;
                        visitor.Dates = dates;
                        visitor.Id = 0;
                        visitor.VisitID = BoxId;
                        visitor.Status = "Approved";
                        visitor.ReceiverID = "00010";
                        visitor.ReceiverID1 = sch.AllocatedUserID;
                        visitor.ReceiverID2 = sch.AllocatedUserID;
                        visitor.ReceiverID3 = sch.AllocatedUserID;
                        visitor.ReceiverID4 = sch.AllocatedUserID;
                        visitor.UserID = userID;
                        _context.Add(visitor);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    try
                    {
                       
                        var bx = _context.Box.Where(u => (u.Date == DateTime.UtcNow.Date && u.Subject == "Visitors")).FirstOrDefault();
                        if (bx != null)
                        {
                            string userID = HttpContext.Session.GetString("UserID");
                        var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Visitor").FirstOrDefault();
                            if (sch != null)
                            {
                                
                                visitor.StationName = stationName;
                                visitor.Date = DateTime.UtcNow.Date;
                                visitor.Dates = dates;
                                visitor.Id = 0;
                                visitor.VisitID = bx.IdNo;
                                visitor.Status = "Approved";
                                visitor.ReceiverID = "00010";
                                visitor.ReceiverID1 = sch.AllocatedUserID;
                                visitor.ReceiverID2 = sch.AllocatedUserID;
                                visitor.ReceiverID3 = sch.AllocatedUserID;
                                visitor.ReceiverID4 = sch.AllocatedUserID;
                                visitor.UserID = userID;
                                _context.Update(visitor);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VisitorExists(visitor.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                string stationNames = HttpContext.Session.GetString("station");
               
                DateTime CurrentServerTimes = DateTime.UtcNow.AddHours(1);
                string forma = "dd/MM/yyyy";
                
                string dat = Convert.ToString(CurrentServerTimes.ToString(forma));
              
                var visit = (from s in _context.Visitor where s.Date == DateTime.UtcNow.Date && s.StationName == stationNames select s);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", visit.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateEdit", visitor) });
           
        }

        // GET: Visitors/Delete/5
        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitor = await _context.Visitor.FindAsync(id);
            _context.Visitor.Remove(visitor);
            await _context.SaveChangesAsync();
            string stationNames = HttpContext.Session.GetString("station");
            DateTime CurrentServerTimes = DateTime.UtcNow.AddHours(1);
            string forma = "dd/MM/yyyy";
            string dat = Convert.ToString(CurrentServerTimes.ToString(forma));
            var visit = (from s in _context.Visitor where s.Date == DateTime.UtcNow.Date && s.StationName == stationNames select s);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", visit.ToList()) });
        }

        private bool VisitorExists(int id)
        {
            return _context.Visitor.Any(e => e.Id == id);
        }
    }
}
