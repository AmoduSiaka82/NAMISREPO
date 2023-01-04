using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NAMIS.DAL;
using NAMIS.Data;
using NAMIS.Models;

namespace NAMIS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<useraccount> _signInManager;
        private readonly UserManager<useraccount> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public RegisterModel(
            UserManager<useraccount> userManager,
            SignInManager<useraccount> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDbContext context,IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            this.configuration = config;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Staff Name")]
            public string StaffName { get; set; }
            [Display(Name = "Station")]
            public string StationName { get; set; }
            [Display(Name = "First Name")]
            [Required]
            public string FirstName { get; set; }
            [Display(Name = "Surname")]
            [Required]
            public string LastName { get; set; }
            [Display(Name = "Middle Name")]

            public string MiddleName { get; set; }
            [Display(Name = "Title")]
            [Required]
            public string Title { get; set; }
            [Display(Name = "User ID")]
           
            public string UserID { get; set; }
            public string Department { get; set; }
            public string RoleID { get; set; }
        }
     
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                int iNo;

                string genNo = "";
                string id = "";
                DALClass genID = new DALClass(configuration);

                genNo = genID.StaffNoAuto().ToString();

                if (genNo.Equals("") || genNo == null)
                {
                    iNo = 00001;
                }
                else
                {
                    iNo = int.Parse(genNo);
                    iNo++;
                }
                if (iNo < 10) { id = "0000" + Convert.ToString(iNo); }
                else if (10 <= iNo && iNo < 100) { id = "000" + Convert.ToString(iNo); }
                else if (100 <= iNo && iNo < 1000) { id = "00" + Convert.ToString(iNo); }
                else if (1000 <= iNo && iNo < 10000) { id = "0" + Convert.ToString(iNo); }
                else id = Convert.ToString(iNo);
                string staffName =Input.Title + " " + Input.LastName + " " + Input.MiddleName + " " + Input.FirstName;
                var user = new useraccount { UserName = Input.Email, Email = Input.Email,Title=Input.Title,LastName=Input.LastName,FirstName=Input.FirstName,StaffName= staffName,StationName="",UserID=id,Department="",RoleID = "" };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                   
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
