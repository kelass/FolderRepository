using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TZTest.Models;
using System.IO;
using TZTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TZTest.Models.Dto;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace TZTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    readonly ApplicationDbContext _db;
    public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }
    public IActionResult Home(Guid id)
    {
        var folders = _db.Folders.AsNoTracking()
            .Where(F => F.ParentFolderId == id)
            .ToList();

        ViewBag.FolderName = _db.Folders
            .Where(x => x.Id == id)
            .Select(x => x.Name)
            .FirstOrDefault();
            

        return View(folders);
    }

    public IActionResult Index(Guid id)
    {
        var item = _db.Folders.AsNoTracking().ToList();

        return View(item);
    }

    public IActionResult Privacy()
    {

        ViewBag.Folders = _db.Folders.AsNoTracking()
            .Select(obj => new SelectListItem { Text = obj.Name, Value = obj.Id.ToString()})
            .ToList();

       

        return View();
    }

    [HttpPost]
    public IActionResult Privacy(CreateFolderDto model)
    {
        if (ModelState.IsValid)
        {
            var ParentFolderPath = _db.Folders
                .Where(obj => obj.Id == model.ParentFolderId)
                .Select(obj => obj.Path).FirstOrDefault();





            //Реализация создания папки в папке
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), ParentFolderPath, model.Name);
            Directory.CreateDirectory(folderPath);


            var result = new FolderClass { Id = model.Id, Name = model.Name, ParentFolderId = model.ParentFolderId, Path = folderPath };

            _db.Folders.Add(result);
            _db.SaveChanges();

            

           

            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }


        return View();
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

