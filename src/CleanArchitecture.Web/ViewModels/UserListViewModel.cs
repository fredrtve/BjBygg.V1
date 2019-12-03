using System.Collections.Generic;

namespace CleanArchitecture.Web.ViewModels
{
    public class UserListViewModel
    {
        public UserListViewModel() { }
        public UserListViewModel(IEnumerable<UserViewModel> users, string headerName, string headerIcon, string headerStyling = "bg-dark text-white")
        {
            Users = users;
            HeaderName = headerName;
            HeaderIcon = headerIcon;
            HeaderStyling = headerStyling;
        }

        public string HeaderName { get; set; }
        public string HeaderIcon { get; set; }
        public string HeaderStyling { get; }
        public IEnumerable<UserViewModel> Users { get; set; }

    }
}
