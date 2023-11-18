using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//1.1.4 在Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫在var builder這行後面)
builder.Services.AddDbContext<dbStudentsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbStudentsConnection"))
);


// Add services to the container.
builder.Services.AddControllersWithViews();


//2.2.2 在Program.cs中註冊及啟用Swagger
builder.Services.AddSwaggerGen();


var app = builder.Build();

//啟用Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
