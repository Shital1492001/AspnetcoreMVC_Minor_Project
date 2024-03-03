namespace DeptEmp.Models;

public class Employee
{
    public int Id { get; set; }

    public string Ename{ get; set; }

    public decimal Sal{ get; set; }
    public int DepartmentId{ get; set;}
}
