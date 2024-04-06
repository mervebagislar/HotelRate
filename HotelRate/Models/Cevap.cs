namespace HotelRate2.Models
{
    //public enum CevapSikki 
    //{
    //    Mükemmel,
    //    İyi,
    //    Orta,
    //    Yetersiz,
    //    Kötü

    //}
    public class Cevap
    {
        public int CevapId { get; set; }

        //public int CevapSıkki { get; set; }
        public string Cevabi { get; set; }

        public int KullanicilarId { get; set; }

        public Kullanicilar kullanicilar { get; set; }
        public int OtelId { get; set; }
        public Otel Otel { get; set; }

        public int SoruId { get; set; }
        public Soru Soru { get; set; }

        public Cevap(int soruId,string cevabi)
        {
            Cevabi = cevabi;
            SoruId = soruId;
        }
    }
}
