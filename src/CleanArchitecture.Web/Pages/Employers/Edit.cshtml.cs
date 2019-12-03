using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Pages.Employers
{
    [Authorize(Roles = "Leder")]
    public class EditModel : PageModel
    {
        private readonly IEmployerViewModelService _service;
        private readonly IConfiguration _config;

        public EditModel(IEmployerViewModelService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [BindProperty]
        public EmployerViewModel Employer { get; set; }

        public string GoogleMapsApiKey { get; set; }

        public async Task OnGet(int id)
        {
            Employer = await _service.GetEmployer(id);
            GoogleMapsApiKey = _config["GoogleMapsApiKey"];
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                GoogleMapsApiKey = _config["GoogleMapsApiKey"];
                return Page();
            }

            await _service.UpdateEmployerFromViewModel(Employer);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var success = await _service.DeleteEmployerById(id);
            if (success) return RedirectToPage("./Index");
            else return BadRequest("Fant ikke oppdrag");
        }

    }
}
