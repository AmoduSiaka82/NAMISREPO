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
    public class WrittenLetterViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public WrittenLetterViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = HttpContext.Session.GetString("UserID");
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.Leaves where (s.Status == "Written") orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                var bio = (from s in _context.Leaves where (s.Status == "Written") && s.StationName==stationName orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }

        }
    }
}
