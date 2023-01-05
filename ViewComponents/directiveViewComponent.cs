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
    public class directiveViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public directiveViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = HttpContext.Session.GetString("UserID");
            string stationName = HttpContext.Session.GetString("station");
           
                var bio = (from s in _context.Directives where (s.Status == "Waiting" && s.UserID==userID) select s);

                return View(await bio.ToListAsync());

           

        }
    }
}
