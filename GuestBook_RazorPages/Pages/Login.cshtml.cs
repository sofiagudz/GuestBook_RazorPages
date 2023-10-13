using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBook_RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRepository repo;
        public LoginModel(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogModel LogModel { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (repo.UsersCount == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return Page();
                }
                var user = await repo.CheckingLogin(LogModel);
                if (repo.CheckingLoginCount(LogModel) == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return Page();
                }
                HttpContext.Session.SetString("Login", user.Name);
            }
            return RedirectToPage("./Index");
        }
    }
}
