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

        public async Task<IActionResult> Index(string value)
        {
            //await _clientService.GetAllVCardFromUrlAndSaveDB("https://randomuser.me/api?results=50");

            if (int.TryParse(value, out int count))
            {
                return count == 0
                           ? View(await _vCardService.GetAllAsyncByCount(null, 50))
                           : View(await _vCardService.GetAllAsyncByCount(null, count));
            }
            else
            {
                return value == null
                            ? View(await _vCardService.GetAllAsyncByCount(null, 50))
                            : View(await _vCardService.GetAllAsync(x =>
                            x.FirstName.ToLower().Contains(value) ||
                            x.Surname.ToLower().Contains(value) ||
                            x.Email.ToLower().Contains(value)||
                            x.Phone.ToLower().Contains(value) ||
                            x.Country.ToLower().Contains(value) ||
                            x.City.ToLower().Contains(value) 
                            ));
            }


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