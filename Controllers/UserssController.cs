using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PermissionManagement.MVC.Models;
using NAMIS.Models;
using System.Security.Claims;

namespace PermissionManagement.MVC.Controllers
{
    [Authorize]
    public class UserssController : Controller
    {
        private readonly UserManager<useraccount> _userManager;

        public UserssController(UserManager<useraccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("SuperAdmin"))
            {
                var allUsersExceptCurrentUser = await _userManager.Users.ToListAsync();
                return View(allUsersExceptCurrentUser);
            }
            else
            {
                var allUsersExceptCurrentUser = await _userManager.Users.Where(x => x.StationName == user.StationName).ToListAsync();
                return View(allUsersExceptCurrentUser);
            }
        }
    }
}