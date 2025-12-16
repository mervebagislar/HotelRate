namespace HotelRate2.Models.ViewModels
{
    public class OtelIstatistikViewModel
    {
        public int OtelId { get; set; }
        public string OtelAdi { get; set; } = string.Empty;
        public int ToplamCevapSayisi { get; set; }
        public double GenelOrtalamaPuan { get; set; }
        public List<SoruIstatistikDTO> SoruIstatistikleri { get; set; } = new List<SoruIstatistikDTO>();
    }
}

