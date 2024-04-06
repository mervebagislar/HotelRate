using System.ComponentModel.DataAnnotations;

namespace HotelRate2.Models
{
    public class Soru
    {
        public int SoruId { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string? Konu { get; set; }
        public string SoruMetni { get; set; }

    }
}
