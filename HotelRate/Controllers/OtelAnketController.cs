using HotelRate2.Migrations;
using HotelRate2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Net.WebSockets;


namespace HotelRate2.Controllers
{
    public class OtelAnketController : Controller
    {
        private readonly HotelDbContext _context;
        public OtelAnketController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult HotelDetay(int? id)
        {
            var otel = _context.Oteller.Include(x => x.OtelResimleri).FirstOrDefault(a => a.OtelId == id);
            var sorular = _context.Sorular.ToList();

            int? userId = HttpContext.Session.GetInt32("KullaniciId");

            ViewBag.SelectedHotelId = otel.OtelId;

            var tupplecreate = Tuple.Create<Otel, List<Soru>>(otel, sorular);


            return View(tupplecreate);

        }
        
        [HttpPost]
        public IActionResult HotelDetay(FormCollection form)
        {
            var routes = Request.RouteValues;

            int selectedHotelId = int.Parse(routes["id"].ToString());

            int? KullaniciId = HttpContext.Session.GetInt32("KullaniciId");

            foreach (var key in form.Keys) 
            {
                if (key.StartsWith("SoruId_"))
                {
                    int soruId = int.Parse(key.Substring(7));
                    string cevap = form[key];

                    var cevapModel = new Cevap(soruId, cevap)
                    {
                        OtelId = selectedHotelId,
                        KullanicilarId = KullaniciId ?? 0,
                        
                    };

                    _context.Cevaplar.Add(cevapModel);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Kontrol", "Check", new { id = selectedHotelId });

        }
    }
}
