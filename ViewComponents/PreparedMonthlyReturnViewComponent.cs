using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewComponents
{
    public class PreparedMonthlyReturnViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PreparedMonthlyReturnViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = HttpContext.Session.GetString("UserID");
            var bio = (from s in _context.monthlyreturn where (s.Status == "No") && s.UserID == userID select s);

            return View(await bio.ToListAsync());
        }
    }
}

