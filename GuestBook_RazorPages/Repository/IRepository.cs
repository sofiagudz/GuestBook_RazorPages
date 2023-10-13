using GuestBook_RazorPages.Models;
namespace GuestBook_RazorPages.Repository
{
    public interface IRepository
    {
        Task<List<Message>> MessagesToList();
        Task<IEnumerable<Message>> MessagesToListIEnumerable();
        Task AddMessage(Message message);
        Task Save();
        Task<User> FindUserById(string str);
        Task AddUser(User user);
        Task<int> UsersCount();
        Task<int> CheckingLoginCount(LogModel login);
        Task<User> CheckingLogin(LogModel login);
    }
}
