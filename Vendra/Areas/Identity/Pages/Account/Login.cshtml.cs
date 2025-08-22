using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vendra.Models;


namespace Vendra.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private string UserMail;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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

            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                UserMail = Input.Email;

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    if (user is null) return LocalRedirect("/Home/Index");

                    // Otomatik Type atama
                    if (user.Type == "Admin")
                    {       
                        await _userManager.UpdateAsync(user);
                        return LocalRedirect("/Admin/Dashboard/Index");
                    }
                    else if (user.Type == "Seller")
                    {                     
                        await _userManager.UpdateAsync(user);
                        return LocalRedirect("/Seller/Dashboard/Index");
                    }
                    else
                    {
                        user.Type = "Customer";
                        await _userManager.UpdateAsync(user);
                        return LocalRedirect("/Home/Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}

