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
    public class MemosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public MemosController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: Memos
        public async Task<IActionResult> Index()
        {
          

            var bio = (from s in _context.Memo where s.Status=="No" select s);

            return View(await bio.ToListAsync());
           
        }

        // GET: Memos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }

            return View(memo);
        }

        // GET: Memos/Create
        public IActionResult Create()
        {
        
            return View();
        }

        // POST: Memos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Body,Address,ReportTitle,Id,Status,Recipient,StationName,Status,RefNo")] Memo memo)
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
                string userID = HttpContext.Session.GetString("UserID");
                string stations = HttpContext.Session.GetString("station");
                memo.StationName = stations;
                memo.Status = "No";
                memo.Nspri = "NIGERIAN STORE PRODUCTS RESEARCH INSTITUTE";
                memo.MemoTitle = "INTERNAL MEMORADUM";
                memo.Date = date;
                memo.Dates = dates;
                memo.UserID = userID;
                memo.Id = 0;
                _context.Add(memo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memo);
        }

        // GET: Memos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memo.FindAsync(id);
            if (memo == null)
            {
                return NotFound();
            }
            return View(memo);
        }

        // POST: Memos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Body,Address,ReportTitle,Id,Status,Recipient,StationName,Status,RefNo")] Memo memo)
        {
            
            if (id != memo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 
                    
                    string formats = "MM/dd/yyyy";
                    string formatedTime = DateTime.Now.ToString("HH:mm:ss");
                    string format = "dd/MM/yyyy";
                    DateTime CurrentServerTime = DateTime.UtcNow.AddHours(1);
                    Int32 Yr = CurrentServerTime.Year;
                    string date = Convert.ToString(CurrentServerTime.ToString(format));
                    string dates = Convert.ToString(CurrentServerTime.ToString(formats));
                    string time = Convert.ToString(CurrentServerTime.ToString(formatedTime));
                    string userID = HttpContext.Session.GetString("UserID");
                    string stations = HttpContext.Session.GetString("station");
                    memo.StationName = stations;
                    memo.Status = "No";
                    memo.Nspri = "NIGERIAN STORE PRODUCTS RESEARCH INSTITUTE";
                    memo.MemoTitle = "INTERNAL MEMORADUM";
                    memo.Date = date;
                    memo.Dates = dates;
                    memo.UserID = userID;
                    memo.StationName = stations;
                    memo.Status = "No";
                    _context.Update(memo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoExists(memo.Id))
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
            return View(memo);
        }

        // GET: Memos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }

            return View(memo);
        }

        // POST: Memos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
         

            var memo = await _context.Memo.FindAsync(id);
            _context.Memo.Remove(memo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoExists(int id)
        {
            return _context.Memo.Any(e => e.Id == id);
        }
    }
}
