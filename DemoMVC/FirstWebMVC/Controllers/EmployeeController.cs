using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers;

public class EmployeeController : Controller
{
    // GET: /Employee/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /Employee/Details/
    public IActionResult Details()
    {
        Employee employee = new Employee
        {
            EmployeeId = "2121051322",
            FullName = "Bui Ngoc Anh",        
        };
        return View(employee);
    }
}