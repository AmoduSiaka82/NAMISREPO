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
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TopMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var bio = (from s in _context.TopMenus select s);

            return View(await bio.ToListAsync());

        }
    }
}

