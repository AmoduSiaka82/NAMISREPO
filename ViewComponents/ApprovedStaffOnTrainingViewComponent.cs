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
    public class ApprovedStaffOnTrainingViewComponent :ViewComponent
    {
        private readonly ApplicationDbContext _context;

    public ApprovedStaffOnTrainingViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string userID = HttpContext.Session.GetString("UserID");
        string stationName = HttpContext.Session.GetString("station");
        if (stationName == "Headqauaters Ilorin")
        {
            var bio = (from s in _context.TrainingAndStudy where (s.Status == "Approved") select s);

            return View(await bio.ToListAsync());
        }
        else
        {
            var bio = (from s in _context.TrainingAndStudy where (s.Status == "Approved") && s.StationName == stationName select s);

            return View(await bio.ToListAsync());
        }
    }
}
}


