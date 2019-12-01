using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.Web.Pages.Users
{
    [Authorize(Roles = "Leder")]
    public class EditModel : PageModel
    {
        private readonly IUserViewModelService _service;

        public EditModel(IUserViewModelService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserViewModel UserView { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public async Task OnGet(string userName)
        {          
            UserView = await _service.GetUserFromId(userName);
            Roles = _service.GetRoles(UserView.Role);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Roles = _service.GetRoles(UserView.Role);
                return Page();
            }

            await _service.UpdateUserFromViewModel(UserView);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetDelete(string userName)
        {
            var result = await _service.DeleteUserByUserName(userName);

            if (!result)
            {
                Roles = _service.GetRoles(UserView.Role);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
