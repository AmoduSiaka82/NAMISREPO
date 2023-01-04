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
    public class DispositionViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DispositionViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            string St = HttpContext.Session.GetString("station");
            if (St == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.biodata select s);

                return View(await bio.ToListAsync());
            }
            else
            {
                var bio = (from s in _context.biodata where s.StationName == St select s);

                return View(await bio.ToListAsync());
            }

        }
    }
}