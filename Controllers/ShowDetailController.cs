using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAMIS.Data;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NAMIS.Models;

namespace NAMIS.Controllers
{
    public class ShowDetailController : Controller
    {
        private readonly ApplicationDbContext _contex;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public ShowDetailController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;
            this.configuration = config;
        }
        public IActionResult Index()
        {
            string sprpNo = HttpContext.Session.GetString("SPRP");
            dynamic model = new ExpandoObject();
            model.biodata = (from s in _context.biodata where s.SprpNo == sprpNo select s);
            model.nextofkin = (from c in _context.nextofkin where c.SprpNo == sprpNo select c);
            model.marragehistory = (from c in _context.marragehistory where c.SprpNo == sprpNo select c);
            model.particularofchildren = (from c in _context.particularofchildren where c.SprpNo == sprpNo select c);
            model.languages = (from c in _context.languages where c.SprpNo == sprpNo select c);
            model.dpq = (from c in _context.dpq where c.SprpNo == sprpNo select c);
            model.educations = (from c in _context.educations where c.SprpNo == sprpNo select c);
            model.schoolcertificatehelds = (from c in _context.schoolcertificatehelds where c.SprpNo == sprpNo select c);
            model.dsinforce = (from c in _context.dsinforce where c.SprpNo == sprpNo select c);
            model.dpps = (from c in _context.dpps where c.SprpNo == sprpNo select c);
            model.totalpreviousservice = (from c in _context.totalpreviousservice where c.SprpNo == sprpNo select c);
            model.tourandleaverecord = (from c in _context.tourandleaverecord where c.SprpNo == sprpNo select c);
            model.recordofsickleaves = (from c in _context.recordofsickleaves where c.SprpNo == sprpNo select c);
            model.rofcandcs = (from c in _context.rofcandcs where c.SprpNo == sprpNo select c);
            model.byresignationorinvalidating = (from c in _context.byresignationorinvalidating where c.SprpNo == sprpNo select c);
            model.bydeaths = (from c in _context.bydeaths where c.SprpNo == sprpNo select c);
            model.bytransfers = (from c in _context.bytransfers where c.SprpNo == sprpNo select c);
            model.rofgpm = (from c in _context.rofgpm where c.SprpNo == sprpNo select c);

            model.recordofservice = (from c in _context.recordofservice where c.SprpNo == sprpNo select c);
            model.recordofemolument = (from c in _context.recordofemolument where c.SprpNo == sprpNo select c);
            return View(model);
        }
    }
}
