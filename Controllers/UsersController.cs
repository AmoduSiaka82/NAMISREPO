using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using NAMIS.ViewModels;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;


namespace NAMIS.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public UsersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }
        [NoDirectAccess]
        public IActionResult Qaulify(UsersTabViewModel vm)
        {
           
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTab = ViewModels.Tab.PreparePromotion
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult Disqaulify(UsersTabViewModel vm)
        {
           
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTab = ViewModels.Tab.PreparePromotion
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult MonthlyReturn(UsersTabViewModel vm)
        {
           
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabM = ViewModels.TabM.MonthlyReturn
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult FileList(UsersTabViewModel vm)
        {
           
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabF = ViewModels.TabF.FileList
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult StaffOnTrainingList(UsersTabViewModel vm)
        {
          
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabT = ViewModels.TabT.StaffOnTrainingList
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult PreparedMemo(UsersTabViewModel vm)
        {
           
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabMe = ViewModels.TabMe.PreparedMemo
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult WriteReport(UsersTabViewModel vm)
        {
            
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabRPT = ViewModels.TabRPT.PreparedRPT
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult PreparedIt(UsersTabViewModel vm)
        {
          
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabI = ViewModels.TabI.PreparedIt
                };
            }
            return View(vm);
        }
        public IActionResult SwitchToTabsV(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "Variation":
                    vm.ActiveTabV = ViewModels.TabV.Variation;
                    break;
                case "VariationList":
                    vm.ActiveTabV = ViewModels.TabV.VariationList;
                    break;
              

                default:
                    vm.ActiveTabV = ViewModels.TabV.ApprovedVariation;
                    break;
            }
            return RedirectToAction(nameof(UsersController.Variation), vm);
        }
        [NoDirectAccess]
        public IActionResult Variation(UsersTabViewModel vm)
        {
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabV = ViewModels.TabV.Variation
                };
            }
            return View(vm);
        }
        public IActionResult SwitchToTabsD(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "Disposition":
                    vm.ActiveTabD = ViewModels.TabD.Disposition;
                    break;
                case "VariationList":
                    vm.ActiveTabD = ViewModels.TabD.DispositionList;
                    break;


                default:
                    vm.ActiveTabD = ViewModels.TabD.ApprovedDisposition;
                    break;
            }
            return RedirectToAction(nameof(UsersController.Disposition), vm);
        }
        [NoDirectAccess]
        public IActionResult Disposition(UsersTabViewModel vm)
        {
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabD = ViewModels.TabD.Disposition
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult LeaveRoster(UsersTabViewModel vm)
        {
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabL = ViewModels.TabL.LeaveRoaster
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult ConfirmationList(UsersTabViewModel vm)
        {
          
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabC = ViewModels.TabC.ConfirmationList
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult PrepareRetirmentList(UsersTabViewModel vm)
        {
            
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabR = ViewModels.TabR.PrepareRetirmentList
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult PostingList(UsersTabViewModel vm)
        {
            
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabP = ViewModels.TabP.PostingList
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public async Task<IActionResult> Box()
        {
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Box where (s.UserID == userID && (s.Status == "Written" || s.Status == "Approved" || s.Status == "Read")) orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public IActionResult ReportFileDetail(string id)
        {
           
            var bio = (from s in _context.reportupload where (s.RId == id) select s);

            return View(bio.ToList());
           
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintReport(string id)
        {
          
            var bio = (from s in _context.reportwriting where s.Status == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintMemo(int id)
        {
          
            var bio = (from s in _context.Memo where s.Status == "Approved" && s.Id==id select s);

            return View( await bio.ToListAsync());
        }
        [NoDirectAccess]
        public IActionResult Index(UsersTabViewModel vm)
        {
            
            if (vm==null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTab = ViewModels.Tab.PreparePromotion
                };
            }
            return View(vm);
        }
        [NoDirectAccess]
        public IActionResult LetterHead(UsersTabViewModel vm)
        {
         
            if (vm == null)
            {
                vm = new UsersTabViewModel
                {
                    ActiveTabRANDM = ViewModels.TabRANDM.LetterHead
                };
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult SubmitPromotion()
        {


          
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Promotion List";
                myBox.Description = "Promotion List Prepared for Approval";
                myBox.Actions = "PromotionList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedPromotion";
                myBox.UController = "Users";
                myBox.UserID =userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.CareerProgression.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.CareerId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            
            return RedirectToAction(nameof(UsersController.Index));

        }
        
            [HttpPost]
        public IActionResult SubmitIT()
        {


            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "IT Student List";
                myBox.Description = "IT Student List Prepared For Approval";
                myBox.Actions = "ITStudent";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedITStudent";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.itstudent.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.PreparedIt));

        }
       
            [HttpPost]
        public IActionResult SubmitMemo()
        {


           
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Memo").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Internal Memoradum";
                myBox.Description = "Memo Prepared For Approval";
                myBox.Actions = "MemoReport";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedMemo";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.Memo.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.WriteReport));

        }
        [HttpPost]
        public IActionResult SubmitRPT()
        {


            
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Actions == "WriteReport").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Report";
                myBox.Description = "Report Prepared For Approval";
                myBox.Actions = "RPTReport";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedRPT";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.reportwriting.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.WriteReport));

        }
        [HttpPost]
        public IActionResult SubmitTraining()
        {


            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
           
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Training List";
                myBox.Description = "Training/Study List Prepared For Approval";
                myBox.Actions = "TrainingAndStudy";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedStaffOnTraining";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.TrainingAndStudy.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.StaffOnTrainingList));

        }
        [HttpPost]
        public IActionResult SubmitFile()
        {


          
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Personel File List";
                myBox.Description = "Personel List Prepared";
                myBox.Actions = "PersonnelFile";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedPersonnelFile";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.PersonelFile.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.FileList));

        }

        [HttpPost]
        public IActionResult SubmitMonthlyReturn()
        {


          
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Monthly Return").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.UserStatus = "Waiting";
                myBox.Subject = "Monthly Return";
                myBox.Description = "Monthly Return";
                myBox.Actions = "MonthlyReturnList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedMonthlyReturn";
                myBox.UController = "Users";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.monthlyreturn.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.MonthlyReturn));

        }
      
             [HttpPost]
        public IActionResult SubmitRetirement()
        {


         
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Staff Retirement List";
                myBox.Description = "Staff Retirement List Prepared for Approval";
                myBox.Actions = "RetirementList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedRetirement";
                myBox.UController = "Users";
                myBox.UserID = userID;
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.UserStatus = "Waiting";
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.retirementbiodata.Where(x => x.Status == "No" && x.CheckBy == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.PrepareRetirmentList));

        }
        [HttpPost]
        public IActionResult SubmitPosting()
        {


            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Posting And Deployment").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Staff Posting And Deployment List";
                myBox.Description = "Staff Posting And Deployment List Prepared for Approval";
                myBox.Actions = "PostingList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedPosting";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.StaffPosting.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.PostingList));

        }
        
            [HttpPost]
        public IActionResult SubmitDailyVehicleMotorWorkBook()
        {


           
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            int iNo;
            string BoxId = "";
            string BoxNo = "";

            DALClass sign = new DALClass(configuration);
            BoxNo = sign.BoxNoAuto().ToString();

            if (BoxNo.Equals("") || BoxNo == null)
            {
                iNo = 00001;
            }
            else
            {
                iNo = int.Parse(BoxNo);
                iNo++;
            }
            if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
            else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
            else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
            else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
            else BoxId = Convert.ToString(iNo);
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Daily Motor Vehicle Work Book").FirstOrDefault();
            //if (sch != null)
            //{
                Box myBox = new Box();
                myBox.Subject = "Daily Motor Vehicle Work Book";
                myBox.Description = "Daily Motor Vehicle Work Book List Prepared for View";
                myBox.Actions = "DailyMotorVehicleWorkBookList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedDailyMotorVehicleWorkBook";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                myBox.ReceiverID = "00010";
                myBox.ReceiverID1 = "00011";
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.UserStatus = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                int i = _context.SaveChanges();
                _context.DailyMotorVehicleWorkBook.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    x.ReceiverID = "00010";
                    x.ReceiverID1 = "00011";
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.DailyID = BoxId;
                    x.Status = "Approved";
                });
                _context.SaveChanges();
            
            return RedirectToAction("Index", "DailyMotorVehicleWorkBooks");
           

        }
       
             [HttpPost]
        public IActionResult SubmitMinute()
        {


           
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
            string MinuteId = HttpContext.Session.GetString("MINUTEID");
           
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Minutes Of The Meeting").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Minutes Of The Meeting";
                myBox.Description = "Minute Of The Meeting Prepared";
                myBox.Actions = "MinuteOfTheMeetingList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedMinuteOfTheMeeting";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.MinuteOfMeeting.Where(x => x.MinuteID== MinuteId && x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    x.ReceiverID = "00010";
                    x.ReceiverID1 = "00011";
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.BoxID = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
                _context.MinuteRegister.Where(x => x.Id== MinuteId && x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    
                    x.Status = "Submitted";
                });
                _context.SaveChanges();
            

            return RedirectToAction("Index", "MinuteRegisters");

        }
        [HttpPost]
        public IActionResult SubmitConfirmation()
        {


            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");
           
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Confirmation List";
                myBox.Description = "Confirmationn List Prepared for Approval";
                myBox.Actions = "ConfirmationList";
                myBox.Controllers = "Boxes";
                myBox.UAction = "ApprovedConfirmation";
                myBox.UController = "Users";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
                //myBox.ReceiverID = sch.AllocatedUserID;
                //myBox.ReceiverID1 = sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.Confirmationofappointment.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.ConId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            

            return RedirectToAction(nameof(UsersController.ConfirmationList));

        }
        [HttpPost]
            public IActionResult SubmitLeave()
        {

            
           
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID=HttpContext.Session.GetString("UserID");
            //var sch = _context.scheduled.Where(u => u.UserID == userID && u.Schedule == "Leave Roster").FirstOrDefault();
            //if (sch != null)
            //{
                int iNo;
                string BoxId = "";
                string BoxNo = "";
                DALClass sign = new DALClass(configuration);
                BoxNo = sign.BoxNoAuto().ToString();

                if (BoxNo.Equals("") || BoxNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(BoxNo);
                    iNo++;
                }
                if (iNo < 10) { BoxId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { BoxId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { BoxId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { BoxId = "0" + Convert.ToString(iNo); }
                else BoxId = Convert.ToString(iNo);
                Box myBox = new Box();
                myBox.Subject = "Leave Roster";
                myBox.Description = "Leave Roster Prepared for Approval";
                myBox.Actions = "LeaveRoster";
                myBox.Controllers = "Boxes";
                myBox.UController = "Users";
                myBox.UAction = "ApprovedLeave";
                myBox.UserID = userID;
                myBox.UserStatus = "Waiting";
               // myBox.ReceiverID= sch.AllocatedUserID;
                //myBox.ReceiverID1= sch.AllocatedUserID;
                //myBox.ReceiverID2 = sch.AllocatedUserID;
                //myBox.ReceiverID3 = sch.AllocatedUserID;
                //myBox.ReceiverID4 = sch.AllocatedUserID;
                myBox.Status = "Waiting";
                myBox.Status1 = "Waiting";
                myBox.Status2 = "Waiting";
                myBox.Status3 = "Waiting";
                myBox.Status4 = "Waiting";
                myBox.IdNo = BoxId;
                myBox.Date = DateTime.UtcNow.Date;
                myBox.Dates = dates;
                myBox.Yr = Convert.ToString(nYear);
                myBox.Mnt = Convert.ToString(nMonth);
                myBox.Dy = Convert.ToString(nDay);
                _context.Add(myBox);
                _context.SaveChanges();
                _context.Leaves.Where(x => x.Status == "No" && x.UserID == userID).ToList().ForEach(x =>
                {
                    //x.ReceiverID = sch.AllocatedUserID;
                    //x.ReceiverID1 = sch.AllocatedUserID;
                    //x.ReceiverID2 = sch.AllocatedUserID;
                    //x.ReceiverID3 = sch.AllocatedUserID;
                    //x.ReceiverID4 = sch.AllocatedUserID;
                    x.BoxId = BoxId;
                    x.Status = "Waiting";
                });
                _context.SaveChanges();
            
            
            return RedirectToAction(nameof(UsersController.LeaveRoster));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessPosting(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            PopulateStationDropDownList();
            return View(leave);

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
        [NoDirectAccess]
        public async Task<IActionResult> ProcessRetirement(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            
            return View(leave);



        }
        [HttpPost]
        public async Task<IActionResult> ProcessRetirement(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
         

            if (string.IsNullOrEmpty(bio.PhoneNo) || string.IsNullOrWhiteSpace(bio.PhoneNo) || bio.PhoneNo == "")
            {
                ModelState.AddModelError("", "Enter Phone No");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }
            if (string.IsNullOrEmpty(bio.NHISNO) || string.IsNullOrWhiteSpace(bio.NHISNO) || bio.NHISNO == "")
            {
                ModelState.AddModelError("", "Enter NHIS NO");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }
            if (string.IsNullOrEmpty(bio.NHFNO) || string.IsNullOrWhiteSpace(bio.NHFNO) || bio.NHFNO == "")
            {
                ModelState.AddModelError("", "Enter NHF No");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }
            if (string.IsNullOrEmpty(bio.IPPISNO) || string.IsNullOrWhiteSpace(bio.IPPISNO) || bio.IPPISNO == "")
            {
                ModelState.AddModelError("", "Enter IPPIS No");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }
            //if (string.IsNullOrEmpty(HttpContext.Request.Form["HighestQualification"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["HighestQualification"].ToString()) || HttpContext.Request.Form["HighestQualification"].ToString() == "")
            //{
            //    ModelState.AddModelError("", "Enter Email Address");
            //    PopulateDepartmentDropDownList();
            //    PopulateStationDropDownList();
            //    return View();

            //}
            //if (string.IsNullOrEmpty(HttpContext.Request.Form["EmailID"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["EmailID"].ToString()) || HttpContext.Request.Form["EmailID"].ToString() == "")
            //{
            //    ModelState.AddModelError("", "Enter Email Address");
            //    PopulateDepartmentDropDownList();
            //    PopulateStationDropDownList();
            //    return View();

            //}
            var stf = _context.retirementbiodata.Where(u => (u.SprpNo == bio.SprpNo)).FirstOrDefault();
            if (stf != null)
            {
               
                ModelState.AddModelError("", "SPRP already In our Registered");

                return View();
            }

            var Ippis = _context.retirementbiodata.Where(u => (u.IPPISNO== bio.IPPISNO)).FirstOrDefault();
            if (Ippis != null)
            {

                ModelState.AddModelError("", "IPPIS No already In our Registered");

                return View();
            }
            var Nhis = _context.retirementbiodata.Where(u => (u.NHISNO == bio.NHISNO)).FirstOrDefault();
            if (Nhis != null)
            {

                ModelState.AddModelError("", "NHIS No already In our Registered");

                return View();
            }

            var Pn = _context.retirementbiodata.Where(u => (u.PhoneNo == bio.PhoneNo)).FirstOrDefault();
            if (Pn != null)
            {

                ModelState.AddModelError("", "Phone No already In our Registered");

                return View();
            }
            var Nhf = _context.retirementbiodata.Where(u => (u.NHFNO== bio.NHFNO)).FirstOrDefault();
            if (Nhf != null)
            {

                ModelState.AddModelError("", "NHF No already In our Registered");

                return View();
            }
            var bios = await _context.biodata.FindAsync(id);
         
            if (string.IsNullOrEmpty(bios.PFA) || string.IsNullOrWhiteSpace(bios.PFA) || bios.PFA == "")
            {
                ModelState.AddModelError("", "Contact Pension Office,No PFA Record available for this Staff");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }

            if (string.IsNullOrEmpty(bios.PinNo) || string.IsNullOrWhiteSpace(bios.PinNo) || bios.PinNo == "")
            {
                ModelState.AddModelError("", "Contact Pension Office,No Pension PIN No Record available for this Staff");
                //PopulateDepartmentDropDownList();
                //PopulateStationDropDownList();
                return View();

            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            int iNo;
            string RId = "";
            string RNo = "";
            DALClass sign = new DALClass(configuration);
            RNo = sign.RNoAuto().ToString();

            if (RNo.Equals("") || RNo == null)
            {
                iNo = 00001;
            }
            else
            {
                iNo = int.Parse(RNo);
                iNo++;
            }
            if (iNo < 10) { RId = "0000" + Convert.ToString(iNo); }
            else if (10 <= iNo && iNo < 100) { RId = "000" + Convert.ToString(iNo); }
            else if (100 <= iNo && iNo < 1000) { RId = "00" + Convert.ToString(iNo); }
            else if (1000 <= iNo && iNo < 10000) { RId = "0" + Convert.ToString(iNo); }
            else RId = Convert.ToString(iNo);
            string userID = HttpContext.Session.GetString("UserID");
            string Station = HttpContext.Session.GetString("station");
            retirementbiodata lv = new retirementbiodata();
            lv.Surname = bio.Surname;
            lv.Id = 0;
            lv.PFA = bios.PFA;
            lv.PinNo = bios.PinNo;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
            lv.SprpNo = bio.SprpNo;
            lv.CurrentAppointment = bio.CurrentAppointment;
            lv.DateOfFirstAppointment = bio.DateOfFirstAppointment;
            lv.DateOfBirth = bio.DateOfBirth;
            lv.DateOfRetirement = bio.DateOfRetirement;
            lv.IPPISNO = bio.IPPISNO;
            lv.NHISNO = bio.NHISNO;
            lv.NHFNO = bio.NHFNO;
            lv.Sex = bio.Sex;
            
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.GradeLevel = bios.GradeLevel;
            lv.Status = "No";
            lv.SprpNo= bios.SprpNo;
            lv.EmailID = bios.EmailID;
            lv.PhoneNo = bio.PhoneNo;
            lv.RMode = bio.RMode;
            lv.StationName = bios.StationName;
            lv.Department = bios.Department;
            lv.HighestQualification = bios.HighestQualification;
            lv.Decoration = bios.Decoration;
            lv.Natinality = bios.Natinality;
            lv.DateOfFirstArrival = bios.DateOfFirstArrival;
            lv.LGAOrigin = bios.LGAOrigin;
            lv.PlaceOfBirth = bios.PlaceOfBirth;
            lv.Proof = bios.Proof;
            lv.HomeAddress = bios.HomeAddress;
            lv.GeographicalLocation = bios.GeographicalLocation;
            lv.SubstansiveAppointment = bios.SubstansiveAppointment;
            lv.DateOfAppointment = bios.DateOfAppointment;
            lv.TermsOfEngagement = bios.TermsOfEngagement;
            lv.StateOfOrigin = bios.StateOfOrigin;
            lv.DateOfCurrentAppointment = bios.DateOfCurrentAppointment;
            lv.Carder = bios.Carder;
            lv.EdNote = bios.EdNote;
            lv.HodNote = bios.HodNote;
            lv.UnitNote = bios.UnitNote;
            lv.Step = bios.Step;
            lv.TrainingStatus = bios.TrainingStatus;
            lv.QualificationInView = bios.QualificationInView;
            lv.ProStatus = bios.ProStatus;
            lv.RStatus = bios.RStatus;
            lv.ProYr = bios.ProYr;
            lv.RYr = bios.RYr;
            lv.AppointmentStatus = bios.AppointmentStatus;
            lv.ConfirmationDate = bios.ConfirmationDate;
            lv.ConfirmationYr = bios.ConfirmationYr;
            lv.DateOfPromotion = bios.DateOfPromotion;
            lv.EmailID = bios.EmailID;
            lv.CheckBy= userID;
            lv.RId = RId;
            _context.Add(lv);
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.biodata.Where(x => x.SprpNo == id).ToList().ForEach(x =>
                {
                    x.PhoneNo = bio.PhoneNo;
                    x.NHFNO = bio.NHFNO;
                    x.NHISNO = bio.NHISNO;
                    x.IPPISNO = bio.IPPISNO;
                    x.RMode = bio.RMode;
                });
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(PrepareRetirmentList));

        }
        [HttpPost]
        public async Task<IActionResult> ProcessMonthlyReturn(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
           

            if (string.IsNullOrEmpty(HttpContext.Request.Form["PhoneNo"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["PhoneNo"].ToString()) || HttpContext.Request.Form["PhoneNo"].ToString() == "")
            {
                ModelState.AddModelError("", "Enter Phone No");
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return View();

            }
            
                 if (string.IsNullOrEmpty(HttpContext.Request.Form["HighestQualification"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["HighestQualification"].ToString()) || HttpContext.Request.Form["HighestQualification"].ToString() == "")
            {
                ModelState.AddModelError("", "Enter Email Address");
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return View();

            }
            if (string.IsNullOrEmpty(HttpContext.Request.Form["EmailID"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["EmailID"].ToString()) || HttpContext.Request.Form["EmailID"].ToString() == "")
            {
                ModelState.AddModelError("", "Enter Email Address");
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return View();

            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            //int iNo;
            //string LeaveId = "";
            //string LeaveNo = "";
            string userID = HttpContext.Session.GetString("UserID");
            //DALClass sign = new DALClass(configuration);
            //LeaveNo = sign.PostNoAuto().ToString();

            //if (LeaveNo.Equals("") || LeaveNo == null)
            //{
            //    iNo = 00001;
            //}
            //else
            //{
            //    iNo = int.Parse(LeaveNo);
            //    iNo++;
            //}

            //if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            //else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            //else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            //else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            //else LeaveId = Convert.ToString(iNo);
            string Station = HttpContext.Session.GetString("station");
            monthlyreturn lv = new monthlyreturn();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
           lv.RDate= Convert.ToDateTime(HttpContext.Request.Form["rDate"]);
            
            lv.SprpNo = bio.SprpNo;
            lv.CurrentAppointment = bio.CurrentAppointment;
            lv.DateOfCurrentAppointment = bio.DateOfCurrentAppointment;
            
            lv.SprpNo = bio.SprpNo;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.GradeLevel = bio.GradeLevel;
            lv.Status = "No";
            lv.Id = 0;
            
                
            lv.EmailID = HttpContext.Request.Form["EmailID"].ToString();
            lv.PhoneNo = HttpContext.Request.Form["PhoneNo"].ToString();
            lv.StationName = bio.StationName;
            lv.Department = bio.Department;
            lv.HighestQualification = HttpContext.Request.Form["HighestQualification"].ToString();
            lv.UserID = userID;
            _context.Add(lv);
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {

                _context.biodata.Where(x => x.SprpNo == id).ToList().ForEach(x =>
                {

                    x.EmailID = HttpContext.Request.Form["EmailID"].ToString();
                    x.PhoneNo = HttpContext.Request.Form["PhoneNo"].ToString();
                    x.HighestQualification = HttpContext.Request.Form["HighestQualification"].ToString();
                    

                });
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(MonthlyReturn));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessMonthlyReturn(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
        
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            PopulateDepartmentDropDownList();
            PopulateStationDropDownList();
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ProcessPosting(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
         
           
            if (string.IsNullOrEmpty(HttpContext.Request.Form["Department"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["Department"].ToString()) || HttpContext.Request.Form["Department"].ToString() == "" || HttpContext.Request.Form["Department"].ToString() == "Select")
            {
                ModelState.AddModelError("", "Please Select Department");
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return View();
                
            }
            if (string.IsNullOrEmpty(HttpContext.Request.Form["StationName"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["StationName"].ToString()) || HttpContext.Request.Form["StationName"].ToString() == "Select" || HttpContext.Request.Form["StationName"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Station");
                PopulateDepartmentDropDownList();
                PopulateStationDropDownList();
                return View();

            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            //int iNo;
            //string LeaveId = "";
            //string LeaveNo = "";
            string userID = HttpContext.Session.GetString("UserID");
            //DALClass sign = new DALClass(configuration);
            //LeaveNo = sign.PostNoAuto().ToString();

            //if (LeaveNo.Equals("") || LeaveNo == null)
            //{
            //    iNo = 00001;
            //}
            //else
            //{
            //    iNo = int.Parse(LeaveNo);
            //    iNo++;
            //}

            //if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            //else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            //else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            //else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            //else LeaveId = Convert.ToString(iNo);
            string Station = HttpContext.Session.GetString("station");
            StaffPosting lv = new StaffPosting();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
            lv.Sex = bio.Sex;
            lv.DateOfResumetion = bio.DateOfResumetion;
            lv.SprpNo = bio.SprpNo;
            lv.CurrentAppointment = bio.CurrentAppointment;
            lv.DateOfFirstAppointment = bio.DateOfFirstAppointment;
            lv.DateDue = bio.ConfirmationDate;
            lv.SprpNo = bio.SprpNo;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.GradeLevel = bio.GradeLevel;
            lv.Status = "No";
            lv.Id = 0;
            lv.StationName = HttpContext.Request.Form["StationName"].ToString();
            lv.Department = HttpContext.Request.Form["Department"].ToString();
            lv.HighestQualification =bio.HighestQualification;
            lv.UserID = userID;
            _context.Add(lv);
            int i=await _context.SaveChangesAsync();
            if (i>0)
            {
                
                _context.biodata.Where(x =>  x.SprpNo == id).ToList().ForEach(x =>
                {
                    
                    
                    x.StationName = HttpContext.Request.Form["StationName"].ToString();
                    x.Department = HttpContext.Request.Form["Department"].ToString();
                    x.CheckBy = userID;
                    
                });
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(PostingList));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessConfirmation(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            GetDesignation();
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ProcessConfirmation(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
          
            //if (HttpContext.Request.Form["Remark"].ToString() == "")
            //{
            //    ModelState.AddModelError("", "Please enter remark");
            //   GetDesignation();
            //  return View();
            //}

            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            int iNo;
            string LeaveId = "";
            string LeaveNo = "";
            string userID = HttpContext.Session.GetString("UserID");
            DALClass sign = new DALClass(configuration);
            LeaveNo = sign.ConNoAuto().ToString();

            if (LeaveNo.Equals("") || LeaveNo == null)
            {
                iNo = 00001;
            }
            else
            {
                iNo = int.Parse(LeaveNo);
                iNo++;
            }
            if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            else LeaveId = Convert.ToString(iNo);
            string Station = HttpContext.Session.GetString("station");
            Confirmationofappointment lv = new Confirmationofappointment();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
            lv.Sex = bio.Sex;
            lv.Department = bio.Department;
            lv.SprpNo = bio.SprpNo;
            lv.CurrentAppointment = bio.CurrentAppointment;
            lv.Department = bio.Department;
            lv.DateOfFirstAppointment =bio.DateOfFirstAppointment;
            lv.DateDue = bio.ConfirmationDate;
            lv.SprpNo = bio.SprpNo;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.GradeLevel = bio.GradeLevel;
            lv.Status = "No";
            lv.Id = 0;
            lv.StationName = Station;

            lv.Remark = HttpContext.Request.Form["Remark"].ToString();
            lv.UserID = userID;
            
         
            _context.Add(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.ConfirmationList));
           

        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessPromotion(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            GetDesignation();
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ProcessPromotion(string id,biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
         
            if (HttpContext.Request.Form["CurrentAppointmen"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Rank");
                GetDesignation();
                return View();
            }
            if (HttpContext.Request.Form["Steps"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Step");
                GetDesignation();
                return View();
            }
            if (HttpContext.Request.Form["ProposeGrade"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Propose Grade");
                GetDesignation();
                return View();
            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            string userID = HttpContext.Session.GetString("UserID");
            
            string Station = HttpContext.Session.GetString("station");
            int iNo;
            string LeaveId = "";
            string LeaveNo = "";
            DALClass sign = new DALClass(configuration);
            LeaveNo = sign.ProNoAuto().ToString();

            if (LeaveNo.Equals("") || LeaveNo == null)
            {
                iNo = 00001;
            }
            else
            {
                iNo = int.Parse(LeaveNo);
                iNo++;
            }
            if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            else LeaveId = Convert.ToString(iNo);
            CareerProgression lv = new CareerProgression();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
            
            lv.Department = bio.Department;
            lv.SprpNo = bio.SprpNo;
            
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.DateOfFirstAppointment = bio.DateOfFirstAppointment;
            lv.Status = "No";
            lv.Id = 0;
            lv.CurrentAppointment = bio.CurrentAppointment;
            lv.DateofCurrentAppointment = bio.DateOfCurrentAppointment;
            lv.UserID = userID;
            lv.GradeLevel = bio.GradeLevel;
            lv.Step = bio.Step;
            lv.StationName = Station;
            
            lv.ProposeRank = HttpContext.Request.Form["CurrentAppointmen"].ToString();
            lv.ProposeGrade = HttpContext.Request.Form["ProposeGrade"].ToString();
            lv.ProposeStep = HttpContext.Request.Form["Steps"].ToString();
            _context.Add(lv);
            await _context.SaveChangesAsync();
            GetDesignation();
            return RedirectToAction(nameof(UsersController.Index));
           

        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessTraining(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ProcessTraining(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
          
           
            if (HttpContext.Request.Form["date"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["date"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["date"].ToString()))
            {
                ModelState.AddModelError("", "Please Select Start Date");

                return View();
            }
            if (HttpContext.Request.Form["dates"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["dates"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["dates"].ToString()))
            {
                ModelState.AddModelError("", "Please Select Expected Date of Completion");
               
                return View();
            }
            
            if (HttpContext.Request.Form["TrainingDescription"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["TrainingDescription"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["TrainingDescription"].ToString()))
            {
                ModelState.AddModelError("", "Please Enter Training Description");
               
                return View();
            }
            if (HttpContext.Request.Form["QualificationInView"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["QualificationInView"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["QualificationInView"].ToString()))
            {
                ModelState.AddModelError("", "Please Select Qualification In View");

                return View();
            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            Int32 noofDay = 0;
            Int32 noofDays = 0;

            string userID = HttpContext.Session.GetString("UserID");
            DateTime SD = Convert.ToDateTime(HttpContext.Request.Form["date"].ToString());
            string SDates = Convert.ToString(SD.ToString(format));
            string SDate = Convert.ToString(SD.ToString(formats));
            DateTime eD = Convert.ToDateTime(HttpContext.Request.Form["dates"].ToString());
            string eDates = Convert.ToString(eD.ToString(format));
            string eDate = Convert.ToString(eD.ToString(formats));
            string Station = HttpContext.Session.GetString("station");
            Int32 sYear = SD.Year;
            Int32 sMonth = SD.Month;
            Int32 sDay = SD.Day;
            Int32 eYear = eD.Year;
            Int32 eMonth = eD.Month;
            Int32 eDay = eD.Day;
            if (eYear < nYear)
            {

                ModelState.AddModelError("", "Selected Completion Year cannot be less than the current Year");

                return View();
            }
            if (sYear < nYear)
            {

                ModelState.AddModelError("", "Selected Start Year cannot be less than the current Year");

                return View();
            }
            noofDay = (eD - SD).Days;
            noofDays = (SD- CurrentServerTime).Days;
            if (noofDay<0)
            {
                ModelState.AddModelError("", "Please Check Date Of Completion must be grater than Start Date");
                
                return View();
            }
            //int iNo;
            //string LeaveId = "";
            //string LeaveNo = "";
            //DALClass sign = new DALClass(configuration);
            //LeaveNo = sign.ProNoAuto().ToString();

            //if (LeaveNo.Equals("") || LeaveNo == null)
            //{
            //    iNo = 00001;
            //}
            //else
            //{
            //    iNo = int.Parse(LeaveNo);
            //    iNo++;
            //}
            //if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            //else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            //else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            //else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            //else LeaveId = Convert.ToString(iNo);
            TrainingAndStudy lv = new TrainingAndStudy();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FirstName = bio.FirstName;
            lv.SprpNo = bio.SprpNo;
            lv.NoOfDays = Convert.ToString(noofDay);
            lv.Department = bio.Department;
            lv.StationName = bio.StationName;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Time = time;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.Status = "No";
            lv.UserID = userID;
            lv.Id = 0;
            lv.GradeLevel = bio.GradeLevel;
            lv.Step = bio.Step;
            lv.HighestQualification = bio.HighestQualification;
            lv.TrainingDescription = HttpContext.Request.Form["TrainingDescription"].ToString();
            lv.SDate = SD;
            lv.SDates = SDates;
            lv.EDate = eD;
            lv.EDates = eDates;
            lv.QualificationInView = HttpContext.Request.Form["QualificationInView"].ToString();
            _context.Add(lv);
          int i=  await _context.SaveChangesAsync();
            if (i>0)
            {
                string trStatus = "";
                if (noofDays<=0)
                {
                    trStatus = "On Training";
                }
                else { trStatus = "Waiting"; }
                _context.biodata.Where(x =>  x.SprpNo ==bio.SprpNo).ToList().ForEach(x =>
                {
                    x.QualificationInView = HttpContext.Request.Form["QualificationInView"].ToString();
                    x.TrainingStatus = trStatus;
                });
                await _context.SaveChangesAsync();

            }
           
            return RedirectToAction(nameof(UsersController.StaffOnTrainingList));
        }
        [NoDirectAccess]
        public async Task<IActionResult> ProcessFile(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.biodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            FileDesignation();
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ProcessFile(string id, biodata bio)
        {

            if (id != bio.SprpNo)
            {
                return NotFound();
            }
           
            if (HttpContext.Request.Form["time"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["time"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["time"].ToString()))
            {

                ModelState.AddModelError("", "Please Select Time Out");
                FileDesignation();
            }
            //if (HttpContext.Request.Form["dates"].ToString() == "" || string.IsNullOrEmpty(HttpContext.Request.Form["dates"].ToString()) || string.IsNullOrWhiteSpace(HttpContext.Request.Form["dates"].ToString()))
            //{
            //    ModelState.AddModelError("", "Please Select Expected Date of Return");
            //    FileDesignation();
            //    return View();
            //}
           
            if (HttpContext.Request.Form["destinationName"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select File Destination");
                FileDesignation();
                return View();
            }
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            DateTime DateOfFirstApp = Convert.ToDateTime(bio.DateOfFirstAppointment);
            DateTime DateOfCurrentApp = Convert.ToDateTime(bio.DateOfCurrentAppointment);
            string dateOfFirstAppoint = Convert.ToString(DateOfFirstApp.ToString(formats));
            string dateOfCurrentAppoint = Convert.ToString(DateOfCurrentApp.ToString(formats));
            string userID = HttpContext.Session.GetString("UserID");
            DateTime exD = Convert.ToDateTime(HttpContext.Request.Form["dates"].ToString());
            string exDates = Convert.ToString(exD.ToString(format));
            string exDate = Convert.ToString(exD.ToString(formats));
            string Station = HttpContext.Session.GetString("station");
            //int iNo;
            //string LeaveId = "";
            //string LeaveNo = "";
            //DALClass sign = new DALClass(configuration);
            //LeaveNo = sign.ProNoAuto().ToString();

            //if (LeaveNo.Equals("") || LeaveNo == null)
            //{
            //    iNo = 00001;
            //}
            //else
            //{
            //    iNo = int.Parse(LeaveNo);
            //    iNo++;
            //}
            //if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            //else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            //else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            //else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            //else LeaveId = Convert.ToString(iNo);
            PersonelFile lv = new PersonelFile();
            lv.Surname = bio.Surname;
            lv.MiddleName = bio.MiddleName;
            lv.FistName = bio.FirstName;  
            lv.SprpNo = bio.SprpNo;
            lv.YourName= HttpContext.Request.Form["YourName"].ToString();
            lv.Department = bio.Department;
            lv.StationName = bio.StationName;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Time = HttpContext.Request.Form["time"].ToString();
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);          
            lv.Status = "No";
            lv.UserID = userID;
            lv.ID = 0;
            lv.Remark = HttpContext.Request.Form["Remark"].ToString();
            lv.ExpDate = exD;
            lv.ExpDates = exDates;
            lv.DestinationName = HttpContext.Request.Form["destinationName"].ToString();
            _context.Add(lv);
            await _context.SaveChangesAsync();
            FileDesignation();
            return RedirectToAction(nameof(UsersController.FileList));


        }
        private void FileDesignation()
        {
            string DeptID = HttpContext.Session.GetString("Department");
            List<FileDestination> FileDestinationlist = new List<FileDestination>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            FileDestinationlist = (from category in _context.FileDestination orderby category.DestinationName ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            FileDestinationlist.Insert(0, new FileDestination { ID = 0, DestinationName = "---Select---" });
            ViewBag.ListofDest = FileDestinationlist;
        }
        private void GetDesignation()
        {
            string DeptID = HttpContext.Session.GetString("Department");
            List<designation> designationlist = new List<designation>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            designationlist = (from category in _context.designation  orderby category.Decoration ascending select category).ToList();
            // ------- Inserting Select Item in List -------
            designationlist.Insert(0, new designation { DesignationID = 0, Decoration = "---Select---" });
            ViewBag.ListofDesig = designationlist;
        }
        [NoDirectAccess]
        public async Task<IActionResult> PromotionLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.CareerProgression.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> PromotionLetter(int id, CareerProgression Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
          
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.CareerProgression.FindAsync(id);
            _context.CareerProgression.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;
                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.CareerId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedPromotion));
        }
        [NoDirectAccess]
        public async Task<IActionResult> PostingLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.StaffPosting.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> PostingLetter(int id, StaffPosting Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
         
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.StaffPosting.FindAsync(id);
            _context.StaffPosting.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;

                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.ConId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedPosting));
        }
        [NoDirectAccess]
        public async Task<IActionResult> ConfirmationLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.Confirmationofappointment.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ConfirmationLetter(int id, Confirmationofappointment Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
           
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.Confirmationofappointment.FindAsync(id);
            _context.Confirmationofappointment.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;
                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.ConId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedConfirmation));
        }

        [NoDirectAccess]
        public async Task<IActionResult> PrepareLetter(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.Leaves.FindAsync(id);
         
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintRetirementLetter(int id)
        {

          
            var bio = (from s in _context.retirementbiodata where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintPostingLetter(int id)
        {

           
            var bio = (from s in _context.StaffPosting where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintItLeter(int id)
        {

          
            var bio = (from s in _context.itstudent where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintReleaseLetter(int id)
        {

           
            var bio = (from s in _context.TrainingAndStudy where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> PrintPromotionLetter(int id)
        {

            
            var bio = (from s in _context.CareerProgression where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintConfirmationLetter(int id)
        {

          
            var bio = (from s in _context.Confirmationofappointment where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PrintLetter(string id)
        {

            var bio = (from s in _context.Leaves where s.LStatus == "Approved" && s.Id == id select s);

            return View(await bio.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SubmitRetireLetter()
        {

            
            _context.retirementbiodata.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.PrepareRetirmentList));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitPostingLetter()
        {

           
            _context.StaffPosting.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.PostingList));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitItLetter()
        {

        
            _context.itstudent.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.PreparedIt));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitPromotionLetter()
        {

           
            _context.CareerProgression.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.Index));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitReleaseLetter()
        {

          
            _context.TrainingAndStudy.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.StaffOnTrainingList));
        }
        
         
        [HttpPost]
        public async Task<IActionResult> SubmitConfirmationLetter()
        {

            
            _context.Confirmationofappointment.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.ConfirmationList));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitLetter()
        {
         
            _context.Leaves.Where(x => x.LStatus == "No").ToList().ForEach(x =>
            {
                x.LStatus = "Waiting";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersController.LeaveRoster));
        }

        [NoDirectAccess]
        public async Task<IActionResult> EditReleaseLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.TrainingAndStudy.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> EditReleaseLetter(int id, TrainingAndStudy Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
           
            var name = await _context.TrainingAndStudy.FindAsync(id);
            _context.TrainingAndStudy.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;

                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(StaffOnTrainingList));
        }
        [NoDirectAccess]
        public async Task<IActionResult> ItLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.itstudent.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ItLetter(int id, itstudent Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
           
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.itstudent.FindAsync(id);
            _context.itstudent.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;
                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.ConId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedITStudent));
        }
        [NoDirectAccess]
        public async Task<IActionResult> RetirementLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
           
            var leave = await _context.retirementbiodata.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> RetirementLetter(int id, retirementbiodata Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
          
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.retirementbiodata.FindAsync(id);
            _context.retirementbiodata.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {

                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;

                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.ConId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedRetirement));
        }
        [NoDirectAccess]
        public async Task<IActionResult> ReleaseLetter(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave = await _context.TrainingAndStudy.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [HttpPost]
        public async Task<IActionResult> ReleaseLetter(int id, TrainingAndStudy Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
          
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Title) || string.IsNullOrWhiteSpace(Lvs.Title)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.TrainingAndStudy.FindAsync(id);
            _context.TrainingAndStudy.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Title = Lvs.Title;
                x.Recipient = name.Surname + " " + name.MiddleName + " " + name.FirstName;
                x.RefNo = Lvs.RefNo;

                x.Body = Lvs.Body;
                x.Status = "Written";
            });
          int i=  await _context.SaveChangesAsync();
            if (i>0)
            {
                _context.Box.Where(x => (x.IdNo == name.ConId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";
                   
                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedStaffOnTraining));
        }
        [HttpPost]
        public async Task<IActionResult> PrepareLetter(string id, Leaves Lvs)
        {
            if (id != Lvs.Id)
            {
                return NotFound();
            }
         
            if ((string.IsNullOrEmpty(Lvs.Address) || string.IsNullOrWhiteSpace(Lvs.Address)))
            {
                ModelState.AddModelError("", "Enter Address");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Body) || string.IsNullOrWhiteSpace(Lvs.Body)))
            {
                ModelState.AddModelError("", "Enter Body");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.RefNo) || string.IsNullOrWhiteSpace(Lvs.RefNo)))
            {
                ModelState.AddModelError("", "Enter Ref No");
                return View();
            }
            if ((string.IsNullOrEmpty(Lvs.Addresse) || string.IsNullOrWhiteSpace(Lvs.Addresse)))
            {
                ModelState.AddModelError("", "Enter Title");
                return View();
            }
            var name = await _context.Leaves.FindAsync(id);
            _context.Leaves.Where(x => (x.Status == "Approved" || x.Status == "Written") && x.Id == Lvs.Id).ToList().ForEach(x =>
            {
                x.LStatus = "No";
                x.Address = Lvs.Address;
                x.Addresse = Lvs.Addresse;
                x.Salutation = name.Surname + " " + name.MiddleName + " " + name.FirstName;
               
                x.RefNo = Lvs.RefNo;
                x.Body = Lvs.Body;
                x.Status = "Written";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => (x.IdNo == name.BoxId)).ToList().ForEach(x =>
                {
                    x.Status = "Waiting";
                    x.Status1 = "Waiting";

                    x.Status2 = "Waiting";
                    x.Status3 = "Waiting";

                    x.Status4 = "Waiting";
                });
            }
            return RedirectToAction(nameof(ApprovedLeave));
        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedMemo(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.Memo where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);

            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedRPT(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.reportwriting where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));

           
                sign.UpdateUserStatus(id);
            
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedITStudent(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.itstudent where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Read" || s.Status == "Written" || s.Status == "Approved") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedStaffOnTraining(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.TrainingAndStudy where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedPersonnelFile(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.PersonelFile where s.UserID == userID && s.ConId == bx.IdNo && (s.Status != "No") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedVisitor(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.Visitor where s.UserID == userID && s.VisitID == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedDailyMotorVehicleWorkBook(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.DailyMotorVehicleWorkBook where s.UserID == userID && s.DailyID == bx.IdNo && (s.Status == "Written" || s.Status == "Approved" || s.Status == "Read") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedRetirement(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.retirementbiodata where s.CheckBy == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedMonthlyReturn(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.monthlyreturn where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedPromotion(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.CareerProgression where s.UserID == userID && s.CareerId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedPosting(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.StaffPosting where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedConfirmation(int id = 0)
        {
            int Id = 0;
            if (id!=0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv = (from s in _context.Confirmationofappointment where s.UserID == userID && s.ConId == bx.IdNo && (s.Status == "Written" || s.Status == "Approved" || s.Status == "Read") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovedLeave(int id=0)
        {
            int Id = 0;
            if (id != 0)
            {
                Id = id;
                HttpContext.Session.SetString("ID", Convert.ToString(id));
            }
            else
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            var bx = await _context.Box.FindAsync(Id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string boxID = HttpContext.Session.GetString("boxID");
            string userID = HttpContext.Session.GetString("UserID");
            var lv= (from s in _context.Leaves where s.UserID == userID && s.BoxId==bx.IdNo && (s.Status=="Approved" || s.Status == "Read" || s.Status == "Written") select s);
            DALClass sign = new DALClass(configuration);
            string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));


            sign.UpdateUserStatus(Id);
            return View(await lv.ToListAsync());

        }
        [NoDirectAccess]
        public async Task<IActionResult> ReturnFile(int? id)
        {


          
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.PersonelFile.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ReturnFile(int id, PersonelFile lv)
        {
            if (id != lv.ID)
            {
                return NotFound();
            }
         
            string BoxID = HttpContext.Session.GetString("boxID");
            DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            string userID = HttpContext.Session.GetString("UserID");

            var fl = _context.PersonelFile.Where(u =>  u.Status == "No").FirstOrDefault();
            if (fl != null)
            {
                ModelState.AddModelError("", "Cannot Remove the file,File not submited");
                return View();
            }

                _context.PersonelFile.Where(x => x.ID == lv.ID).ToList().ForEach(x =>
            {



                x.Status = "Returned";
            });
            int i = await _context.SaveChangesAsync();

            //if (i > 0)
            //{
            //    _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
            //    {


            //        x.UserStatus = "Waiting";
            //        x.Status = "Approved";
            //    });
            //    await _context.SaveChangesAsync();
            //}





            return RedirectToAction(nameof(FileList));

        }
        [NoDirectAccess]
        public async Task<IActionResult> RemoveFile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lv = await _context.PersonelFile

                .FirstOrDefaultAsync(m => m.ID == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveFile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveFile(int id)
        {
            var lv = await _context.PersonelFile.FindAsync(id);
            if (lv.Status == "Read" || lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.PersonelFile.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(FileList));
        }
        [NoDirectAccess]
        public IActionResult ProcessDisposition(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var leave = _context.biodata.Find(id);
           
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [NoDirectAccess]
        public IActionResult ProcessVariation(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var leave = _context.biodata.Find(id);
        
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);

        }
        [NoDirectAccess]
        public IActionResult Process(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            var leave =  _context.biodata.Find(id);
            HttpContext.Session.SetString("Grd", leave.GradeLevel);
            HttpContext.Session.SetString("fap", Convert.ToString(leave.DateOfFirstAppointment));
            HttpContext.Session.SetString("Stp", leave.Step);
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);
           
        }
        [HttpPost]
        public IActionResult Process(string id,biodata bios)
        {
            if (id != bios.SprpNo)
            {
                return NotFound();
            }
           
            
            if (HttpContext.Request.Form["LeaveType"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Leave Type");
                return View();
            }
            if (HttpContext.Request.Form["StartDate"].ToString() == "")
            {
                ModelState.AddModelError("", "Please Select Start Date");
                return View();
            }
           
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
            string formats = "dd/MM/yyyy";
            string format = "MM/dd/yyyy";
            string formatedTime = DateTime.Now.ToString("HH:mm:ss");
            string dates = Convert.ToString(CurrentServerTime.ToString(format));
            string date = Convert.ToString(CurrentServerTime.ToString(formats));
            string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
            Int32 nYear = CurrentServerTime.Year;
            Int32 nMonth = CurrentServerTime.Month;
            Int32 nDay = CurrentServerTime.Day;
            Int32 noofDay = 0;
            var Lvs = _context.Leaves.Where(u => ((u.Yr == nYear.ToString() && u.LeaveType == HttpContext.Request.Form["LeaveType"].ToString()) || u.Status != "Expired") && u.SprpNo==bios.SprpNo ).FirstOrDefault();
            if (Lvs != null)
            {
                //ModelState.AddModelError("", "Not eligible,either the staff has applied for the same leave this year or one leave applied never expire");
                //return View();
            }
            string dat = "09/30/2020";
            DateTime endDate= Convert.ToDateTime(dat);
            DateTime startDate = Convert.ToDateTime(HttpContext.Request.Form["StartDate"].ToString());
            Int32 sYear = startDate.Year;
            Int32 sMonth = startDate.Month;
            Int32 sDay = startDate.Day;
            if (sYear < nYear)
            {

                ModelState.AddModelError("", "Selected Start Year cannot be less than the current Year");
               
                return View();
            }
            DateTime ResumtionDate;
            DateTime rDate;
            string userID = HttpContext.Session.GetString("UserID");
            string grd = HttpContext.Session.GetString("Stp");
            string stp = HttpContext.Session.GetString("Grd");
            string Fap = HttpContext.Session.GetString("fap");
            string Station = HttpContext.Session.GetString("station");
            DateTime FirstAp = Convert.ToDateTime(Fap);
           int noofmonth = (startDate- FirstAp).Days;
            if (noofmonth<120)
            {
                // ModelState.AddModelError("", "Not Due for leave,,the staff can only go for Pro rata Leave");
                // return View();
            }

            if (HttpContext.Request.Form["LeaveType"].ToString() == "Pro rata Leave")
            {
                int diff = 0;
                if (grd == "CON_R 1" || grd == "CON_R 2" || grd == "CON_R 3" || grd == "CON_R 4" || grd == "CON_R 5")
                {
                    endDate = startDate.AddDays(7);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 7)
                    {

                        diff = noofDay - 7;
                        noofDay = 7;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 7)
                    {

                        diff = 7- noofDay;
                        noofDay = 7;
                        endDate = endDate.AddDays(diff);
                    }

                }
                else if (grd == "CON_R 6" || grd == "CON_R 7")
                {
                    endDate = startDate.AddDays(14);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 14)
                    {

                        diff = noofDay - 14;
                        noofDay = 14;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 14)
                    {

                        diff = 14 - noofDay;
                        noofDay = 14;
                        endDate = endDate.AddDays(diff);
                    }
                }
                else
                {
                    endDate = startDate.AddDays(21);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 21)
                    {

                        diff = noofDay - 21;
                        noofDay = 21;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 21)
                    {

                        diff = 21 - noofDay;
                        noofDay = 21;
                        endDate = endDate.AddDays(diff);
                    }
                }
            }
              else  if (HttpContext.Request.Form["LeaveType"].ToString() == "Annual Leave")
            {
              
                int diff = 0;
                if (grd == "CON_R 3" || grd == "CON_R 4" || grd == "CON_R 5")
                {
                    endDate = startDate.AddDays(27);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 27)
                    {

                        diff = noofDay - 27;
                        noofDay = 27;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 27)
                    {

                        diff = 27 - noofDay;
                        noofDay = 27;
                        endDate = endDate.AddDays(diff);
                    }

                }
                if (grd == "CON_R 1" || grd == "CON_R 2")
                {
                    endDate = startDate.AddDays(18);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 18)
                    {

                        diff = noofDay - 18;
                        noofDay = 18;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 18)
                    {

                        diff = 18 - noofDay;
                        noofDay = 18;
                        endDate = endDate.AddDays(diff);
                    }

                }
                else if (grd == "CON_R 6")
                {
                    endDate = startDate.AddDays(40);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 40)
                    {

                        diff = noofDay - 40;
                        noofDay = 40;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 40)
                    {

                        diff = 40 - noofDay;
                        noofDay = 40;
                        endDate = endDate.AddDays(diff);
                    }
                }
                else
                {
                    endDate = startDate.AddMonths(1);
                    noofDay = (endDate - startDate).Days;
                    if (noofDay > 40)
                    {

                        diff = noofDay - 40;
                        noofDay = 40;
                        endDate = endDate.AddDays(-diff);
                    }
                    else if (noofDay < 40)
                    {

                        diff = 40 - noofDay;
                        noofDay = 40;
                        endDate = endDate.AddDays(diff);
                    }
                }
            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Casual Leave")
            {
                endDate = startDate.AddDays(7);
                noofDay = (endDate - startDate).Days;
                int diff = 0;
                if (noofDay > 7)
                {

                    diff = noofDay - 7;
                    noofDay = 7;
                    endDate = endDate.AddDays(-diff);
                }
                else if (noofDay < 7)
                {

                    diff = 7 - noofDay;
                    noofDay = 7;
                    endDate = endDate.AddDays(diff);
                }
               
            }
           else if (HttpContext.Request.Form["LeaveType"].ToString() == "Patanity Leave")
            {
                endDate = startDate.AddDays(18);
                noofDay = (endDate - startDate).Days;
                int diff = 0;
                if (noofDay > 18)
                {

                    diff = noofDay - 18;
                    noofDay = 18;
                    endDate = endDate.AddDays(-diff);
                }
                else if (noofDay < 18)
                {

                    diff = 18 - noofDay;
                    noofDay = 18;
                    endDate = endDate.AddDays(diff);
                }

            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Sabbatical Leave")
            {

                endDate = startDate.AddMonths(12);
                noofDay = (endDate - startDate).Days;
              
            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Maternity Leave")
            {
                endDate = startDate.AddMonths(4);
                noofDay = (endDate - startDate).Days;
                int diff = 0;
                if (noofDay > 116)
                {

                    diff = noofDay - 116;
                    noofDay = 116;
                    endDate = endDate.AddDays(-diff);
                }
                else if (noofDay < 116)
                {

                    diff = 116 - noofDay;
                    noofDay = 116;
                    endDate = endDate.AddDays(diff);
                }
               
            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Study Leave")
            {
                if (HttpContext.Request.Form["EndDate"].ToString() == "")
                {
                    ModelState.AddModelError("", "Please Select End date");
                    return View();
                }
                endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                noofDay = (endDate - startDate).Days;
                
            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Leave Of Absence")
            {

                if (HttpContext.Request.Form["EndDate"].ToString() == "")
                {
                    ModelState.AddModelError("", "Please Select End date");
                    return View();
                }
                endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                noofDay = (endDate - startDate).Days;

               
            }

            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Sick Leave")
            {
                if (HttpContext.Request.Form["EndDate"].ToString() == "")
                {
                    ModelState.AddModelError("", "Please Select End date");
                    return View();
                }
                endDate = Convert.ToDateTime(HttpContext.Request.Form["EndDate"].ToString());
                noofDay = (endDate - startDate).Days;
                
            }
            else if (HttpContext.Request.Form["LeaveType"].ToString() == "Pre Retirement Leave")
            {
                endDate = startDate.AddMonths(3);
                noofDay = (endDate - startDate).Days;
                int diff = 0;
                if (noofDay > 90)
                {

                    diff = noofDay - 90;
                    noofDay = 90;
                    endDate = endDate.AddDays(-diff);
                }
                else if (noofDay < 90)
                {

                    diff = 90 - noofDay;
                    noofDay = 90;
                    endDate = endDate.AddDays(diff);
                }
               
            }
            ResumtionDate = endDate.AddDays(1);
            rDate = endDate.AddDays(1);
            string sdate = Convert.ToString(startDate.ToString(format));
            string edate = Convert.ToString(endDate.ToString(format));

            string startdate = Convert.ToString(startDate.ToString(formats));
            string enddate = Convert.ToString(endDate.ToString(formats));
            int iNo;
            string LeaveId = "";
            string LeaveNo = "";
            DALClass sign = new DALClass(configuration);
            LeaveNo = sign.LeaveNoAuto().ToString();

            if (LeaveNo.Equals("") || LeaveNo == null)
            {
                iNo = 00001;
            }
            else
            {
                iNo = int.Parse(LeaveNo);
                iNo++;
            }
            if (iNo < 10) { LeaveId = "0000" + Convert.ToString(iNo); }
            else if (10 <= iNo && iNo < 100) { LeaveId = "000" + Convert.ToString(iNo); }
            else if (100 <= iNo && iNo < 1000) { LeaveId = "00" + Convert.ToString(iNo); }
            else if (1000 <= iNo && iNo < 10000) { LeaveId = "0" + Convert.ToString(iNo); }
            else LeaveId = Convert.ToString(iNo);
            Leaves lv = new Leaves();
            lv.Surname = bios.Surname;
            lv.MiddleName = bios.MiddleName;
            lv.FirstName = bios.FirstName;
            lv.Sex = bios.Sex;
            lv.Department = bios.Department;
            lv.SprpNo = bios.SprpNo;
            lv.LeaveType = HttpContext.Request.Form["LeaveType"].ToString();
            lv.EndDate = endDate;
            lv.StartDate = startDate;
            lv.EDate = endDate;
            lv.SDate = startDate;
            lv.Date = DateTime.UtcNow.Date;
            lv.Dates = dates;
            lv.Yr = Convert.ToString(nYear);
            lv.Mnt = Convert.ToString(nMonth);
            lv.Day = Convert.ToString(nDay);
            lv.NoOfDays = Convert.ToString(noofDay);
            lv.Status = "No";
            lv.Id = LeaveId;
            lv.ResumeDate=ResumtionDate;
            lv.RDate=rDate;
            lv.UserID = userID;
            lv.GradeLevel = grd;
            lv.Step = stp;
            lv.StationName = Station;
            _context.Add(lv);
             _context.SaveChanges();
            return RedirectToAction(nameof(UsersController.LeaveRoster));
           
        }
        [NoDirectAccess]
        public IActionResult SeniorityList()
        {
            
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.biodata select s);
                ViewBag.data = bio.ToList();
                return View(bio.ToList());
            }
            else
            {
                var bio = (from s in _context.biodata where s.StationName == stationName select s);
                ViewBag.data = bio.ToList();
                return View(bio.ToList());
            }
        }
        [NoDirectAccess]
        public IActionResult NorminalRoll()
        {
         
            string stationName = HttpContext.Session.GetString("station");
            if (stationName == "Headqauaters Ilorin")
            {
                var bio = (from s in _context.biodata orderby s.GradeLevel descending select s);
                ViewBag.data = bio.ToList();
                return View(bio.ToList());
            }
            else
            {
                var bio = (from s in _context.biodata where s.StationName == stationName orderby s.GradeLevel descending select s);
                ViewBag.data = bio.ToList();
                return View(bio.ToList());
            }
        }
        public IActionResult SwitchToTabsR(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PrepareRetirmentList":
                    vm.ActiveTabR = ViewModels.TabR.PrepareRetirmentList;
                    break;
                case "PrepareRetirmentRoll":
                    vm.ActiveTabR = ViewModels.TabR.PrepareRetirmentRoll;
                    break;
                case "ApprovedRetirment":
                    vm.ActiveTabR = ViewModels.TabR.ApprovedRetirment;
                    break;                    
                case " WastedRegister":
                    vm.ActiveTabR = ViewModels.TabR.WastedRegister;
                    break;
                default:
                    vm.ActiveTabR = ViewModels.TabR.PrepareRetirmentList;
                    break;
            }
            return RedirectToAction(nameof(UsersController.PrepareRetirmentList), vm);
        }
        public IActionResult SwitchToTabsP(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PostingList":
                    vm.ActiveTabP = ViewModels.TabP.PostingList;
                    break;
                case "PreparedPosting":
                    vm.ActiveTabP = ViewModels.TabP.PreparedPosting;
                    break;
                case "ApprovedPosting":
                    vm.ActiveTabP = ViewModels.TabP.ApprovedPosting;
                    break;
                case "WrittenPostingLetter":
                    vm.ActiveTabP = ViewModels.TabP.WrittenPostingLetter;
                    break;

                default:
                    vm.ActiveTabP = ViewModels.TabP.PostingList;
                    break;
            }
            return RedirectToAction(nameof(UsersController.PostingList), vm);
        }
        public IActionResult SwitchToTabsC(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "ConfirmationList":
                    vm.ActiveTabC = ViewModels.TabC.ConfirmationList;
                    break;
                case "PreparedComfirmation":
                    vm.ActiveTabC = ViewModels.TabC.PreparedComfirmation;
                    break;
                case "ApprovedConfirmation":
                    vm.ActiveTabC = ViewModels.TabC.ApprovedConfirmation;
                    break;
                case "WrittenConfirmationLetter":
                    vm.ActiveTabC = ViewModels.TabC.WrittenConfirmationLetter;
                    break;

                default:
                    vm.ActiveTabC = ViewModels.TabC.ConfirmationList;
                    break;
            }
            return RedirectToAction(nameof(UsersController.ConfirmationList), vm);
        }
        
             public IActionResult SwitchToTabsM(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "MonthlyReturn":
                    vm.ActiveTabM = ViewModels.TabM.MonthlyReturn;
                    break;
                case "PreparedMonthlyReturn":
                    vm.ActiveTabM = ViewModels.TabM.PreparedMonthlyReturn;
                    break;
               

                default:
                    vm.ActiveTabM = ViewModels.TabM.MonthlyReturn;
                    break;
            }
            return RedirectToAction(nameof(UsersController.MonthlyReturn), vm);
        }
        public IActionResult SwitchToTabsL(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "LeaveRoaster":
                    vm.ActiveTabL = ViewModels.TabL.LeaveRoaster;
                    break;
                case "PreparedLeave":
                    vm.ActiveTabL = ViewModels.TabL.PreparedLeave;
                    break;
                case "ApprovedLeave":
                    vm.ActiveTabL = ViewModels.TabL.ApprovedLeave;
                    break;
                case "WrittenLetter":
                    vm.ActiveTabL = ViewModels.TabL.WrittenLetter;
                    break;
                    
                default:
                    vm.ActiveTabL = ViewModels.TabL.LeaveRoaster;
                    break;
            }
            return RedirectToAction(nameof(UsersController.LeaveRoster), vm);
        }
        public IActionResult SwitchToTabsI(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PreparedIt":
                    vm.ActiveTabI = ViewModels.TabI.PreparedIt;
                    break;
                case "ApprovedIt":
                    vm.ActiveTabI = ViewModels.TabI.ApprovedIt;
                    break;
                case "ApprovedLetter":
                    vm.ActiveTabI = ViewModels.TabI.ApprovedLetter;
                    break;

                default:
                    vm.ActiveTabI = ViewModels.TabI.PreparedIt;
                    break;
            }
            return RedirectToAction(nameof(UsersController.PreparedIt), vm);
        }
        public IActionResult SwitchToTabsRPT(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PreparedRPT":
                    vm.ActiveTabRPT = ViewModels.TabRPT.PreparedRPT;
                    break;
                case "ApprovedRPT":
                    vm.ActiveTabRPT = ViewModels.TabRPT.ApprovedRPT;
                    break;
                case "ApprovedRPTLetter":
                    vm.ActiveTabRPT = ViewModels.TabRPT.ApprovedRPTLetter;
                    break;
                case "PreparedMemo":
                    vm.ActiveTabRPT = ViewModels.TabRPT.PreparedMemo;
                    break;
                case "ApprovedMemo":
                    vm.ActiveTabRPT = ViewModels.TabRPT.ApprovedMemo;
                    break;
                case "ApprovedMemoLetter":
                    vm.ActiveTabRPT = ViewModels.TabRPT.ApprovedMemoLetter;
                    break;
                default:
                    vm.ActiveTabRPT = ViewModels.TabRPT.PreparedRPT;
                    break;
            }
            return RedirectToAction(nameof(UsersController.WriteReport), vm);
        }
        public IActionResult SwitchToTabsMe(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PreparedMemo":
                    vm.ActiveTabMe = ViewModels.TabMe.PreparedMemo;
                    break;
                case "ApprovedMemo":
                    vm.ActiveTabMe = ViewModels.TabMe.ApprovedMemo;
                    break;
                case "ApprovedMemoLetter":
                    vm.ActiveTabMe = ViewModels.TabMe.ApprovedMemoLetter;
                    break;

                default:
                    vm.ActiveTabMe = ViewModels.TabMe.PreparedMemo;
                    break;
            }
            return RedirectToAction(nameof(UsersController.PreparedMemo), vm);
        }
        public IActionResult SwitchToTabsF(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "FileList":
                    vm.ActiveTabF = ViewModels.TabF.FileList;
                    break;
                case "PreparedFile":
                    vm.ActiveTabF = ViewModels.TabF.PreparedFile;
                    break;
                case "ApprovedPersonnelFile":
                    vm.ActiveTabF = ViewModels.TabF.ApprovedPersonnelFile;
                    break;
                   
                default:
                    vm.ActiveTabF = ViewModels.TabF.FileList;
                    break;
            }
            return RedirectToAction(nameof(UsersController.FileList), vm);
        }
        public IActionResult SwitchToTabsRANDM(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "LetterHead":
                    vm.ActiveTabRANDM = ViewModels.TabRANDM.LetterHead;
                    break;
                case "PrintMemo":
                    vm.ActiveTabRANDM = ViewModels.TabRANDM.PrintMemo;
                    break;

                default:
                    vm.ActiveTabRANDM = ViewModels.TabRANDM.LetterHead;
                    break;
            }
            return RedirectToAction(nameof(UsersController.LetterHead), vm);
        }
        public IActionResult SwitchToTabs(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch (tabname)
            {
                case "PreparePromotion":
                    vm.ActiveTab = ViewModels.Tab.PreparePromotion;
                    break;
                case "Qaulified":
                    vm.ActiveTab = ViewModels.Tab.Qaulified;
                    break;
                case "Disaulified":
                    vm.ActiveTab = ViewModels.Tab.Disaulified;
                    break;
                case "Promoted":
                    vm.ActiveTab = ViewModels.Tab.Promoted;
                    break;
                default:
                    vm.ActiveTab = ViewModels.Tab.PreparePromotion;
                    break;
            }
            return RedirectToAction(nameof(UsersController.Index), vm);
        }
        public IActionResult SwitchToTabsT(string tabname)
        {
            var vm = new UsersTabViewModel();
            switch(tabname){
                case "StaffOnTrainingList":
                    vm.ActiveTabT = ViewModels.TabT.StaffOnTrainingList;
                    break;
                case "PreparedStaffOnTraining":
                    vm.ActiveTabT = ViewModels.TabT.PreparedStaffOnTraining;
                    break;
                case "ApprovedStaffOnTraining":
                    vm.ActiveTabT = ViewModels.TabT.ApprovedStaffOnTraining;
                    break;
                case "ReleaseLetter":
                    vm.ActiveTabT = ViewModels.TabT.ReleaseLetter;
                    break;
                default:
                    vm.ActiveTabT = ViewModels.TabT.StaffOnTrainingList;
                    break;
            }
            return RedirectToAction(nameof(UsersController.StaffOnTrainingList),vm);
        }
    }
}
