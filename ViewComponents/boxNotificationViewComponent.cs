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
    public class boxNotificationViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public boxNotificationViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string usId = HttpContext.Session.GetString("UserID");
            var bio = (from s in _context.Box where s.ReceiverID == usId && s.Status == "Waiting" orderby s.Id descending select s);

            return View(await bio.ToListAsync());

        }
    }
}

