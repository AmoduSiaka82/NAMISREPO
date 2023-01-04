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
    public class PrepareRetirmentRollViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PrepareRetirmentRollViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string sprpNo = HttpContext.Session.GetString("SPRP");
            string stationName = HttpContext.Session.GetString("station");
            string userID = HttpContext.Session.GetString("UserID");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.retirementbiodata where s.Status=="No" && s.CheckBy==userID orderby s.Id descending select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                var bio = (from s in _context.retirementbiodata where s.StationName == stationName && s.Status == "No" && s.CheckBy == userID orderby s.Id descending  select s);
                ViewBag.data = bio.ToListAsync();
                return View(await bio.ToListAsync());
            }


        }
    }
}
