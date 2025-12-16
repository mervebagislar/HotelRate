using HotelRate2.Models;
using HotelRate2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelRate2.Services
{
    public interface IIstatistikService
    {
        List<OtelIstatistikViewModel> TumOtelIstatistikleriniGetir();
        OtelIstatistikViewModel? OtelIstatistikleriniGetir(int otelId);
    }

    public class IstatistikService : IIstatistikService
    {
        private readonly HotelDbContext _context;

        public IstatistikService(HotelDbContext context)
        {
            _context = context;
        }

        public List<OtelIstatistikViewModel> TumOtelIstatistikleriniGetir()
        {
            var oteller = _context.Oteller.ToList();
            var istatistikler = new List<OtelIstatistikViewModel>();

            foreach (var otel in oteller)
            {
                var istatistik = OtelIstatistikleriniGetir(otel.OtelId);
                if (istatistik != null)
                {
                    istatistikler.Add(istatistik);
                }
            }

            return istatistikler;
        }

        public OtelIstatistikViewModel? OtelIstatistikleriniGetir(int otelId)
        {
            var otel = _context.Oteller.FirstOrDefault(o => o.OtelId == otelId);
            if (otel == null)
                return null;

            var cevaplar = _context.Cevaplar
                .Include(c => c.Soru)
                .Where(c => c.OtelId == otelId)
                .ToList();

            if (!cevaplar.Any())
                return new OtelIstatistikViewModel
                {
                    OtelId = otel.OtelId,
                    OtelAdi = otel.OtelAdi ?? string.Empty,
                    ToplamCevapSayisi = 0,
                    GenelOrtalamaPuan = 0
                };

            var soruIstatistikleri = new List<SoruIstatistikDTO>();
            var sorular = _context.Sorular.ToList();

            foreach (var soru in sorular)
            {
                var soruCevaplari = cevaplar.Where(c => c.SoruId == soru.SoruId).ToList();
                
                if (soruCevaplari.Any())
                {
                    var puanlar = soruCevaplari
                        .Select(c => CevapStringToInt(c.Cevabi))
                        .Where(p => p.HasValue)
                        .Select(p => p.Value)
                        .ToList();

                    if (puanlar.Any())
                    {
                        var ortalamaPuan = puanlar.Average();
                        var dagilim = CevapDagiliminiHesapla(soruCevaplari);

                        soruIstatistikleri.Add(new SoruIstatistikDTO
                        {
                            SoruId = soru.SoruId,
                            SoruKonu = soru.Konu ?? string.Empty,
                            SoruMetni = soru.SoruMetni ?? string.Empty,
                            OrtalamaPuan = Math.Round(ortalamaPuan, 2),
                            CevapSayisi = soruCevaplari.Count,
                            CevapDagilimi = dagilim
                        });
                    }
                }
            }

            var tumPuanlar = cevaplar
                .Select(c => CevapStringToInt(c.Cevabi))
                .Where(p => p.HasValue)
                .Select(p => p.Value)
                .ToList();

            var genelOrtalama = tumPuanlar.Any() ? Math.Round(tumPuanlar.Average(), 2) : 0;

            return new OtelIstatistikViewModel
            {
                OtelId = otel.OtelId,
                OtelAdi = otel.OtelAdi ?? string.Empty,
                ToplamCevapSayisi = cevaplar.Count,
                GenelOrtalamaPuan = genelOrtalama,
                SoruIstatistikleri = soruIstatistikleri
            };
        }

        private int? CevapStringToInt(string cevap)
        {
            if (string.IsNullOrWhiteSpace(cevap))
                return null;

            cevap = cevap.Trim();
            
            if (int.TryParse(cevap, out int puan) && puan >= 1 && puan <= 5)
                return puan;

            return null;
        }

        private CevapDagilimDTO CevapDagiliminiHesapla(List<Cevap> cevaplar)
        {
            var dagilim = new CevapDagilimDTO();

            foreach (var cevap in cevaplar)
            {
                var puan = CevapStringToInt(cevap.Cevabi);
                if (puan.HasValue)
                {
                    switch (puan.Value)
                    {
                        case 1:
                            dagilim.BirPuanSayisi++;
                            break;
                        case 2:
                            dagilim.IkiPuanSayisi++;
                            break;
                        case 3:
                            dagilim.UcPuanSayisi++;
                            break;
                        case 4:
                            dagilim.DortPuanSayisi++;
                            break;
                        case 5:
                            dagilim.BesPuanSayisi++;
                            break;
                    }
                }
            }

            return dagilim;
        }
    }
}

