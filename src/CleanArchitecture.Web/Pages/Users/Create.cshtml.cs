using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.Web.Pages.Users
{
    [Authorize(Roles = "Leder")]
    public class CreateModel : PageModel
    {
        private readonly IUserViewModelService _service;

        public CreateModel(IUserViewModelService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserViewModel UserView { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Passord")]
        [StringLength(150, ErrorMessage = "{0} må være på minst {2} tegn.", MinimumLength = 7)]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public IActionResult OnGet()
        {
            Roles = _service.GetRoles();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            var result = await _service.CreateUserFromViewModel(UserView, Password);          

            if (result) return RedirectToPage("./Index");
            
           return Page();
        }
    }
}
