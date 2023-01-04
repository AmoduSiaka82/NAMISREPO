using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;


namespace NAMIS.Controllers
{
  //  [Authorize(Roles = "SuperAdmin,ED,UnitHead,SectionHead")]
    public class UnitHeadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        public UnitHeadController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
           
            this.configuration = config;
        }
        [NoDirectAccess]
        public IActionResult ShowAll()
        {

            var biodatas = (from s in _context.biodata select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult Promotion()
        {

            var biodatas = (from s in _context.biodata where s.ProStatus == "Due" select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult Retirement()
        {

            var biodatas = (from s in _context.biodata where s.RStatus == "Due" select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult Training()
        {

            var biodatas = (from s in _context.biodata where s.TrainingStatus == "On Training" select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult Researchers()
        {

            var biodatas = (from s in _context.biodata where s.Carder == "Research Officer" select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult NoneResearchers()
        {

            var biodatas = (from s in _context.biodata where s.Carder != "Research Officer" select s);


            return View(biodatas.ToList());
        }
        [NoDirectAccess]
        public IActionResult ShowIndex(string searchString)
        {

            var biodatas = (from s in _context.biodata where s.SprpNo == searchString select s);

            ViewBag.data = biodatas.ToList();

            HttpContext.Session.SetString("SPRP", searchString);

            if (biodatas != null)
            {
                return RedirectToAction("Index", "ShowDeatail");
            }
            else
            {
                return RedirectToAction("Index", "ExecutiveDirector");
            }
        }
        [NoDirectAccess]
        public IActionResult Index()
        {
            string usId = HttpContext.Session.GetString("UserID");
            var sc = _context.scheduled.Where(u => (u.UserID == usId)).FirstOrDefault();
            if (sc != null)
            {
                HttpContext.Session.SetString("schedle", sc.Schedule);
                HttpContext.Session.SetString("unit", sc.Unit);
            }
           
            var box = (from s in _context.Box where s.ReceiverID2 == usId && s.Status2 == "Waiting" orderby s.Id descending select s);
            ViewBag.dat = box.ToList();
            int nMeassage = 0;
            foreach (var item in ViewBag.dat)
            {
                nMeassage = nMeassage + 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(nMeassage));
            var biodatas = (from s in _context.biodata select s);
           
            ViewBag.data = biodatas.ToList();
            decimal total = 0;
            decimal totalR = 0;
            decimal totalNR = 0;
            decimal totalT = 0;
            decimal totalD = 0;
            decimal totalRT = 0;
            foreach (var item in ViewBag.data)
            {
               total = total + 1;
                if (item.Carder == "Research Officer")
                {
                    totalR = totalR + 1;
               }
               else
               {
                   totalNR = totalNR + 1;

               }
               if (item.TrainingStatus == "On Training")
               {
                    totalT = totalT + 1;
               }
                if (item.ProStatus == "Due")
                {
                    totalD = totalD + 1;
                }
                if (item.RStatus == "Due")
                {
                    totalRT = totalRT + 1;
               }
            }
            HttpContext.Session.SetString("Fin", "Ok");
            HttpContext.Session.SetString("Total", Convert.ToString(total));
            HttpContext.Session.SetString("TotalR", Convert.ToString(totalR));
            HttpContext.Session.SetString("TotalNR", Convert.ToString(totalNR));

            HttpContext.Session.SetString("TotalT", Convert.ToString(totalT));
            HttpContext.Session.SetString("TotalD", Convert.ToString(totalD));
            HttpContext.Session.SetString("TotalRT", Convert.ToString(totalRT));
            return View(biodatas.ToList());

        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (biodata == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("SPRP", biodata.SprpNo);
            return View(biodata);
        }
    }
}
