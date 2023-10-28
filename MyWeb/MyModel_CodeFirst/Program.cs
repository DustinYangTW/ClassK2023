using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫法var builder這行後面)
builder.Services.AddDbContext<GuestBookContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection"))
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
