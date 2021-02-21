using BC_IS413_Assignment6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAmazonBooksRepository _repository;

        public HomeController(ILogger<HomeController> logger, IAmazonBooksRepository repository)
        {
            _logger = logger;
            _repository = repository; //Setting the IAmazonBooksRepository to the private attribute to send to Index
        }

        public IActionResult Index()
        {
            return View(_repository.Books); //Passing the Books objects to Index view, ("Index", _repository.Books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
