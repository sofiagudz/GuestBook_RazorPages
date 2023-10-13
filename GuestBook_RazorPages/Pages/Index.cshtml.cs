using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBook_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository repo;
        public IndexModel(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["Messages"] = await repo.MessagesToList();
            return Page();
        }

        [BindProperty]
        public Message Messages { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string login = HttpContext.Session.GetString("Login");
                var user = await repo.FindUserById(login);

                Messages.User = user;
                Messages.UserName = HttpContext.Session.GetString("Login");
                Messages.MessageDate = DateTime.Now;
                repo.AddMessage(Messages);
                await repo.Save();
                return RedirectToPage("Index");
            }
            catch (Exception)
            {
                return RedirectToPage("Index");
            }
        }
    }
}