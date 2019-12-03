using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Web.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        public ConfirmEmailModel()
        {
        }

        public IActionResult OnGetAsync(string userId, string code)
        {
            return null;
        }
    }
}
