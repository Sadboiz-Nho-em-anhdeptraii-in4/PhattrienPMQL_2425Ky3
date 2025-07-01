using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models;

class Employee : Person
{
    public string? EmployeeId { get; set; }
    [DataType(DataType.Date)]
    public int Age { get; set; }
}