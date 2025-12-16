using HotelRate2.Models.ViewModels;
using HotelRate2.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelRate2.Controllers
{
    public class IstatistikController : Controller
    {
        private readonly IIstatistikService _istatistikService;

        public IstatistikController(IIstatistikService istatistikService)
        {
            _istatistikService = istatistikService;
        }

        public IActionResult Index()
        {
            var istatistikler = _istatistikService.TumOtelIstatistikleriniGetir();
            return View(istatistikler);
        }
    }
}
