using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Pages;
using Microsoft.EntityFrameworkCore;

namespace GuestBook_RazorPages.Repository
{
    public class GuestBookRepository : IRepository
    {
        private readonly GuestBookContext db;
        public GuestBookRepository(GuestBookContext context)
        {
            db = context;
        }

        public async Task<List<Message>> MessagesToList()
        {
            return await db.Messages.ToListAsync();
        }

        public async Task<IEnumerable<Message>> MessagesToListIEnumerable()
        {
            return await db.Messages.ToListAsync();
        }

        public async Task AddMessage(Message message)
        {
            await db.Messages.AddAsync(message);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public async Task<User> FindUserById(string str)
        {
            return db.Users.FirstOrDefault(a => a.Name == str);
        }

        public async Task AddUser(User user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task<int> UsersCount()
        {
            return await db.Users.CountAsync();
        }

        public async Task<int> CheckingLoginCount(LogModel login)
        {
            return await db.Users.Where(a => a.Name == login.Name).CountAsync();
        }

        public async Task<User> CheckingLogin(LogModel login)
        {
            return db.Users.FirstOrDefault(a => a.Name == login.Name);
        }
    }
}
