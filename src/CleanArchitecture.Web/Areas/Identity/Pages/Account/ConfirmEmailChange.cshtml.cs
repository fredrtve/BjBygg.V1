using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

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
