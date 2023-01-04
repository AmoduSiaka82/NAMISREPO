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
    public class signaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public signaturesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: signatures
        public async Task<IActionResult> Index()
        {
           
            string userID = HttpContext.Session.GetString("UserID");

            var bio = (from s in _context.signatures where s.UserID == userID select s);

            return View(await bio.ToListAsync());
           
        }

        // GET: signatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var signatures = await _context.signatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signatures == null)
            {
                return NotFound();
            }

            return View(signatures);
        }

        // GET: signatures/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: signatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignFile,Id,UserID")] signaturesModel signatures)
        {
            
            if (ModelState.IsValid)
            {
                string userID = HttpContext.Session.GetString("UserID");
                var accountVerify = _context.signatures.Where(x => x.UserID == userID).FirstOrDefault();
                if (accountVerify != null)
                {
                  
                    ModelState.AddModelError("", "Signature already captured");
                    return View();
                }
                string uniqueFileName = null;

                if (signatures.SignFile != null && signatures.SignFile.Count > 0)
                {
                    foreach (IFormFile file in signatures.SignFile)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "sign");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));

                    }

                }
               
                if (uniqueFileName == null)
                {
                    uniqueFileName = "";
                }
                signatures rptFile = new signatures
                {
                SignFile = uniqueFileName,
                UserID = userID,
                Id = 0,
                };
                _context.Add(rptFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signatures);
        }

        // GET: signatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var signatures = await _context.signatures.FindAsync(id);
            if (signatures == null)
            {
                return NotFound();
            }
            signaturesModel signModel=new signaturesModel();
            signModel.Id = signatures.Id;
            return View(signModel);
        }

        // POST: signatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SignFile,Id,UserID")] signaturesModel signatures)
        {
            
            if (id != signatures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;

                    if (signatures.SignFile != null && signatures.SignFile.Count > 0)
                    {
                        foreach (IFormFile file in signatures.SignFile)
                        {
                            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "sign");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            file.CopyTo(new FileStream(filePath, FileMode.Create));

                        }

                    }
                    string userID = HttpContext.Session.GetString("UserID");
                    if (uniqueFileName == null)
                    {
                        uniqueFileName = "";
                    }
                    signatures rptFile = new signatures
                    {
                        SignFile = uniqueFileName,
                        UserID = userID,
                        Id = 0,
                    };
                    _context.Update(rptFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!signaturesExists(signatures.Id))
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
            return View(signatures);
        }

        // GET: signatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var signatures = await _context.signatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signatures == null)
            {
                return NotFound();
            }

            return View(signatures);
        }

        // POST: signatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var signatures = await _context.signatures.FindAsync(id);
            var rptFile = Path.Combine(webHostEnvironment.WebRootPath, "images", signatures.SignFile);
            if (System.IO.File.Exists(rptFile))
            {
                System.IO.File.Delete(rptFile);
            }
            _context.signatures.Remove(signatures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool signaturesExists(int id)
        {
            return _context.signatures.Any(e => e.Id == id);
        }
    }
}
