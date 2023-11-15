using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using sqlChartsDemo.Models;

namespace sqlChartsDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        CartActivityModel cartActivites = new CartActivityModel();
        cartActivites.Name = "Cart Activity";
        cartActivites.CartAmounts = new int[] { 9857, 23657, 19456, 36456, 64567, 62387, 33780, 43567 };
        cartActivites.TimePeriods = new string[] { "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep" };
        cartActivites.RecoveredCartAmounts = new int[] { 2000, 3200, 1780, 1799 };
        cartActivites.RecoveredTimePeriods = new string[] { "jun", "jul", "aug", "sep" };

        return View(cartActivites);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

