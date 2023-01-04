using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;
//migrationBuilder.Sql("SET default_storage_engine=INNODB");
namespace NAMIS.Controllers
{
   // [Authorize(Roles = "SuperAdmin,Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        //private readonly RoleManager<AppRoles> _roleManager;
        public AdminController(UserManager<useraccount> userManager,  SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
           // _roleManager = roleManager;
            this.configuration = config;
        }
        [NoDirectAccess]

        public async Task<IActionResult> Details(string Id)
        {
            var users = await userManager.FindByIdAsync(Id);
            return View(users);
        }
        public IActionResult Index()
        {
            return View(_context.department.ToList());
        }
        


        //[NoDirectAccess]
        //public async Task<IActionResult> UpdateRole(string roleId)
        //{
        //    var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var role = await _roleManager.FindByIdAsync(roleId);
        //    ViewData["Units"] = new SelectList(_context.unit, "UnitName", "UnitName");
        //    ViewData["Distances"] = new SelectList(_context.station, "StationName", "StationName");
        //    ViewData["Responsibility"] = new SelectList(_context.department, "Department", "Department");
        //    return View(role);
        //}


        //[HttpPost, ActionName("UpdateRole")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ConfirmUpdateRole(AppRoles rl)
        //{
        //    var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var role = await _roleManager.FindByIdAsync(rl.Id);
        //    role.Name = rl.Name;
        //    role.departments = rl.departments;
        //    role.units = rl.units;
        //    role.sections = rl.sections;
        //    role.mda = rl.mda;
        //    var result = await _roleManager.UpdateAsync(role);
            
        //    return RedirectToAction(nameof(UserRole));
        //}
        //[NoDirectAccess]
        //[HttpGet]
        //public async Task<IActionResult> UserRole()
        //{
        //    var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var roles = await _roleManager.Roles.Where(x=>x.mda=="").ToListAsync();
        //    return View(roles);
        //}

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AssignIndex()
        {
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var users = userManager.Users.Where(x => x.StationName == "" || x.StationName == user.StationName);
            return View(users);
        }
        [NoDirectAccess]
        public async Task<IActionResult> AssignResponsibility(string Id)
        {
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var users = await userManager.FindByIdAsync(Id);
            ViewData["Units"] = new SelectList(_context.unit, "UnitName", "UnitName");
            ViewData["Distances"] = new SelectList(_context.station, "StationName", "StationName");
            ViewData["Responsibility"] = new SelectList(_context.department, "Department", "Department");
            return View(users);
        }
        [HttpPost, ActionName("AssignResponsibility")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAssignResponsibility(string Id, useraccount applicationUsers)
        {
            var users = await userManager.FindByIdAsync(Id);
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            users.PhoneNumber = applicationUsers.PhoneNumber;
            users.Email = applicationUsers.Email;
            users.RoleID = applicationUsers.RoleID;
            users.StaffName = applicationUsers.StaffName;
            users.PhoneNumber = applicationUsers.PhoneNumber;
            users.StationName = applicationUsers.StationName;
            users.Department = applicationUsers.Department;
            users.Unit = applicationUsers.Unit;
            IdentityResult result = await userManager.UpdateAsync(users);
            if (result.Succeeded)
            {
                var usr = (from s in _context.Users where s.StationName == user.StationName || s.StationName == "" select s);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllAssign", usr.ToList()) });
            }
            ViewData["Units"] = new SelectList(_context.unit, "UnitName", "UnitName");
            ViewData["Distances"] = new SelectList(_context.station, "StationName", "StationName");
            ViewData["Responsibility"] = new SelectList(_context.department, "Department", "Department");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AssignResponsibility", users) });
        }
    }
}
