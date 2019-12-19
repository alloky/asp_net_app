using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_net_web_app.Models;
using ASP_net_web_app.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_net_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext db;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;

            db = context;

            if (db.News.Count() == 0)
            {
                db.News.Add(new NewsViewModel { Header = "I <3 programming", Content = "Some content" });
                db.News.Add(new NewsViewModel { Header = "I <3 programming 2", Content = "Some content" });
                db.News.Add(new NewsViewModel { Header = "I <3 programming 3", Content = "Some content" });
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> IndexAsync()
        {

            return View(model: await db.News.ToListAsync());
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
