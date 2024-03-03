using DemoApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //enable ASP.NET Core MVC
builder.Services.AddSingleton<ICounter, CommonCounter>();
var app = builder.Build();
app.MapGet("/", () => "Hello World!!!");
//map path /X/Y to XController::Y(...) method 
//with X=Home and Y=Index by default
app.MapDefaultControllerRoute();
app.Run();
