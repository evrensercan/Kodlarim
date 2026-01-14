using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using Microsoft.Extensions.Configuration;

namespace ReactApp1.Server.Services
{
    public class SiparisServis
    {
        private readonly string _connectionString;

        public SiparisServis(IConfiguration configuration)
        {
            
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }

        //************************
        //* CREATE - Veri Ekleme *
        //************************
        public void Create(Siparis siparis)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();

                string sorgu = "INSERT INTO Siparis (MusteriId, UrunId, Adet, ToplamTutar, Durum) VALUES (@MusteriId, @UrunId, @Adet, @ToplamTutar, @Durum)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                komut.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                komut.Parameters.AddWithValue("@Adet", siparis.Adet);
                komut.Parameters.AddWithValue("@ToplamTutar", siparis.ToplamTutar);
                komut.Parameters.AddWithValue("@Durum", siparis.Durum);

                komut.ExecuteNonQuery();
            }
        }

        //***********************
        //* DELETE - Veri Silme *
        //***********************
        public void Delete(int id)
        {
            using (SqlConnection baglanti = new SqlConnection (_connectionString))
            {
                baglanti.Open();

                string sorgu = "DELETE FROM SİPARİS WHERE SiparisId=@SiparisId";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@SiparisId", id);

                komut.ExecuteNonQuery();
            }
        }

        //*************************
        //* READ - Veri Listeleme *
        //*************************

        public List<Siparis> GetSiparisler()
        {
            List<Siparis> siparisler = new List<Siparis>();

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM SİPARİS";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Siparis u = new Siparis
                    {
                        SiparisId = Convert.ToInt32(okuyucu["SiparisId"]),
                        MusteriId = Convert.ToInt32(okuyucu["MusteriId"]),
                        UrunId = Convert.ToInt32(okuyucu["UrunId"]),
                        Adet = Convert.ToInt32(okuyucu["Adet"]),
                        ToplamTutar = Convert.ToDecimal(okuyucu["ToplamTutar"]),
                        Durum = okuyucu["Durum"].ToString(),
                    };

                    siparisler.Add(u);
                }
            };

            return siparisler;
        }

        //****************************
        //* UPDATE - Veri Güncelleme *
        //****************************
        public void Update(Siparis siparis)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: Seçilen ürünü güncelleme
                string sorgu = "UPDATE SİPARİS SET MusteriId=@MusteriId, UrunId=@UrunId, Adet=@Adet, ToplamTutar=@ToplamTutar, Durum=@Durum";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreleri bağlama
                komut.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                komut.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                komut.Parameters.AddWithValue("@Adet", siparis.Adet);
                komut.Parameters.AddWithValue("@ToplamTutar", siparis.ToplamTutar);
                komut.Parameters.AddWithValue("@Durum", siparis.Durum);

                // Sorguyu çalıştırma
                komut.ExecuteNonQuery();
            }
        }

    }

}