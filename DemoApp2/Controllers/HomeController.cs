using DeptEmp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeptEmp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index([FromServices] SiteDbContext site)
    {
        var employee = from emp in site.Employees
                        select new EmpInfo 
                        {
                            EmpId = emp.Id,
                            EmpName = emp.Ename,
                            Sal = emp.Sal,
                            DeptId= emp.DepartmentId

                        };
       if(employee is not null)
       {
            return View(employee.ToList());
       }
       return NotFound();
    }

    public IActionResult Register()
    {
        //throw new NotImplementedException();
        return View(new Employee());
    }
    public IActionResult Delete()
    {
        //throw new NotImplementedException();
        return View();
    }
    public IActionResult Update()
    {
        //throw new NotImplementedException();
        return View();
    }
    public IActionResult AddDept()
    {
        //throw new NotImplementedException();
        return View(new Department());
    }
    
     [HttpPost]
    public IActionResult Register([FromServices] SiteDbContext site, Employee input)
    {
        if(ModelState.IsValid)
        {
            var emp = site.Employees.Find(input.DepartmentId);
            if(emp is null)
            {
                emp = input;
                site.Employees.Add(emp);
            }
          // emp.Employees.Add(new Department());
            site.SaveChanges();
           return RedirectToAction("Index");
        }

        return Register();
        
    }

   [HttpPost]
public IActionResult Delete([FromServices] SiteDbContext site, Employee input)
{
    if (ModelState.IsValid)
    {
        var emp = site.Employees.Find(input.Id);
        if (emp != null)
        {
            emp.Id = input.Id; 
            emp.DepartmentId = input.DepartmentId;

            site.Employees.Remove(emp);
            site.SaveChanges();
        }
    }
    return RedirectToAction("Index");
}

[HttpPost]
public IActionResult Update([FromServices] SiteDbContext site, Employee input)
{
    if (ModelState.IsValid)
    {
        var emp = site.Employees.Find(input.Id);
        if (emp != null)
        {
             
            emp.DepartmentId = input.DepartmentId;
            emp.Ename = input.Ename;
            emp.Sal = input.Sal;
            site.Employees.Update(emp);
            site.SaveChanges();
        }
    }
    return RedirectToAction("Index");
}
 [HttpPost]
    public IActionResult AddDept([FromServices] SiteDbContext site, Department input)
    {
        if(ModelState.IsValid)
        {
            var emp = site.Departments.Find(input.Id);
            if(emp is null)
            {
                emp = input;
                site.Departments.Add(emp);
            }
          // emp.Employees.Add(new Department());
            site.SaveChanges();
           return RedirectToAction("Index");
        }

        return AddDept();
        
    }
   
}