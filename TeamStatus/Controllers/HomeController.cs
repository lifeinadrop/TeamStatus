using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TeamStatus.Hubs;
using TeamStatus.Models;
using TeamStatus.Services;
using TeamStatusData.Data;
using TeamStatusData.Enums;
using TeamStatusData.Models;

namespace TeamStatus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataService _dataService;
    private readonly StatusUpdateService _statusUpdateService;

    public HomeController(ILogger<HomeController> logger, DataContext dataContext, StatusUpdateService statusUpdateService)
    {
        _logger = logger;
        _dataService = new DataService(dataContext);
        _statusUpdateService = statusUpdateService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        var users = _dataService.GetUsers();
        return View(users);
    }
    
    [HttpPost("dashboard/{userId:long}/update-status")]
    public async Task<IActionResult> UpdateUserStatus(long userId, UserStatus userStatus)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Dashboard));
        }
        
        await _statusUpdateService.UpdateUserStatus(userId, userStatus);
	    
        return RedirectToAction(nameof(Dashboard));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}