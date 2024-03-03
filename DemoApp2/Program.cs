using DeptEmp.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DeptEmp.Models.SiteDbContext>();
var app = builder.Build();
app.MapDefaultControllerRoute();
app.Run();
