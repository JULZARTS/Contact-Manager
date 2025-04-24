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
    
    
    public async Task <IActionResult> Edit(int id)
    {
        var contacts = await _contactContext.ContactNums.FirstOrDefaultAsync();
        return View(contacts);
    }
    
    
    [HttpPost]
    public async Task <IActionResult> Edit([Bind("Id, FullName, PhoneNumber, Email, Notes")] Contacts contacts)
    {
        if (ModelState.IsValid)
        {
            _contactContext.ContactNums.Update(contacts);
            await _contactContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(contacts);
    }
    
    
    
    
    
    
    public async Task <IActionResult> Delete(int id)
    {
        var contacts = await _contactContext.ContactNums.FirstOrDefaultAsync();
        return View(contacts);
    }



    
    [HttpPost]
    [ActionName("Delete")]
    public async Task <IActionResult> DeleteConfirmed(int id)
    {
            var willdelete = await _contactContext.ContactNums.FindAsync(id);
            _contactContext.ContactNums.Remove(willdelete);
            await _contactContext.SaveChangesAsync();

            return RedirectToAction("Index");
    }
    
    
    
        
    public IActionResult Create()
    {
        return View();
    }
    
        
    [HttpPost]
    public async Task <IActionResult> Create([Bind("Id, FullName, PhoneNumber, Email, Notes")] Contacts contacts)
    {
        if (ModelState.IsValid)
        {
            _contactContext.ContactNums.Add(contacts);
            await _contactContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
    public async Task<IActionResult> Favorites()
    {
        var contacts = await _contactContext.ContactNums.Where(x => x.IsFavorite == true).ToListAsync();
        return View(contacts);
    }


    [HttpPost]
    public async Task<IActionResult> addToFavorites([Bind("IsFavorites")] Contacts contacts)
    {
        _contactContext.ContactNums.Update(contacts);
        _contactContext.SaveChangesAsync();

        return RedirectToAction("Index");
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