namespace ReactApp1.Server.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Durum { get; set; }
    }
}
