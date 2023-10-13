using Microsoft.EntityFrameworkCore;
using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Длительность сеанса (тайм-аут завершения сеанса)
    options.Cookie.Name = "Session"; // Каждая сессия имеет свой идентификатор, который сохраняется в куках.

});
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlServer(connection));

builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository, GuestBookRepository>();

var app = builder.Build();
app.UseSession();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
