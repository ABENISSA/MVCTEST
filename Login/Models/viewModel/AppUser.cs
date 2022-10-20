using Microsoft.AspNetCore.Identity;

namespace Login.Models.viewModel
{
    public class AppUser :IdentityUser
    {
        public string EmpNo { get; set; }

    }
}
