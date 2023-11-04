using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

var builder = WebApplication.CreateBuilder(args);

//1.2.4 在Program.cs內以依賴注入的寫法撰寫讀取連線字串的物件
builder.Services.AddDbContext<GuestBookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection"))
);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//1.3.3 在Program.cs撰寫啟用Initializer的程式
//*****(要寫在var app = builder.Build();之後)******
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}




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
