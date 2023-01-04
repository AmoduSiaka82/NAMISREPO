using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using NAMIS.Models;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using NAMIS.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NAMIS.Controllers
{
    public class ShowDeatailController : Controller
    {
        
        private readonly ApplicationDbContext _contex;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public ShowDeatailController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;
            this.configuration = config;
        }
        public async Task<IActionResult> Allow(string id)
        {

            

            biodataViewModel model = new biodataViewModel();

            var tbl_Stockut = await _context.biodata.FindAsync(id);
            model.Surname = tbl_Stockut.Surname;
            model.FirstName = tbl_Stockut.FirstName;
            model.MiddleName= tbl_Stockut.MiddleName;
            model.SprpNo = tbl_Stockut.SprpNo;

            model.EdNote = tbl_Stockut.EdNote;
            if (tbl_Stockut == null)
            {
                return NotFound();
            }
            return PartialView("Allow", model);
            //return View(tbl_StockOut);
        }
        
        public IActionResult Index()
        {
           
            string sprpNo = HttpContext.Session.GetString("SPRP");
           
            dynamic model = new ExpandoObject();
            model.biodata = (from s in _context.biodata where s.SprpNo == sprpNo select s);
            model.nextofkin = (from c in _context.nextofkin where c.SprpNo == sprpNo select c);
            model.marragehistory = (from c in _context.marragehistory where c.SprpNo == sprpNo select c);
            model.particularofchildren= (from c in _context.particularofchildren where c.SprpNo == sprpNo select c);
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
        

             [NoDirectAccess]
        public async Task<IActionResult> BioDataAction(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata.FindAsync(id);
            if (biodata == null)
            {
                return NotFound();
            }
            ViewData["MiniteTo"] = new SelectList(_context.Users.Where(x => x.Department == "Admin"), "UserID", "StaffName");
            return View(biodata);
        }
        [HttpPost, ActionName("BioDataAction")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBioDataAction(string id, biodata bio)
        {
            var bios = await _context.biodata.FindAsync(id);
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            string Id = "";
            if (bios.UnitNote=="" || bios.UnitNote==null)
            {
                int iNo;

                string genNo = "";
                
                DALClass genID = new DALClass(configuration);

                genNo = genID.RefNoAuto().ToString();

                if (genNo.Equals("") || genNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(genNo);
                    iNo++;
                }
                if (iNo < 10) { Id = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { Id = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { Id = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { Id = "0" + Convert.ToString(iNo); }
                else Id = Convert.ToString(iNo);
                Refrence rf = new Refrence();
                rf.Id = 0;
                rf.RefNo = Id;
                _context.Add(rf);
                await _context.SaveChangesAsync();
            }
            else
            {
                Id = bios.UnitNote;
            }
            _context.biodata.Where(x => x.SprpNo == id ).ToList().ForEach(x =>
            {
                if (bio.EdNote == "Editting")
                {
                    x.Status = "Editting";
                }else if (bio.EdNote== "Cancel Action")
                {
                    x.Status = "Waiting";
                }
                x.UnitNote = Id;
                x.EdNote = bio.EdNote;
                x.HodNote = bio.HodNote;
            });
          int i=  _context.SaveChanges();
            if (i > 0)
            {
                int k = 0;
                string staffName = HttpContext.Session.GetString("StaffName");
                string roleID = HttpContext.Session.GetString("RoleID");
                var dir = await _context.Directives.FirstOrDefaultAsync(m => m.RefNo== Id && m.UserID== HttpContext.Request.Form["miniteTo"].ToString() && m.SprpNo==bio.SprpNo && m.Status=="Waiting");
                if (dir != null)
                {
                    dir.Act = bio.EdNote;
                    dir.Remarks = bio.HodNote;
                    _context.Update(dir);
                    k = await _context.SaveChangesAsync();
                }
                else
                {
                    Directive dr = new Directive();
                    
                        
                    if(User.IsInRole("ED"))
                    {
                        dr.Remarks = bio.HodNote;
                    }
                    else
                    {
                        dr.Remarks= HttpContext.Request.Form["hodNote"].ToString();
                    }
                    dr.RefNo = Id;
                    dr.OfficerName = staffName;
                    dr.Responsibility = roleID;
                    dr.Date = DateTime.UtcNow.AddHours(1).Date;
                    dr.Act = bio.EdNote;
                    dr.UserID = HttpContext.Request.Form["miniteTo"].ToString();
                    dr.SprpNo = bio.SprpNo;
                    dr.Status = "Waiting";
                    _context.Add(dr);
                     k = await _context.SaveChangesAsync();
                }
                if (k>0)
                {
                    _context.register.Where(x => x.SprpNo == id).ToList().ForEach(x =>
                    {
                        if (bio.EdNote == "Cancel Action")
                        {
                            x.Status = "Submitted";
                        }
                        else { x.Status = "No"; }
                        x.UserID = HttpContext.Request.Form["miniteTo"].ToString();
                    });
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            else{
                ViewData["MiniteTo"] = new SelectList(_context.Users.Where(x => x.Department == "Admin"), "UserID", "StaffName");
                return View(bio);
            }
        }
        public async Task<IActionResult> biodatasEdit(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata.FindAsync(id);
            if (biodata == null)
            {
                return NotFound();
            }
            
            return View(biodata);
        }


        // POST: biodatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> biodatasEdit(string id, [Bind("EdNote,Status")] biodata biodata)
        {
            
            if (id != biodata.SprpNo)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid parameters");
            }
            else
            {
              
            
            try
                {
                    var stf = _context.biodata.Where(u => (u.SprpNo == biodata.SprpNo)).FirstOrDefault();
                    if (stf == null)
                    {
                       
                        ModelState.AddModelError("", "SPRP No Not In our Record");

                        return View();
                    }
                    string userID = HttpContext.Session.GetString("UserID");
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                  // var biodatas = await _context.biodata.FindAsync(id);
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                    string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                    

                   
                    biodata.Status = "Action";
                   
                    biodata.EdNote = biodata.EdNote;

                    _context.Update(biodata);
                    int i = await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!biodataExists(biodata.SprpNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
           

        }
        private bool biodataExists(string id)
        {
            return _context.biodata.Any(e => e.SprpNo == id);
        }
        public async Task<IActionResult> nextofkinsEdit(int? id)
        {
          
          
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            var nextofkin = await _context.nextofkin.FindAsync(id);
            if (nextofkin == null)
            {
                return NotFound();
            }
            return View(nextofkin);
        }

        // POST: nextofkins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nextofkinsEdit(int id, [Bind("Status,EdNote")] nextofkin nextofkin)
        {
            
          
            if (id != nextofkin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    //var nextofkins = await _context.nextofkin.FindAsync(id);
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                   
                    nextofkin.Status = "Action";
                    nextofkin.EdNote = nextofkin.EdNote;
                    _context.Update(nextofkin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nextofkinExists(nextofkin.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nextofkin);
        }
        private bool nextofkinExists(int id)
        {
            return _context.nextofkin.Any(e => e.ID == id);
        }
    }
}
