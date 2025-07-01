using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers;
    public class PersonController : Controller
{
    // GET: /Person/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /Person/Details/
    public IActionResult Details()
    {
        Person person = new Person
        {
            PersonId = "2121051322",
            FullName = "Bui Ngoc Anh"
        };
        return View(person);
    }
}