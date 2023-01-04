﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewComponents
{
    public class rofgpmsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public rofgpmsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sprpNo = HttpContext.Session.GetString("SPRP");
            var bio = (from s in _context.rofgpm where s.SprpNo == sprpNo select s);

            return View(await bio.ToListAsync());

        }
    }
}