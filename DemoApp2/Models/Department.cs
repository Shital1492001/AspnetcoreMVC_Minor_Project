namespace DeptEmp.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
[Table("R71_Department")]
public class Department
{
    [Column("deptno")]
    public int Id { get; set; }
    public string dname { get; set; }
    public string dloc{ get; set; }
    public List<Employee> Employees { get; set; } =new();
    


}
