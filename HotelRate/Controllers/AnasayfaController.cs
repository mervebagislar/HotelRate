using HotelRate2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelRate2.Controllers
{
    public class AnasayfaController : Controller
    {

        private readonly HotelDbContext _context;
        public AnasayfaController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            int? KullaniciId = HttpContext.Session.GetInt32("KullaniciId");

            var otel = _context.Oteller.ToList();
            return View(otel);
        }



    }
}
