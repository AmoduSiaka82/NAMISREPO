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
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;
using static NAMIS.Helper;

namespace NAMIS.Controllers
{
    public class BoxesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;
        private readonly ApplicationDbContext _contex;
        public BoxesController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            _contex = context;

            this.configuration = config;
        }
       
        [HttpPost]
        public IActionResult SubmitLeave()
        {


          
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
          
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Leaves.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.BoxId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Leaves.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.BoxId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Leaves.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.BoxId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Leaves.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.BoxId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            

            return RedirectToAction(nameof(BoxesController.Index));

        }

        
            [HttpPost]
        public IActionResult SubmitMontlyReturn()
        {


           
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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.monthlyreturn.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.monthlyreturn.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.monthlyreturn.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.monthlyreturn.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }
       
            [HttpPost]
        public IActionResult SubmitRetirement()
        {


          
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
           
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.retirementbiodata.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.retirementbiodata.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.retirementbiodata.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.retirementbiodata.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }
        
            [HttpPost]
        public IActionResult SubmitIT()
        {


           
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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.itstudent.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.itstudent.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.itstudent.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.itstudent.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult SubmitTraining()
        {


           
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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.TrainingAndStudy.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.TrainingAndStudy.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.TrainingAndStudy.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.TrainingAndStudy.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult SubmitPosting()
        {


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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.StaffPosting.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.StaffPosting.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.StaffPosting.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.StaffPosting.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult SubmitCon()
        {


          
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
           
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Confirmationofappointment.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {
                    
                        var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Confirmationofappointment.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                        
                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }



                            
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Confirmationofappointment.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Confirmationofappointment.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        
             [HttpPost]
        public IActionResult SubmitMemo()
        {


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
           
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Memo.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Memo.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Memo.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.Memo.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult SubmitRPT()
        {


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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.reportwriting.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.reportwriting.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.reportwriting.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.reportwriting.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult SubmitFile()
        {


         
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
            
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.PersonelFile.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.PersonelFile.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.PersonelFile.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.PersonelFile.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.ConId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            

            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult SubmitPro()
        {


           
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
            var sch = _context.scheduled.Where(u => u.UserID == userID).FirstOrDefault();
            if (sch != null)
            {
                if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;
                        myBox.ReceiverID1 = userID;


                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.CareerProgression.Where(x => x.Status == "Waiting" && x.ReceiverID2 == userID && x.CareerId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;
                            x.ReceiverID1 = userID;


                            x.Status = "Wait";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD")
                {

                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {
                        if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                        {
                            myBox.ReceiverID = userID;

                        }
                        else { myBox.ReceiverID3 = userID; }
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.CareerProgression.Where(x => x.Status == "Wait" && x.ReceiverID1 == userID && x.CareerId == BoxID).ToList().ForEach(x =>
                        {

                            if (HttpContext.Session.GetString("station") == "Headqauaters Ilorin")
                            {
                                x.ReceiverID = userID;
                                x.Status = "Pending";
                            }
                            else
                            {
                                x.ReceiverID3 = userID;
                                x.Status = "Pending";
                            }




                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head" || HttpContext.Session.GetString("RoleID") == "Out Station Head")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID = userID;

                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.CareerProgression.Where(x => x.Status == "Pending" && x.ReceiverID3 == userID && x.CareerId == BoxID).ToList().ForEach(x =>
                        {
                            x.ReceiverID = userID;



                            x.Status = "Pending";
                        });
                        _context.SaveChanges();
                    }

                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                    var myBox = _context.Box.Where(u => u.IdNo == BoxID).FirstOrDefault();
                    if (myBox != null)
                    {

                        myBox.ReceiverID2 = userID;


                        myBox.ReceiverID4 = userID;
                        _context.Entry(myBox).State = EntityState.Modified;
                        _context.SaveChanges();
                        _context.CareerProgression.Where(x => x.Status == "Waiting" && x.ReceiverID4 == userID && x.CareerId == BoxID).ToList().ForEach(x =>
                        {

                            x.ReceiverID2 = userID;

                            x.ReceiverID4 = userID;
                            x.Status = "Waiting";
                        });
                        _context.SaveChanges();
                    }

                }
            }

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> Disapprove(string id)
        {


          
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Leaves.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> Disapprove(string id, Leaves lv)
        {
            if (id != lv.Id)
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
           


                _context.Leaves.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
                {



                    x.Status = "Disapproved";
                });
               await _context.SaveChangesAsync();



            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapprovePro(int? id)
        {


       
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.CareerProgression.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapprovePro(int id, CareerProgression lv)
        {
            if (id != lv.Id)
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



            _context.CareerProgression.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [NoDirectAccess]
        public async Task<IActionResult> DisapproveTraining(int? id)
        {


         
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.TrainingAndStudy.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapproveTraining(int id, Confirmationofappointment lv)
        {
            if (id != lv.Id)
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



            _context.TrainingAndStudy.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapproveCon(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Confirmationofappointment.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapproveCon(int id, Confirmationofappointment lv)
        {
            if (id != lv.Id)
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



            _context.Confirmationofappointment.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapproveMemo(string id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Memo.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapproveMemo(int id, Memo lv)
        {
            if (id != lv.Id)
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



            _context.Memo.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {

                x.Remark = lv.Remark;

                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapproveRPT(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.reportwriting.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapproveRPT(string id, reportwriting lv)
        {
            if (id != lv.Id)
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



            _context.reportwriting.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {

                x.Remark = lv.Remark;

                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapproveRetirement(string id)
        {


           
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.retirementbiodata.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapproveRetirement(string id, retirementbiodata lv)
        {
            if (id != lv.SprpNo)
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



            _context.retirementbiodata.Where(x => x.Status == "Pending" && x.SprpNo == lv.SprpNo).ToList().ForEach(x =>
            {



                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> DisapprovePosting(int? id)
        {


           
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.StaffPosting.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> DisapprovePostingn(int id, StaffPosting lv)
        {
            if (id != lv.Id)
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



            _context.StaffPosting.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Disapproved";
            });
            await _context.SaveChangesAsync();





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [NoDirectAccess]
        public async Task<IActionResult> ReverseMinute(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.MinuteOfMeeting.FindAsync(id);
            HttpContext.Session.SetString("MinuteID", box.MinuteID);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ReverseMinute(int id, MinuteOfMeeting lv)
        {
            if (id != lv.Id)
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
            string MinuteId = HttpContext.Session.GetString("MinuteID");
            if ((string.IsNullOrEmpty(lv.Remark) || string.IsNullOrWhiteSpace(lv.Remark)))
            {
                ModelState.AddModelError("", "Enter Remark");

                return View();
            }
            _context.MinuteOfMeeting.Where(x => x.MinuteID == MinuteId).ToList().ForEach(x =>
            {
               
                x.Remark = lv.Remark;
                x.Status = "No";
                
            });
            await _context.SaveChangesAsync();
            _context.MinuteRegister.Where(x => x.Id == MinuteId).ToList().ForEach(x =>
            {

                x.Status = "No";

            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> Approve(string id)
        {


           
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Leaves.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
           

            

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovePro(int? id)
        {


         
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.CareerProgression.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApprovePro(int id, CareerProgression lv)
        {
            if (id != lv.Id)
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



            _context.CareerProgression.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [NoDirectAccess]
        public async Task<IActionResult> ApproveRetirement(string id)
        {


            
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.retirementbiodata.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveRetirement(string id, retirementbiodata lv)
        {
            if (id != lv.SprpNo)
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



            _context.retirementbiodata.Where(x => x.Status == "Pending" && x.SprpNo == lv.SprpNo).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [NoDirectAccess]
        public async Task<IActionResult> ApproveTraining(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.TrainingAndStudy.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveTraining(int id, TrainingAndStudy lv)
        {
            if (id != lv.Id)
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



            _context.TrainingAndStudy.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovePosting(int? id)
        {


            
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.StaffPosting.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApprovePosting(int id, StaffPosting lv)
        {
            if (id != lv.Id)
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



            _context.StaffPosting.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveMemo(int? id)
        {


         
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Memo.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveMemo(int id, Memo lv)
        {
            if (id != lv.Id)
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign!=null)

            {
                Sign = sign.SignFile;
            }
            _context.Memo.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {
               
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveTrainingLetter(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));

            var box = await _context.TrainingAndStudy.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.ConId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveTrainingLetter(int id, TrainingAndStudy lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

          
            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.TrainingAndStudy.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;


                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewPromotionLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveRetirementLetter(int? id)
        {


           
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));
            var box = await _context.retirementbiodata.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.ConId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveRetirementLetter(int id, retirementbiodata lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.retirementbiodata.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewRetirementLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovePromotionLetter(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));
            var box = await _context.CareerProgression.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.CareerId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApprovePromotionLetter(int id, CareerProgression lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

          
            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.CareerProgression.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewPromotionLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveLeaveLetter(string id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Leaves.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.BoxId);
            if (box == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", id);
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveLeaveLetter(string id, Leaves lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }
        
            HttpContext.Session.SetString("ID", id);
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.Leaves.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewLeaveLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveItLetter(int? id)
        {


           
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));
            var box = await _context.itstudent.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.ConId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveItLetter(int id, itstudent lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

           
            string BoxID = HttpContext.Session.GetString("boxID");
            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.itstudent.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewItLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApprovePostingLetter(int? id)
        {


           
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));
            var box = await _context.StaffPosting.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.ConId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApprovePostingLetter(int id, StaffPosting lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.StaffPosting.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewPostingLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveConfirmationLetter(int? id)
        {


           
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("ID", Convert.ToString(id));
            var box = await _context.Confirmationofappointment.FindAsync(id);
            HttpContext.Session.SetString("boxID", box.ConId);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveConfirmationLetter(int id, Confirmationofappointment lv)
        {
            if (id != lv.Id)
            {
                return NotFound();
            }

          
            HttpContext.Session.SetString("ID", Convert.ToString(id));
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
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)
            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.Confirmationofappointment.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.LStatus = "Approved";
            });
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {



                    x.UserStatus = "Waiting";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.ViewConfirmationLetter));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveMe(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Memo.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveMe(int id, Memo lv)
        {
            if (id != lv.Id)
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
            string Sign = "";

            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor!="" )
            {
                fr = "For: " + lv.SignFor;
            }
            _context.Memo.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveRPort(string id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.reportwriting.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveRPort(string id, reportwriting lv)
        {
            if (id != lv.Id)
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




            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
            string fr = "";
            if (lv.SignFor != "")
            {
                fr = "For: " + lv.SignFor;
            }
            _context.reportwriting.Where(x => x.Id == lv.Id).ToList().ForEach(x =>
            {
                x.SignFor = fr;
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ApproveRPT(string id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.reportwriting.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveRPT(string id, reportwriting lv)
        {
            if (id != lv.Id)
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



            
            string Sign = "";
            var usr = HttpContext.Session.GetString("StaffName");
            var sign = _context.signatures.Where(u => (u.UserID == userID)).FirstOrDefault();
            if (sign != null)

            {
                Sign = sign.SignFile;
            }
           
            _context.reportwriting.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {
                
                x.Authorise = Sign;
                x.Authorisedby = usr;
                x.Remark = lv.Remark;

                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        public async Task<IActionResult> ApproveCon(int? id)
        {


          
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Confirmationofappointment.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);




        }
        [HttpPost]
        public async Task<IActionResult> ApproveCon(int id, Confirmationofappointment lv)
        {
            if (id != lv.Id)
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



            _context.Confirmationofappointment.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost, ActionName("ReverseCon")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReverseConConfirm(int id, Confirmationofappointment lv)
        {
            

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



            _context.Confirmationofappointment.Where(x =>  x.Id == lv.Id).ToList().ForEach(x =>
            {

                if (HttpContext.Session.GetString("RoleID") == "Executive Director")
                {
                    x.Remark = lv.Remark;
                }
                else if (HttpContext.Session.GetString("RoleID") == "Director")
                {
                    x.Remark1 = lv.Remark;
                }
                else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
                {
                    x.Remark2 = lv.Remark;
                }
                else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
                {
                    x.Remark3 = lv.Remark;
                }
                else if (HttpContext.Session.GetString("RoleID") == "Staff")
                {
                     x.Remark4 = lv.Remark; 
                }
              

                x.Status = "No";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "No";
                    x.Status = "No";
                });
                await _context.SaveChangesAsync();
            }



           
            var box = (from s in _context.Box where (s.ReceiverID1 == userID || s.ReceiverID == userID || s.ReceiverID2 == userID || s.ReceiverID3 == userID || s.ReceiverID4 == userID || (s.UserID == userID && s.Status == "Approved")) orderby s.Id descending select s);

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", box.ToList()) });
            //return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> ReverseCon(int? id)
        {

            var lv = await _context.Confirmationofappointment

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost]
        public async Task<IActionResult> Approve(string id,Leaves lv)
        {
            if (id != lv.Id)
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

            

                _context.Leaves.Where(x => x.Status == "Pending" && x.Id == lv.Id).ToList().ForEach(x =>
                {



                    x.Status = "Approved";
                });
            int i=  await  _context.SaveChangesAsync();

            if (i>0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                 await _context.SaveChangesAsync();
            }

            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public async Task<IActionResult> ApproveLeave()
        {


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
           
                
                  
                        _context.Leaves.Where(x => x.Status == "Pending"  && x.BoxId== BoxID).ToList().ForEach(x =>
                        {
                           


                            x.Status = "Approved";
                        });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult DisapproveLeave()
        {


           
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
            


                _context.Leaves.Where(x => x.Status == "Pending" && x.BoxId == BoxID).ToList().ForEach(x =>
                {



                    x.Status = "Diapproved";
                });
                _context.SaveChanges();



            

            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public async Task<IActionResult> ApproveAllPro()
        {


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



            _context.CareerProgression.Where(x => x.Status == "Pending" && x.CareerId == BoxID).ToList().ForEach(x =>
            {


                
                x.Status = "Approved";
            });
            await _context.SaveChangesAsync();
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {
                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult DisapproveAllPro()
        {


          
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



            _context.CareerProgression.Where(x => x.Status == "Pending" && x.CareerId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }

       

             [HttpPost]
        public async Task<IActionResult> ApproveAllRetirement()
        {


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



            _context.retirementbiodata.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            await _context.SaveChangesAsync();

            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }



            return RedirectToAction(nameof(BoxesController.Index));

        }

        
              [HttpPost]
        public async Task<IActionResult> ApproveAllIT()
        {


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



            _context.itstudent.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public async Task<IActionResult> ApproveAllTraining()
        {


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



            _context.TrainingAndStudy.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public async Task<IActionResult> ApproveAllPosting()
        {


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



            _context.StaffPosting.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {

                    x.UserStatus = "Waiting";

                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
      
            [HttpPost]
        public IActionResult DisapproveAllRetirement()
        {


            
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



            _context.retirementbiodata.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult DisapproveAllIT()
        {

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



            _context.itstudent.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult DisapproveAllTraining()
        {


          
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



            _context.TrainingAndStudy.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult DisapproveAllPosting()
        {


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



            _context.StaffPosting.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public async Task<IActionResult> ApproveAllCon()
        {


           
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



            _context.Confirmationofappointment.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public async Task<IActionResult> ApproveAllMemo()
        {
           
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
            _context.Memo.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {
                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(BoxesController.Index));
        }
        [HttpPost]
        public async Task<IActionResult> ApproveAllRPT()
        {


          
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



            _context.reportwriting.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Approved";
            });
            int i = await _context.SaveChangesAsync();

            if (i > 0)
            {
                _context.Box.Where(x => x.IdNo == BoxID).ToList().ForEach(x =>
                {


                    x.UserStatus = "Waiting";
                    x.Status = "Approved";
                });
                await _context.SaveChangesAsync();
            }





            return RedirectToAction(nameof(BoxesController.Index));

        }

        [HttpPost]
        public IActionResult DisapproveAllCon()
        {


          
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



            _context.Confirmationofappointment.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        
            [HttpPost]
        public IActionResult DisapproveAllMemo()
        {

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



            _context.reportwriting.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [HttpPost]
        public IActionResult DisapproveAllRPT()
        {


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



            _context.reportwriting.Where(x => x.Status == "Pending" && x.ConId == BoxID).ToList().ForEach(x =>
            {



                x.Status = "Diapproved";
            });
            _context.SaveChanges();





            return RedirectToAction(nameof(BoxesController.Index));

        }
        [NoDirectAccess]
        public async Task<IActionResult> MinuteOfTheMeetingList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.MinuteOfMeeting where  s.BoxID == bx.IdNo orderby s.Id ascending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> MonthlyReturnList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.monthlyreturn where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> RetirementList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.retirementbiodata where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PostingList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.StaffPosting where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));

                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            
            
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ITStudent(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.itstudent where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus4(id);
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> DailyMotorVehicleWorkBookList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.DailyMotorVehicleWorkBook where s.DailyID == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus4(id);
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> VisitorList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Visitor where (s.VisitID == bx.IdNo) orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus4(id);
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ConfirmationList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Confirmationofappointment where s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus4(id);
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PromotionList(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.CareerProgression where  s.CareerId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> PersonnelFile(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.PersonelFile where s.ConId == bx.IdNo orderby s.ID descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director" )
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));

                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> MemoReport(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Memo where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));

                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> RPTReport(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.reportwriting where  s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));

                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> TrainingAndStudy(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.TrainingAndStudy where (s.UserID == userID || s.ReceiverID1 == userID || s.ReceiverID == userID || s.ReceiverID2 == userID || s.ReceiverID3 == userID || s.ReceiverID4 == userID) && s.ConId == bx.IdNo orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));

                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> LeaveRoster(int id)
        {
            var bx = await _context.Box.FindAsync(id);
            HttpContext.Session.SetString("boxID", bx.IdNo);
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Leaves where  s.BoxId==bx.IdNo  orderby s.Id descending select s);
            DALClass sign = new DALClass(configuration);
            if (HttpContext.Session.GetString("RoleID") == "Executive Director")
            {
                    string sec= HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Director" || HttpContext.Session.GetString("RoleID") == "HOD" || HttpContext.Session.GetString("RoleID") == "Administrator")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus1(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Unit Head")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
                sign.UpdateStatus2(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Zonal Head")
            {                 string sec = HttpContext.Session.GetString("nMessage");
            int num = Convert.ToInt32(sec);
            if (num > 0)
            {
                num = num - 1;
            }
            HttpContext.Session.SetString("nMessage", Convert.ToString(num));
            sign.UpdateStatus3(id);
            }
            else if (HttpContext.Session.GetString("RoleID") == "Staff")
            {
                string sec = HttpContext.Session.GetString("nMessage");
                int num = Convert.ToInt32(sec);
                if (num > 0)
                {
                    num = num - 1;
                }
                HttpContext.Session.SetString("nMessage", Convert.ToString(num));
             
                if (HttpContext.Session.GetString("section") == "Section Head")
                {
                    sign.UpdateStatus4(id);
                }
                else
                {
                    sign.UpdateUserStatus(id);
                }
            }
            return View(await box.ToListAsync());
        }
        // GET: Boxes
        [NoDirectAccess]
        public async Task<IActionResult> ViewMinute(string id = "")
        {
            
            string Id = "";
            if (id == "")
            {
                Id = HttpContext.Session.GetString("ID");
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.MinuteOfMeeting where s.MinuteID == Id  orderby s.Id ascending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewConfirmationLetter(int id=0)
        {
            
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Confirmationofappointment where s.Id == Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewLeaveLetter(string id="")
        {
          
            string Id = "";
            if (id=="")
            {
                Id= HttpContext.Session.GetString("ID"); 
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Leaves where s.Id==Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewPromotionLetter(int id=0)
        {
            
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.CareerProgression where s.Id==Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewRetirementLetter(int id=0)
        {
          
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.retirementbiodata where s.Id == Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewItLetter(int id=0)
        {
           
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.itstudent where s.Id == Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewPostingLetter(int id=0)
        {
         
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.StaffPosting where s.Id == Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> ViewTrainingLetter(int id=0)
        {
            
            int Id = 0;
            if (id == 0)
            {
                Id = int.Parse(HttpContext.Session.GetString("ID"));
            }
            else
            {
                Id = id;
            }
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.TrainingAndStudy where s.Id == Id  orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            string userID = HttpContext.Session.GetString("UserID");
            var box = (from s in _context.Box   orderby s.Id descending select s);
            return View(await box.ToListAsync());
        }

        // GET: Boxes/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box
                .FirstOrDefaultAsync(m => m.Id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // GET: Boxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,Description,Controllers,Actions,Id,Status,Dates,Date,Yr,Mnt,Dy")] Box box)
        {
            if (ModelState.IsValid)
            {
                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                Int32 dy= CurrentServerTime.Day;
                Int32 mnt = CurrentServerTime.Month;
                box.Dy = Convert.ToString(dy);
                box.Yr = Convert.ToString(Yr);
                box.Mnt = Convert.ToString(mnt);
                box.Date = DateTime.UtcNow.Date;
                box.Dates = dates;
                box.Status = "Waiting";
                _context.Add(box);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(box);
        }

        // GET: Boxes/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Box.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject,Description,Controllers,Actions,Id,Status")] Box box)
        {
            if (id != box.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    box.Status = "Waiting";
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxExists(box.Id))
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
            return View(box);
        }
        [NoDirectAccess]
        public async Task<IActionResult> RemovePro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lv = await _context.CareerProgression

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemovePro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemovePro(int id)
        {
            var lv = await _context.CareerProgression.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.CareerProgression.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NoDirectAccess]
        public async Task<IActionResult> RemoveRetirement(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var lv = await _context.retirementbiodata

                .FirstOrDefaultAsync(m => m.SprpNo == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveRetirement")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveRetirement(string id)
        {
            
            var lv = await _context.retirementbiodata.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.retirementbiodata.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NoDirectAccess]
        public async Task<IActionResult> RemovePosting(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var lv = await _context.StaffPosting

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemovePosting")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemovePosting(int id)
        {
           
            var lv = await _context.StaffPosting.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.StaffPosting.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
        [NoDirectAccess]
        public async Task<IActionResult> RemoveCon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var lv = await _context.Confirmationofappointment

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveCon")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveCon(int id)
        {
            var lv = await _context.Confirmationofappointment.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.Confirmationofappointment.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NoDirectAccess]
        public async Task<IActionResult> RemoveMonthlyReturn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var lv = await _context.monthlyreturn

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveMonthlyReturn")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveMonthlyReturn(int id)
        {
            
            var lv = await _context.monthlyreturn.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.monthlyreturn.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }
        [NoDirectAccess]
        public async Task<IActionResult> RemoveMemo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lv = await _context.Memo

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveMemo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveMemo(int id)
        {
          
            var lv = await _context.Memo.FindAsync(id);
            if (lv.Status == "Read" || lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.Memo.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NoDirectAccess]
        public async Task<IActionResult> RemoveTraining(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var lv = await _context.TrainingAndStudy

                .FirstOrDefaultAsync(m => m.Id == id);

            if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("RemoveTraining")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemoveTraining(int id)
        {
          
            var lv = await _context.TrainingAndStudy.FindAsync(id);
            if (lv.Status == "Read" || lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.TrainingAndStudy.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [NoDirectAccess]
        public async Task<IActionResult> Remove(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var lv = await _context.Leaves
                
                .FirstOrDefaultAsync(m => m.Id == id);
            
                if (lv == null)
            {
                return NotFound();
            }

            return View(lv);
        }
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRemove(string id)
        {
            
            var lv = await _context.Leaves.FindAsync(id);
            if (lv.Status == "Approved" || lv.Status == "Disapproved")
            {
                ModelState.AddModelError("", "Cannot Remove Contact ED");
                return View();
            }
            _context.Leaves.Remove(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Boxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var box = await _context.Box
                .FirstOrDefaultAsync(m => m.Id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var box = await _context.Box.FindAsync(id);
            _context.Box.Remove(box);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxExists(int id)
        {
            return _context.Box.Any(e => e.Id == id);
        }
    }
}
