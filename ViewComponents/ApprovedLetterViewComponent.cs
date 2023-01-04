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
    public class ApprovedLetterViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ApprovedLetterViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = HttpContext.Session.GetString("UserID");
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                //string userID = HttpContext.Session.GetString("UserID");
                var bio = (from s in _context.itstudent where (s.Status == "Written") orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                //string userID = HttpContext.Session.GetString("UserID");
                var bio = (from s in _context.itstudent where (s.Status == "Written" && s.StationName == stationName) orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }
        }
    }
}

