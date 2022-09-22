using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using VCard.Services.Abstract;

namespace VCard.Controllers
{
    public class VCardsController : Controller
    {
        private readonly IVCardService _vCardService;
        private readonly IQrService _qrService;
        private readonly IClientService _clientService;

        public VCardsController(IVCardService vCardService, IQrService qrService, IClientService clientService)
        {
            _vCardService = vCardService;
            _qrService = qrService;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index(int? count)
        {
            if (count==0||count==null)
            {
                ViewData["count"] = 0;

                return View(await _vCardService.GetAllAsyncByCount(null,50));
            }
            else
            {
                ViewData["count"] = count;
                return View(await _vCardService.GetAllAsyncByCount(null, 50));

            }

        }
        public async Task<IActionResult> Details(int id)
        {
            VCardModel cardModel =await _vCardService.GetAsync(x => x.Id == id);
           
            return View(cardModel);
        }
      
        public async Task<IActionResult> SaveContactsFromUrl()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveContactsFromUrl(string url)
        {
            await  _clientService.GetAllVCardFromUrlAndSaveDB(url);
           
            int num =  int.Parse(url.Substring(url.LastIndexOf('=')+1));

           return RedirectToAction(nameof(Index), new {count=num});
        }
    }
}
