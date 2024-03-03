namespace DeptEmp.Models;

public readonly record struct EmpInfo(int EmpId, string EmpName,decimal Sal, string DeptName, int DeptId);
