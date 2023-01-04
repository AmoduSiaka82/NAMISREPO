using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;

        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _logger = logger;
            this.db = db;
        }
       
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            HttpContext.Session.SetString("UserID", user.UserID);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("RoleID", user.RoleID);
            HttpContext.Session.SetString("StaffName", user.StaffName);
            HttpContext.Session.SetString("Department", user.Department);
            HttpContext.Session.SetString("station", user.StationName);
            HttpContext.Session.SetString("SPRP", "");
            StationViewModel aperson = new StationViewModel()
            {
                StationName = "Wael",
                StationID= 1
            };
            station st = new station();
            st.StationName = aperson.StationName;
            
          //  db.Add(st);
         //  db.SaveChanges();
            return View(aperson);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
