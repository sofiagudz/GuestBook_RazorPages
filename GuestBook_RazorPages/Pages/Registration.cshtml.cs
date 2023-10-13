using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBook_RazorPages.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly IRepository repo;
        public RegistrationModel(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterModel RegModel { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = RegModel.Name;
                user.Password = RegModel.Password;
                repo.AddUser(user);
                repo.Save();
                return RedirectToPage("./Login");
            }
            return Page();
        }
    }
}
