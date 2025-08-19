using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vendra.Models;
using Vendra.Services;

namespace Vendra.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GeneralService _generalService;

        public RegisterModel(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             GeneralService generalService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _generalService = generalService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
  

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Type { get; set; } 
            public bool RememberMe { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> UserTypes { get; set; }

        }

        public async Task OnGetAsync(string returnurl = null)
        {
            returnurl ??= Url.Content("~/");

            List<SelectListItem> userTypes = new()
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Customer", Text = "Customer" },
                new SelectListItem { Value = "Seller", Text = "Seller" },
                new SelectListItem { Value = "User", Text = "User" },
            };

            //Input = new InputModel{ UserTypes = _generalService.GetUserTypeList("") };
            Input = new InputModel{ UserTypes = userTypes };
            // Burada db.UserTypes tablosundaki veriler çekilecek
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {            
                var user = new ApplicationUser { UserName =Input.Email, Email =Input.Email, Type =Input.Type };
                var result = await _userManager.CreateAsync(user,Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index"); 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
