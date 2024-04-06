namespace HotelRate2.Models
{
    public class Anket
    {
        public int AnketId { get; set; }
        public int OtelId { get; set; }

        public virtual Otel Otel { get; set; }
        public virtual ICollection<Cevap> Cevaplar { get; set; }
    }
}
