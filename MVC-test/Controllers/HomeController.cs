using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MVC_test.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System;

namespace MVC_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Models.HomeControllerModel model = new Models.HomeControllerModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            model.testToWrite = DateTime.Now + " - " +  Environment.MachineName.ToString();

            //var dataFile = Server.MapPath("~/App_Data/Category.txt");
           
            StreamWriter writer = new StreamWriter("Category.txt", true);
            writer.WriteLine(model.testToWrite);
            writer.Close();
            return View(model);
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
}