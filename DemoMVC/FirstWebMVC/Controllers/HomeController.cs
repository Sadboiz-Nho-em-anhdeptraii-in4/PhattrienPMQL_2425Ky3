using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
            _logger = logger;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(string FullName, string Address)
        {
            string strOutput = "Xin chao " + FullName + ", dia chi cua ban la: " + Address;
            ViewBag.Output = strOutput;
            return View();
        }
    }