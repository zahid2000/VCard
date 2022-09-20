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

        public VCardsController(IVCardService vCardService, IQrService qrService)
        {
            _vCardService = vCardService;
            _qrService = qrService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            VCardModel cardModel =await _vCardService.GetAsync(x => x.Id == id);
           
            return View(cardModel);
        }
    }
}
