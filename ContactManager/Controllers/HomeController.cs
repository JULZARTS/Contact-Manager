using System.Diagnostics;
using ContactManager.Data;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers;

public class HomeController : Controller
{
    private readonly ContactContext _contactContext;

    public HomeController(ContactContext contactContext)
    {
        _contactContext = contactContext;
    }

    public async Task <IActionResult> Index()
    {
        var contacts = await _contactContext.ContactNums.ToListAsync();
        return View(contacts);
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