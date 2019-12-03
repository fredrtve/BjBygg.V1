using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Pages.Employers
{
    [Authorize(Roles = "Leder, Mellomleder")]
    public class CreateModel : PageModel
    {
        private readonly IEmployerViewModelService _service;

        private readonly IConfiguration _config;

        public CreateModel(IEmployerViewModelService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [BindProperty]
        public EmployerViewModel Employer { get; set; }

        public string GoogleMapsApiKey { get; set; }

        public IActionResult OnGet()
        {
            GoogleMapsApiKey = _config["GoogleMapsApiKey"];
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                GoogleMapsApiKey = _config["GoogleMapsApiKey"];
                return Page();
            }

            await _service.CreateEmployerFromViewModel(Employer);

            return RedirectToPage("./Index");
        }
    }
}
