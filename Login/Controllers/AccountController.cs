using Login.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext1 db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(AppDBContext1 db,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
                    {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var res = await userManager.Users.ToListAsync();
            return View(res);
        }
    }
}
