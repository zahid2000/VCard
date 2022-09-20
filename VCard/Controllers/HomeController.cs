using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VCard.Models;
using VCard.Services.Abstract;

namespace VCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService;
        private readonly IVCardService _vCardService;

     
        public HomeController(ILogger<HomeController> logger, IClientService clientService, IVCardService vCardService)
        {
            _logger = logger;
            _clientService = clientService;
            _vCardService = vCardService;
        }

        public async Task<IActionResult> Index(int count=0)
        {
            //await _clientService.GetAllVCardFromUrlAndSaveDB("https://randomuser.me/api?results=50");

            return count == 0
              ? View(await _vCardService.GetAllAsyncByCount(null, 50))
              : View(await _vCardService.GetAllAsyncByCount(null,count));
           
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