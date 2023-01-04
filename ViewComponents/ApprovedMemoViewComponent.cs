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
    public class ApprovedMemoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ApprovedMemoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string sprpNo = HttpContext.Session.GetString("SPRP");
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.Memo where s.Status == "Approved" select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                var bio = (from s in _context.Memo where s.StationName == stationName && s.Status == "Approved" select s);

                return View(await bio.ToListAsync());
            }

        }
    }
}

