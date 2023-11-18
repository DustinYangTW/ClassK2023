using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//1.1.4 �bProgram.cs�[�J�ϥ�appsettings.json�����s�u�r��{���X(�o�q�����g�bvar builder�o��᭱)
builder.Services.AddDbContext<dbStudentsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbStudentsConnection"))
);


// Add services to the container.
builder.Services.AddControllersWithViews();


//2.2.2 �bProgram.cs�����U�αҥ�Swagger
builder.Services.AddSwaggerGen();


var app = builder.Build();

//�ҥ�Swagger
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
