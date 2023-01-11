using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class biodatasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public biodatasController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;
            this.configuration = config;
        }
        // GET: biodatas
        public async Task<IActionResult> Index()
        {
            
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            string sprpNo = HttpContext.Session.GetString("SPRP");
            string userID = HttpContext.Session.GetString("UserID");

            var bio = (from s in _context.biodata where s.SprpNo == sprpNo && s.CheckBy == userID select s);

            return View(await bio.ToListAsync());
        }

        public async Task<IActionResult> CareerProgression()
        {
           
            ViewBag.SPRP = HttpContext.Session.GetString("SPRP");
            string sprpNo = HttpContext.Session.GetString("SPRP");

            var bio = (from s in _context.biodata where s.ProStatus == "Due" select s);

            return View(await bio.ToListAsync());
        }

        // GET: biodatas/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (biodata == null)
            {
                return NotFound();
            }

            return View(biodata);
        }

        // GET: biodatas/Create
        [NoDirectAccess]
        public IActionResult Create()
        {
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            //{

            //    return RedirectToAction("Index", "registers");
            //}
            PopulateDepartmentDropDownList();
            PopulateStationDropDownList();

              
            PopulateCountryMasterDropDownList();
            return View();
        }

        // POST: biodatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Decoration,Natinality,DateOfFirstAppointment,DateOfFirstArrival,LGAOrigin,DateOfBirth,PlaceOfBirth,CheckBy,Proof,Date,Dates,Time,Status,HomeAddress,Department,GeographicalLocation,SubstansiveAppointment,DateOfAppointment,TermsOfEngagement,CurrentAppointment,StateOfOrigin,DateOfCurrentAppointment,Carder,HighestQualification,ConfirmationDate,DateOfRetirement,DateOfPromotion")] biodata biodata)

        public async Task<IActionResult> Create([Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Decoration,Natinality,DateOfFirstAppointment,DateOfFirstArrival,LGAOrigin,DateOfBirth,PlaceOfBirth,CheckBy,Proof,Date,Dates,Time,Status,HomeAddress,Department,GeographicalLocation,SubstansiveAppointment,DateOfAppointment,TermsOfEngagement,CurrentAppointment,StateOfOrigin,DateOfCurrentAppointment,StationName,Carder,HighestQualification,GradeLevel,Step,ConfirmationDate,DateOfRetirement,DateOfPromotion")] biodata biodata)
        {
           

            if (ModelState.IsValid)
            {
                var stf = _context.biodata.Where(u => (u.SprpNo == biodata.SprpNo)).FirstOrDefault();
                if (stf!= null)
                {
                    PopulateDepartmentDropDownList();

                    PopulateStationDropDownList();
                  
                    PopulateCountryMasterDropDownList();
                    ModelState.AddModelError("", "SPRP already In our Registered");

                    return View();
                }
                //if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
                //{
                    
                //    return RedirectToAction("Index", "registers");
                //}

                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                string Contry = "";
                string State = "";
               // string Lga = "";
               
                var country = _context.CountryMaster.Where(u => (u.ID == Convert.ToInt32(HttpContext.Request.Form["Natinality"].ToString()))).FirstOrDefault();
                if (country != null)
                {
                    Contry=country.Natinality;
                }
                var state = _context.states.Where(u => (u.state_id == Convert.ToInt32(HttpContext.Request.Form["StateOfOrigin"].ToString()))).FirstOrDefault();
                if (state != null)
                {
                    State = state.StateOfOrigin;
                }

                /*  var lga = _context.locals.Where(u => (u.local_id == Convert.ToInt32(HttpContext.Request.Form["LGAOrigin"].ToString()))).FirstOrDefault();
                  if (lga != null)
                  {
                     Lga = lga.LGAOrigin;
                  }*/
                DateTime cmdate = Convert.ToDateTime(biodata.DateOfFirstAppointment);
                DateTime Dofa = Convert.ToDateTime(biodata.DateOfFirstAppointment);
                DateTime Dob = Convert.ToDateTime(biodata.DateOfBirth);
                DateTime  Dofar = Convert.ToDateTime(biodata.DateOfFirstArrival);
                DateTime Dofca = Convert.ToDateTime(biodata.DateOfCurrentAppointment);
                DateTime Rtdate = new DateTime();
                cmdate =  cmdate.AddYears(2);
                DateTime Pdate = new DateTime();
                if (biodata.Carder == "Research Officer" || biodata.Carder == "Libarian")
                {
               Rtdate = Convert.ToDateTime(biodata.DateOfBirth);
                    Int32 rtYr=Rtdate.Year;
                    if (rtYr>Yr)
                    {
                        PopulateDepartmentDropDownList();

                        PopulateStationDropDownList();

                        PopulateCountryMasterDropDownList();
                        ModelState.AddModelError("", "Invalid Date Of Birth Selected");

                        return View();
                    }
                    rtYr = Yr - rtYr;
                    rtYr = 65 - rtYr;
                    Rtdate = Rtdate.AddYears(rtYr);
                }               
                else 
                {
                    Rtdate = Convert.ToDateTime(biodata.DateOfBirth);
                    Int32 rtYr = Rtdate.Year;
                    if (rtYr > Yr)
                    {
                        PopulateDepartmentDropDownList();

                        PopulateStationDropDownList();

                        PopulateCountryMasterDropDownList();
                        ModelState.AddModelError("", "Invalid Date Of Birth Selected");

                        return View();
                    }
                    rtYr = Yr - rtYr;
                    if (rtYr<=25 && rtYr>0)
                    {
                        Rtdate = Rtdate.AddYears(35);
                    }
                    else
                    {
                        rtYr = 60 - rtYr;
                       
                      Rtdate = Rtdate.AddYears(rtYr);
                       
                    }
                   
                }
                //else if (biodata.Carder == "Scientist")
                //{
                //    Rtdate = Convert.ToDateTime(biodata.DateOfBirth);
                //    Int32 rtYr = Rtdate.Year;
                //    if (rtYr > Yr)
                //    {
                //        PopulateDepartmentDropDownList();

                //        PopulateStationDropDownList();

                //        PopulateCountryMasterDropDownList();
                //        ModelState.AddModelError("", "Invalid Date Of Birth Selected");

                //        return View();
                //    }
                //    rtYr = Yr - rtYr;
                //    if (rtYr <= 25 && rtYr > 0)
                //    {
                //        Rtdate = Rtdate.AddYears(35);
                //    }
                //    else
                //    {
                //        rtYr = 60 - rtYr;

                //        Rtdate = Rtdate.AddYears(rtYr);

                //    }
                //}
                Int32 NoOfDay = ( Rtdate- CurrentServerTime).Days;
                string rStatus = "";
                if (NoOfDay<=90)
                {
                    rStatus = "Waiting";
                }
                Int32 RYer = Rtdate.Year;
                if (RYer==Yr)
                {
                    rStatus = "Due";
                }
                Pdate = Convert.ToDateTime(biodata.DateOfCurrentAppointment);
                if (biodata.GradeLevel == "CON_R 1" || biodata.GradeLevel == "CON_R 2" || biodata.GradeLevel == "CON_R 3" || biodata.GradeLevel == "CON_R 4" || biodata.GradeLevel == "CON_R 5")
                {
                    
                    Pdate = Pdate.AddYears(2);
                }
                else if (biodata.GradeLevel == "CON_R 6" || biodata.GradeLevel == "CON_R 7" || biodata.GradeLevel == "CON_R 8" || biodata.GradeLevel == "CON_R 9" || biodata.GradeLevel == "CON_R 10" || biodata.GradeLevel == "CON_R 11")
                {
                    Pdate = Pdate.AddYears(3);

                }
                else if (biodata.GradeLevel == "CON_R 12" || biodata.GradeLevel == "CON_R 13" || biodata.GradeLevel == "CON_R 14" || biodata.GradeLevel == "CON_R 15")
                {
                    Pdate = Pdate.AddYears(4);
                }
                
                string PDate = Convert.ToString(Pdate.ToString(formats));
                string CDate= Convert.ToString(cmdate.ToString(formats));
                string RDate = Convert.ToString(Rtdate.ToString(formats));
                string userID = HttpContext.Session.GetString("UserID");
                decimal gl = 0;
                if (biodata.GradeLevel == "CON_R 15")
                {
                    gl = 15;
                }
                else if (biodata.GradeLevel == "CON_R 14")
                {
                    gl = 14;
                }
                else if (biodata.GradeLevel == "CON_R 13")
                {
                    gl = 13;
                }
                else if (biodata.GradeLevel == "CON_R 12")
                {
                    gl = 12;
                }
                else if (biodata.GradeLevel == "CON_R 11")
                {
                    gl = 11;
                }
                else if (biodata.GradeLevel == "CON_R 10")
                {
                    gl = 10;
                }
                else if (biodata.GradeLevel == "CON_R 9")
                {
                    gl = 9;
                }
                else if (biodata.GradeLevel == "CON_R 8")
                {
                    gl = 8;
                }
                else if (biodata.GradeLevel == "CON_R 7")
                {
                    gl = 7;
                }
                else if (biodata.GradeLevel == "CON_R 6")
                {
                    gl = 6;
                }
                else if (biodata.GradeLevel == "CON_R 5")
                {
                    gl = 5;
                }
                else if (biodata.GradeLevel == "CON_R 4")
                {
                    gl = 4;
                }
                else if (biodata.GradeLevel == "CON_R 3")
                {
                    gl = 3;
                }
                else if (biodata.GradeLevel == "CON_R 2")
                {
                    gl = 2;
                }
                else if (biodata.GradeLevel == "CON_R 1")
                {
                    gl = 1;
                }
                biodata.Gl = gl;
                biodata.ConfirmationDate = cmdate;
                biodata.DateOfRetirement = Rtdate;
                biodata.DateOfPromotion = Pdate;
                biodata.DateOfCurrentAppointment = biodata.DateOfCurrentAppointment;
                biodata.GeographicalLocation = biodata.GeographicalLocation;
                biodata.SubstansiveAppointment = biodata.SubstansiveAppointment;
                biodata.DateOfAppointment = "";
                biodata.TermsOfEngagement = biodata.TermsOfEngagement;
                biodata.CurrentAppointment = biodata.CurrentAppointment;
                biodata.StateOfOrigin = State;
                biodata.LGAOrigin = biodata.LGAOrigin;
                biodata.Surname = biodata.Surname;
                biodata.MiddleName = biodata.MiddleName;
                biodata.FirstName = biodata.FirstName;
                biodata.SprpNo = biodata.SprpNo;
                biodata.Sex = biodata.Sex;
                biodata.RStatus = rStatus;
                biodata.Decoration = biodata.Decoration;
                biodata.Natinality = Contry;
                biodata.DateOfBirth = biodata.DateOfBirth;
                biodata.PlaceOfBirth = biodata.PlaceOfBirth;
                biodata.CheckBy = userID;
                biodata.Proof = biodata.Proof;
                biodata.Date = DateTime.UtcNow.Date;
                biodata.Dates = dates;
                biodata.Time = DateTime.UtcNow.ToLongTimeString();
                biodata.Status = "No";
                biodata.HomeAddress = biodata.HomeAddress;
                biodata.Department = biodata.Department;
                biodata.DateOfFirstAppointment = biodata.DateOfFirstAppointment;
                biodata.DateOfFirstArrival = biodata.DateOfFirstArrival;
                biodata.Carder = biodata.Carder;
                biodata.HighestQualification = biodata.HighestQualification;
                _context.Add(biodata);
              int i= await _context.SaveChangesAsync();
                if (i>0)
                {
                    
                    register reg = new register();
                    reg.Surname = biodata.Surname;
                    reg.MiddleName = biodata.MiddleName;
                    reg.FirstName = biodata.FirstName;
                    reg.SprpNo = biodata.SprpNo;
                    reg.UserID = userID;
                    reg.DOB = Dob;
                    reg.DOFA = Dofa;
                    reg.DOR = Rtdate;
                    reg.Status = "No";
                    _contex.Add(reg);
                    await _contex.SaveChangesAsync();
                }
                HttpContext.Session.SetString("SPRP", biodata.SprpNo);
               
                PopulateDepartmentDropDownList();

                PopulateStationDropDownList();
               
                PopulateCountryMasterDropDownList();
               // return View();


                // return Json(new { result = "Redirect", url = Url.Action("ActionName", "ControllerName") });

                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();
           
            PopulateCountryMasterDropDownList();
           
            return View(biodata);
        }

        // GET: biodatas/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(string id)
        {
          
            if (id == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            var biodata = await _context.biodata.FindAsync(id);
            if (biodata == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();
        
            PopulateCountryMasterDropDownList();
            return View(biodata);
        }

        
             public JsonResult GetCadre(string DeptID)
        {
            List<designation> Cadrelist = new List<designation>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            Cadrelist = (from category in _context.designation where category.DeptID == DeptID orderby category.Cadre ascending select category).ToList();
            //Cadrelist = (from category in _context.designation.Where(category => category.DeptID == DeptID).Select(category => category.Cadre).Distinct().OrderBy(category => category).AsEnumerable());
            // ------- Inserting Select Item in List -------
            Cadrelist.Insert(0, new designation { DesignationID = 0, Cadre = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------


            return Json(new SelectList(Cadrelist, "Cadre", "Cadre"));
        }
        public JsonResult GetDesignation(string DeptID)
        {
            List<designation> designationlist = new List<designation>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            designationlist = (from category in _context.designation where category.Cadre==DeptID orderby category.Decoration ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            designationlist.Insert(0, new designation { DesignationID = 0, Decoration = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
          

            return Json(new SelectList(designationlist, "Decoration", "Decoration"));
        }
        public JsonResult GetLocal(int state_id)
        {
            List<locals> localsList = new List<locals>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            localsList = (from product in _context.locals
                           where product.state_id == state_id
                          select product).ToList();

            // ------- Inserting Select Item in List -------
            localsList.Insert(0, new locals { local_id = 0, LGAOrigin = "---Select---" });

            return Json(new SelectList(localsList, "LGAOrigin", "LGAOrigin"));
        }
        public JsonResult GetState(int ID)
        {
            List<states> stateslist = new List<states>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            stateslist = (from subcategory in _context.states
                               where subcategory.CountryId == ID
                               select subcategory).ToList();

            // ------- Inserting Select Item in List -------
            stateslist.Insert(0, new states { state_id = 0, StateOfOrigin = "---Select---" });


            return Json(new SelectList(stateslist, "state_id", "StateOfOrigin"));
        }
        private void PopulateStateMasterDropDownList()
        {
            List<CountryMaster> CountryMasterlist = new List<CountryMaster>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            CountryMasterlist = (from category in _context.CountryMaster orderby category.Natinality ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            CountryMasterlist.Insert(0, new CountryMaster { CountryCode = "", Natinality = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofCountryMaster = CountryMasterlist;
        }
        
        private void PopulateCitiesMasterDropDownList()
        {
            List<CountryMaster> CountryMasterlist = new List<CountryMaster>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            CountryMasterlist = (from category in _context.CountryMaster orderby category.Natinality ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            CountryMasterlist.Insert(0, new CountryMaster { CountryCode = "", Natinality = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofCountryMaster = CountryMasterlist;
        }
        private void PopulateCountryMasterDropDownList()
        {
            List<CountryMaster> CountryMasterlist = new List<CountryMaster>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            CountryMasterlist = (from category in _context.CountryMaster orderby category.Natinality ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            CountryMasterlist.Insert(0, new CountryMaster { ID = 0, Natinality = "---Select---" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofCountryMaster = CountryMasterlist;
        }
        private void PopulateStationDropDownList()
        {
            List<station> stationlist = new List<station>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            stationlist = (from category in _context.station orderby category.StationName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            stationlist.Insert(0, new station { StationID = 0, StationName = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofStation = stationlist;
        }
        private void PopulateDepartmentDropDownList()
        {

            List<department> departmentlist = new List<department>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            departmentlist = (from category in _context.department orderby category.Department ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            departmentlist.Insert(0, new department { DeptID = 0, Department = "Select" });
            // ------- Assigning categorylist to ViewBag.ListofCategory -------
            ViewBag.ListofDept = departmentlist;
        }
        
        // POST: biodatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Surname,MiddleName,FirstName,SprpNo,Sex,Decoration,Natinality,DateOfFirstArrival,LGAOrigin,PlaceOfBirth,CheckBy,Proof,Date,Dates,Time,Status,HomeAddress,Department,GeographicalLocation,SubstansiveAppointment,DateOfAppointment,TermsOfEngagement,CurrentAppointment,StateOfOrigin,StationName,Carder,HighestQualification,GradeLevel,Step")] biodata biodata)
        {
          
            if (id != biodata.SprpNo)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SPRP")) || HttpContext.Session.GetString("SPRP") == "")
            {

                return RedirectToAction("Index", "registers");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var stf = _context.biodata.Where(u => (u.SprpNo == biodata.SprpNo)).FirstOrDefault();
                    if (stf == null)
                    {
                        PopulateDepartmentDropDownList();

                        PopulateStationDropDownList();
                      
                        PopulateCountryMasterDropDownList();
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
                    decimal gl = 0;
                    if (biodata.GradeLevel == "CON_R 15")
                    {
                        gl = 15;
                    }
                    else if (biodata.GradeLevel == "CON_R 14")
                    {
                        gl = 14;
                    }
                    else if (biodata.GradeLevel == "CON_R 13")
                    {
                        gl = 13;
                    }
                    else if (biodata.GradeLevel == "CON_R 12")
                    {
                        gl = 12;
                    }
                    else if (biodata.GradeLevel == "CON_R 11")
                    {
                        gl = 11;
                    }
                    else if (biodata.GradeLevel == "CON_R 10")
                    {
                        gl = 10;
                    }
                    else if (biodata.GradeLevel == "CON_R 9")
                    {
                        gl = 9;
                    }
                    else if (biodata.GradeLevel == "CON_R 8")
                    {
                        gl = 8;
                    }
                    else if (biodata.GradeLevel == "CON_R 7")
                    {
                        gl = 7;
                    }
                    else if (biodata.GradeLevel == "CON_R 6")
                    {
                        gl = 6;
                    }
                    else if (biodata.GradeLevel == "CON_R 5")
                    {
                        gl = 5;
                    }
                    else if (biodata.GradeLevel == "CON_R 4")
                    {
                        gl = 4;
                    }
                    else if (biodata.GradeLevel == "CON_R 3")
                    {
                        gl = 3;
                    }
                    else if (biodata.GradeLevel == "CON_R 2")
                    {
                        gl = 2;
                    }
                    else if (biodata.GradeLevel == "CON_R 1")
                    {
                        gl = 1;
                    }
                    biodata.Gl = gl;
                    biodata.GeographicalLocation = biodata.GeographicalLocation;
                    biodata.SubstansiveAppointment = biodata.SubstansiveAppointment;
                    biodata.DateOfAppointment = "";
                    biodata.TermsOfEngagement = biodata.TermsOfEngagement;
                    biodata.CurrentAppointment = biodata.CurrentAppointment;
                    biodata.StateOfOrigin = biodata.StateOfOrigin;
                    biodata.LGAOrigin = biodata.LGAOrigin;
                    biodata.Surname = biodata.Surname;
                    biodata.MiddleName = biodata.MiddleName;
                    biodata.FirstName = biodata.FirstName;
                    biodata.SprpNo = biodata.SprpNo;
                    biodata.Sex = biodata.Sex;
                    biodata.Decoration = biodata.Decoration;
                    biodata.Natinality = biodata.Natinality;
                    biodata.PlaceOfBirth = biodata.PlaceOfBirth;
                    biodata.CheckBy = biodata.CheckBy;
                    biodata.Proof = biodata.Proof;
                    biodata.Date = DateTime.UtcNow.Date;
                    biodata.Dates = dates;
                    biodata.Time = DateTime.UtcNow.ToLongTimeString();
                    biodata.Status = "No";
                    biodata.HomeAddress = biodata.HomeAddress;
                    biodata.Department = biodata.Department;

                    biodata.DateOfFirstArrival = biodata.DateOfFirstArrival;
                    biodata.Carder = biodata.Carder;
                    biodata.HighestQualification = biodata.HighestQualification;
                    _context.Update(biodata);
                  int i=  await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var reg = _context.register.Where(u => (u.SprpNo == biodata.SprpNo)).FirstOrDefault();
                        if (reg == null)
                        {
                            reg.Surname = biodata.Surname;
                            reg.MiddleName = biodata.MiddleName;
                            reg.FirstName = biodata.FirstName;
                            reg.SprpNo = biodata.SprpNo;
                            reg.UserID = userID;
                            _context.Update(reg);
                            await _contex.SaveChangesAsync();
                        }
                    }
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
            PopulateDepartmentDropDownList();

            PopulateStationDropDownList();

            PopulateCountryMasterDropDownList();
            return View(biodata);

        }

        // GET: biodatas/Delete/5
        [NoDirectAccess]
        public async Task<IActionResult> Delete(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var biodata = await _context.biodata
                .FirstOrDefaultAsync(m => m.SprpNo == id);
            if (biodata == null)
            {
                return NotFound();
            }

            return View(biodata);
        }

        // POST: biodatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           
            var biodata = await _context.biodata.FindAsync(id);
            _context.biodata.Remove(biodata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool biodataExists(string id)
        {
            return _context.biodata.Any(e => e.SprpNo == id);
        }
    }
}
