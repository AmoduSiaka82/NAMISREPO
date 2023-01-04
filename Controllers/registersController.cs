using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMIS.Data;
using NAMIS.Models;
using System.Linq;
using System.Threading.Tasks;
using static NAMIS.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace NAMIS.Controllers
{
    public class registersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<useraccount> userManager;
        private readonly SignInManager<useraccount> SignInManager;

        public registersController(UserManager<useraccount> userManager, SignInManager<useraccount> SignInManager, IConfiguration config, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SignInManager = SignInManager;
            _context = context;
            this.configuration = config;
        }

        // GET: registers
        public async Task<IActionResult> Index()
        {
        
            string userID= HttpContext.Session.GetString("UserID");
            HttpContext.Session.SetString("Check", "Okay");
            var reg = (from s in _context.register where s.UserID==userID && s.Status=="No" select s);

            return View(await reg.ToListAsync());
           
        }

        // GET: registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.register
                .FirstOrDefaultAsync(m => m.ID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: registers/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SprpNo,UserID,ID,Surname,MiddleName,FirstName")] register register)
        {
            
            if (ModelState.IsValid)
            {
                string sprpNo = HttpContext.Session.GetString("SPRP");
                register.SprpNo = sprpNo;
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.register.FindAsync(id);
        
            HttpContext.Session.SetString("SPRP", register.SprpNo);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SprpNo,UserID,ID,Surname,MiddleName,FirstName")] register register)
        {
            
            if (id != register.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string sprpNo = HttpContext.Session.GetString("SPRP");
                    register.SprpNo = sprpNo;
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!registerExists(register.ID))
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
            return View(register);
        }

        // GET: registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.register

                .FirstOrDefaultAsync(m => m.ID == id);
            HttpContext.Session.SetString("SPRP", register.SprpNo);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.register.FindAsync(id);
            _context.register.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool registerExists(int id)
        {
            return _context.register.Any(e => e.ID == id);
        }
    }
}
