using CleanArchitecture.Web.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Pages.Employers
{
    [Authorize(Roles = "Leder, Mellomleder")]
    public class IndexModel : PageModel
    {
        private readonly IEmployerViewModelService _service;

        public IndexModel(IEmployerViewModelService service)
        {
            _service = service;
        }

        public IEnumerable<EmployerViewModel> Employers { get; set; }

        public async Task OnGet()
        {
            Employers = await _service.GetEmployers();
        }


    }
}
