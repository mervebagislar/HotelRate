using HotelRate2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelRate2.Controllers
{
    public class CheckController : Controller
    {

        private readonly HotelDbContext _context;
        public CheckController(HotelDbContext context)
        {
            _context = context;
        }
        public IActionResult Kontrol(int? id)
        {

            if (id == null)
            {

                return NotFound();
            }

            var otel = _context.Oteller.SingleOrDefault(o => o.OtelId == id);

            if (otel == null)
            {

                return NotFound();
            }

            var otelList = new List<Otel> { otel };

            return View("Kontrol", otelList);

        }
    }
        
}
