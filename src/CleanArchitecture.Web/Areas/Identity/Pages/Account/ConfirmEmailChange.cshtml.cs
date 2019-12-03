using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Areas.Identity.Pages.Account
{
    public class ConfirmEmailChangeModel : PageModel
    {

        public ConfirmEmailChangeModel()
        {

        }

        public IActionResult OnGetAsync(string userId, string email, string code)
        {
            return Page();
        }
    }
}
