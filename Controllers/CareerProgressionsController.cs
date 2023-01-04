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
    public class CareerProgressionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public CareerProgressionsController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

       

        // GET: CareerProgressions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareerProgression.ToListAsync());
        }

        // GET: CareerProgressions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerProgression = await _context.CareerProgression
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerProgression == null)
            {
                return NotFound();
            }

            return View(careerProgression);
        }

        // GET: CareerProgressions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerProgressions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachFile,SPRPNo,Date,Dates,Yr,Mnt,UserID,StationName,Id,Status,CareerId,Surname,MiddleName,FirstName,DateOfFirstAppointment,CurrentAppointment,DateofCurrentAppointment,GradeLevel,Step,ProposeRank,ProposeGrade,ProposeStep,Body,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,Remark,Remark1,Remark2,Remark3,Remark4,Day,Department")] CareerProgression careerProgression)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerProgression);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerProgression);
        }

        // GET: CareerProgressions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerProgression = await _context.CareerProgression.FindAsync(id);
            if (careerProgression == null)
            {
                return NotFound();
            }
            GetDesignation();
            return View(careerProgression);
        }
        private void GetDesignation()
        {
            string DeptID = HttpContext.Session.GetString("Department");
            List<designation> designationlist = new List<designation>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            designationlist = (from category in _context.designation  orderby category.Decoration ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            designationlist.Insert(0, new designation { DesignationID = 0, Decoration = "---Select---" });
            ViewBag.ListofDesig = designationlist;
        }

        // POST: CareerProgressions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SPRPNo,StationName,Id,Surname,MiddleName,FirstName,DateOfFirstAppointment,CurrentAppointment,DateofCurrentAppointment,GradeLevel,Step,ProposeRank,ProposeGrade,ProposeStep,Department")] CareerProgression careerProgression)
        {
            if (id != careerProgression.Id)
            {
                return NotFound();
            }
           
            if (HttpContext.Request.Form["CurrentAppointmen"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Rank");
                GetDesignation();
                return View();
            }
            if (HttpContext.Request.Form["Steps"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Step");
                GetDesignation();
                return View();
            }
            if (HttpContext.Request.Form["ProposeGrade"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Grade");
                GetDesignation();
                return View();
            }
            if (ModelState.IsValid)
            {
                try
                {
                  
                    careerProgression.ProposeGrade = HttpContext.Request.Form["ProposeGrade"].ToString();
                    careerProgression.ProposeRank= HttpContext.Request.Form["CurrentAppointmen"].ToString();
                    careerProgression.ProposeStep = HttpContext.Request.Form["Steps"].ToString();
                    _context.Update(careerProgression);
                    await _context.SaveChangesAsync();
                    GetDesignation();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerProgressionExists(careerProgression.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                GetDesignation();
                return RedirectToAction(nameof(UsersController.Index));
            }
            GetDesignation();
            return View(careerProgression);
        }

        // GET: CareerProgressions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerProgression = await _context.CareerProgression
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerProgression == null)
            {
                return NotFound();
            }

            return View(careerProgression);
        }

        // POST: CareerProgressions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careerProgression = await _context.CareerProgression.FindAsync(id);
            _context.CareerProgression.Remove(careerProgression);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerProgressionExists(int id)
        {
            return _context.CareerProgression.Any(e => e.Id == id);
        }
    }
}
