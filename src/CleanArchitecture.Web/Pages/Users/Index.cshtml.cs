using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public UserListViewModel EmployeeList { get; set; }
        public UserListViewModel LeaderList { get; set; }
        public UserListViewModel ManagerList { get; set; }

        public async Task OnGet()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Ansatt");
            var employeeView = employees.Select(a => new UserViewModel(a));
            EmployeeList = new UserListViewModel(employees.Select(a => new UserViewModel(a) { Role = "Ansatt" }), "Ansatte", "fa fa-users");

            var leaders = await _userManager.GetUsersInRoleAsync("Leder");
            LeaderList = new UserListViewModel(leaders.Select(a => new UserViewModel(a) { Role = "Leder" }), "Leder", "fa fa-crown", "bg-warning text-dark");

            var managers = await _userManager.GetUsersInRoleAsync("Mellomleder");
            ManagerList = new UserListViewModel(managers.Select(a => new UserViewModel(a) { Role = "Mellomleder" }), "Mellomledere", "fa fa-users");
        }

    }
}
