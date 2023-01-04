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
    public class ScheduleViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ScheduleViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = HttpContext.Session.GetString("UserID");
            var sch = (from s in _context.scheduled where  s.UserID == userID select s);
            
                return View(await sch.ToListAsync());

        }
    }
}
