using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionUsage.Models;
using DependencyInjectionUsage.Services;

namespace DependencyInjectionUsage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _service;
    private readonly IBookService _serviceExample;
    

   

    public HomeController(ILogger<HomeController> logger, IBookService service,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _service = service;
        //ServiceProvider kullanımı
        _serviceExample = serviceProvider.GetService<IBookService>();
    }

    public IActionResult Index()
    {
        _service.Add();
        _service.Refresh();
        return View();
        
    }

    public IActionResult Privacy()
    {
        _serviceExample.Add();
        _serviceExample.Refresh();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}