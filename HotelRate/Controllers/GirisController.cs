using HotelRate2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace HotelRate2.Controllers
{
    public class GirisController : Controller
    {
        private readonly HotelDbContext _context;

        public GirisController(HotelDbContext context)
        {
            _context=context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Index(Kullanicilar model)
        {
            try
            {
                _context.Kullanicilar.Add(model);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("KullaniciId", model.Id);
                TempData["kid"] = model.Id;

            }
            catch (Exception ex)
            {
                ex = ex;
            }
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
