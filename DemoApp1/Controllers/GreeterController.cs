using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers;

public class GreeterController : Controller
{
    public IActionResult Greet([FromServices] ICounter ctr, string id = "Visitor")
    {
        int n = ctr.CountNext(id);
        var guest = new 
        {
            VisitorName = id,
            VisitTime = DateTime.Now
        };
        if((n % 2) == 1)
            return View("~/Views/Welcome.cshtml", guest);
        return View("~/Views/Hello.cshtml", guest);
    }
}