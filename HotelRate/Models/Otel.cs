using System.ComponentModel.DataAnnotations;

namespace HotelRate2.Models
{
    public class Otel
    {
        public int OtelId { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string? OtelAdi { get; set; }

        public List<OtelResim> OtelResimleri { get; set; }

        public string resim {  get; set; }




    }
}
