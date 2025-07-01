using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models;

public class Person
{
    public string? PersonId { get; set; }
    public string? FullName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Address { get; set; }
}