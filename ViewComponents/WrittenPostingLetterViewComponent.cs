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
    public class WrittenPostingLetterViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public WrittenPostingLetterViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string userID = HttpContext.Session.GetString("UserID");
            string userID = HttpContext.Session.GetString("UserID");
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.StaffPosting where (s.Status == "Written") orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                var bio = (from s in _context.StaffPosting where (s.Status == "Written") && s.StationName == stationName select s);

                return View(await bio.ToListAsync());
            }
        }
    }
}


