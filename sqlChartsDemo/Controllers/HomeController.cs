using System.Diagnostics;
using chartsDemo.SqlConn;
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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public string Test()
    {
        OracleConnection conn = DBUtils.GetDBConnection();

        Console.WriteLine("Get Connection: " + conn);
        try
        {
            conn.Open();

            Console.WriteLine(conn.ConnectionString, "Successful Connection");
            return "connection: " + conn.ConnectionString;
        }
        catch (Exception ex)
        {
            Console.WriteLine("## ERROR: " + ex.Message);
            Console.Read();
            return "ERROR:" + ex.Message;
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

