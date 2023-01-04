using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class reportwritingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;
        public reportwritingsController(IConfiguration config, ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            this.configuration = config;
        }
       
        // GET: reportwritings
        public async Task<IActionResult> Index()
        { 
            

           var bio = (from s in _context.reportwriting where s.Status == "No" select s);

            return View(await bio.ToListAsync());
        
        }

        // GET: reportwritings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportwriting = await _context.reportwriting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportwriting == null)
            {
                return NotFound();
            }

            return View(reportwriting);
        }

        //private string UploadedFile(reportwritingModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ReportFile != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ReportFile.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ReportFile.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
        // GET: reportwritings/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: reportwritings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Body,Address,ReportTitle,ReportFile,Id,Status,RefNo,Recipient")] reportUploadModel rptwriting)
        {
          
            if (ModelState.IsValid)
            {
                int iNo;
                string RId = "";
                string RINo = "";
                DALClass sign = new DALClass(configuration);
                RINo = sign.RINoAuto().ToString();

                if (RINo.Equals("") || RINo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(RINo);
                    iNo++;
                }
                if (iNo < 10) { RId = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { RId = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { RId = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { RId = "0" + Convert.ToString(iNo); }
                else RId = Convert.ToString(iNo);
                string uniqueFileName = null;

                if (rptwriting.ReportFile != null && rptwriting.ReportFile.Count>0)
                {
                    foreach (IFormFile file in rptwriting.ReportFile)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));
                        
                        reportupload rptUpload = new reportupload
                        {
                        
                            ReportFile = uniqueFileName,
                            RId = RId,
                            Id = 0,
                        };
                        _context.Add(rptUpload);
                        await _context.SaveChangesAsync();
                    }
                   
                }
                string formats = "MM/dd/yyyy";
                string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                string format = "dd/MM/yyyy";
                DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                Int32 Yr = CurrentServerTime.Year;
                string date = Convert.ToString(CurrentServerTime.ToString(format));
                string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                string userID = HttpContext.Session.GetString("UserID");
                if (uniqueFileName == null)
                {
                    uniqueFileName = "";
                }
                reportwriting rptWrite = new reportwriting
                {
                    Body = rptwriting.Body,
                    Address = rptwriting.Address,
                    ReportTitle = rptwriting.ReportTitle,
                    ReportFile = uniqueFileName,
                    Id = RId,
                    Date = DateTime.UtcNow.Date,
                    Dates =dates,
                    Recipient = rptwriting.Recipient,
                    RefNo = rptwriting.RefNo,
                    UserID = userID,
                    Status ="No",
                    
                    
                };
                
                _context.Add(rptWrite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rptwriting);
        }

        // GET: reportwritings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
         
            if (id == null)
            {
                return NotFound();
            }

            var reportwriting = await _context.reportwriting.FindAsync(id);
            if (reportwriting == null)
            {
                return NotFound();
            }
            return View(reportwriting);
        }

        // POST: reportwritings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Body,Address,ReportTitle,ReportFile,Id,Status,ReceiverID,ReceiverID1,ReceiverID2,ReceiverID3,ReceiverID4,ConId")] reportwriting reportwriting)
        {
           
            if (id != reportwriting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportwriting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reportwritingExists(reportwriting.Id))
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
            return View(reportwriting);
        }

        // GET: reportwritings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var reportwriting = await _context.reportwriting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportwriting == null)
            {
                return NotFound();
            }

            return View(reportwriting);
        }

        // POST: reportwritings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var reportwriting = await _context.reportwriting.FindAsync(id);
            var rptFile = Path.Combine(webHostEnvironment.WebRootPath, "image", reportwriting.ReportFile);
            if (System.IO.File.Exists(rptFile))
            {
                System.IO.File.Delete(rptFile);
            }
            var fileVerify = _context.reportupload.Where(x => x.RId == reportwriting.Id).FirstOrDefault();
            if (fileVerify != null)
            {
                var reportupld = _context.reportupload.Where(r => r.RId == reportwriting.Id);
                var rptFiles = Path.Combine(webHostEnvironment.WebRootPath, "image", fileVerify.ReportFile);
                if (System.IO.File.Exists(rptFiles))
                {
                    System.IO.File.Delete(rptFiles);
                }
                _context.reportupload.RemoveRange(reportupld);
                await _context.SaveChangesAsync();
            }
            _context.reportwriting.Remove(reportwriting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reportwritingExists(string id)
        {
            return _context.reportwriting.Any(e => e.Id == id);
        }
    }
}
