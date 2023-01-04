using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NAMIS.Models;

namespace NAMIS.Controllers
{
    public class SummariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public SummariesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
            _contex = context;
        }
        
     
        public IActionResult Index(int ID)
        {
            var reg = _context.register.Find(ID);
            if (reg != null)
            {
                HttpContext.Session.SetString("SPRP", reg.SprpNo);
            }
            else
            {

            }
            
            return View();
        }
        [HttpPost]
        public IActionResult Submitting(int id=0)
        {
            string sprpNo = HttpContext.Session.GetString("SPRP");
            
            _context.biodata.Where(x => x.SprpNo == sprpNo ).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.nextofkin.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();

            _context.marragehistory.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();

            _context.particularofchildren.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            
           
            _context.languages.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.dpq.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.educations.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.schoolcertificatehelds.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.dsinforce.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.dpps.Where(x => x.SprpNo == sprpNo ).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.totalpreviousservice.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.tourandleaverecord.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.recordofsickleaves.Where(x => x.SprpNo == sprpNo ).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.rofcandcs.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.byresignationorinvalidating.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.bydeaths.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.bytransfers.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.rofgpm.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.recordofservice.Where(x => x.SprpNo == sprpNo ).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            
             _context.recordofemolument.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Waiting";
            });
            _context.SaveChanges();
            _context.register.Where(x => x.SprpNo == sprpNo).ToList().ForEach(x =>
            {
                x.Status = "Submitted";
            });
            _context.SaveChanges();
           
            return RedirectToAction("Index", "registers");
        }
        
    }
}
