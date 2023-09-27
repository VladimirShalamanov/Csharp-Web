﻿namespace TextSplitterApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using TextSplitterApp.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            var slitTextArray = model.Text
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

            model.SplitText = string.Join(Environment.NewLine, slitTextArray);

            return RedirectToAction("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}