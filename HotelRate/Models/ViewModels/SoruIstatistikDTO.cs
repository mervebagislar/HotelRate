namespace HotelRate2.Models.ViewModels
{
    public class SoruIstatistikDTO
    {
        public int SoruId { get; set; }
        public string SoruKonu { get; set; } = string.Empty;
        public string SoruMetni { get; set; } = string.Empty;
        public double OrtalamaPuan { get; set; }
        public int CevapSayisi { get; set; }
        public CevapDagilimDTO CevapDagilimi { get; set; } = new CevapDagilimDTO();
    }
}

