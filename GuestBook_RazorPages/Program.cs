using Microsoft.EntityFrameworkCore;
using GuestBook_RazorPages.Models;
using GuestBook_RazorPages.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // ������������ ������ (����-��� ���������� ������)
    options.Cookie.Name = "Session"; // ������ ������ ����� ���� �������������, ������� ����������� � �����.

});
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlServer(connection));

builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository, GuestBookRepository>();

var app = builder.Build();
app.UseSession();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
