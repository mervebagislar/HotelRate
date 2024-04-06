using System.ComponentModel.DataAnnotations;

namespace HotelRate2.Models
{
    public enum Cinsiyet
    {
        Kadın,
        Erkek,
        Diğer
    }
    public class Kullanicilar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string? Ad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string? Soyad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public DateTime? DogumTarihi { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]

        public int Cinsiyet { get; set; }
       
    }
}
