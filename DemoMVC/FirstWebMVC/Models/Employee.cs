using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models;

public class Employee : Person
{
    public string? EmployeeId { get; set; }
    [DataType(DataType.Date)]
    public int Age { get; set; }
}