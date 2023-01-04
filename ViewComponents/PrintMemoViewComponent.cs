using Microsoft.AspNetCore.Mvc;
using NAMIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewComponents
{
    public class PrintMemoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PrintMemoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ////string sprpNo = HttpContext.Session.GetString("SPRP");
            //string stationName = HttpContext.Session.GetString("station");
            //string userID = HttpContext.Session.GetString("UserID");
            //if (stationName == "Headqauaters Ilorin")
            //{
            //    var bio = (from s in _context.reportwriting where s.Status == "No" select s);

            //    return View(await bio.ToListAsync());
            //}
            //else
            //{
            //    var bio = (from s in _context.reportwriting where s.StationName == stationName && s.Status == "No" select s);

            //    return View(await bio.ToListAsync());
            //}
            return View();
        }
    }
}


