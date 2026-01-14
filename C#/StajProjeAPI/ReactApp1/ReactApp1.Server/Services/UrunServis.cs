using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ReactApp1.Server.Services
{
    public class UrunServis
    {
        // Bağlantı dizesini tutan değişken
        private readonly string _connectionString;

        // Constructor: appsettings.json içindeki bağlantı cümlesini alır
        public UrunServis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }

        //************************************************************
        // 1) CREATE - Veri Ekleme
        //************************************************************

        public void Create(Urun urun)
        {
            // Bağlantı nesnesi oluşturma
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: Yeni ürün ekleme
                string sorgu = "INSERT INTO URUN (Adi, Kodu, Fiyat) VALUES (@Adi, @Kodu, @Fiyat)";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreleri sorguya bağlama
                komut.Parameters.AddWithValue("@Adi", urun.Adi);
                komut.Parameters.AddWithValue("@Kodu", urun.Kodu);
                komut.Parameters.AddWithValue("@Fiyat", urun.Fiyat);

                // Sorguyu çalıştırma (veritabanına kaydetme)
                komut.ExecuteNonQuery();
            }
        }

        //************************************************************
        // 2) READ - Veri Listeleme
        //************************************************************

        public List<Urun> GetUrunler()
        {
            // Ürünleri tutacak liste oluşturma
            List<Urun> urunler = new List<Urun>();

            // Bağlantı nesnesi oluşturma
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: Tüm ürünleri seçme
                string sorgu = "SELECT * FROM URUN";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Sorguyu çalıştırıp okuma nesnesi oluşturma
                SqlDataReader okuyucu = komut.ExecuteReader();

                // Gelen kayıtlar bitene kadar satır satır okuma
                while (okuyucu.Read())
                {
                    // Okunan satırı Urun nesnesine aktarma
                    Urun u = new Urun
                    {
                        UrunId = Convert.ToInt32(okuyucu["UrunId"]),
                        Adi = okuyucu["Adi"].ToString(),
                        Kodu = okuyucu["Kodu"].ToString(),
                        Fiyat = Convert.ToDecimal(okuyucu["Fiyat"])
                    };

                    // Listeye ekleme
                    urunler.Add(u);
                }
            }

            // Listeyi geri döndürme
            return urunler;
        }

        //************************************************************
        // 3) UPDATE - Veri Güncelleme
        //************************************************************

        public void Update(Urun urun)
        {
            // Bağlantı nesnesi oluşturma
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: Seçilen ürünü güncelleme
                string sorgu = "UPDATE URUN SET Adi=@Adi, Kodu=@Kodu, Fiyat=@Fiyat WHERE UrunId=@UrunId";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreleri bağlama
                komut.Parameters.AddWithValue("@Adi", urun.Adi);
                komut.Parameters.AddWithValue("@Kodu", urun.Kodu);
                komut.Parameters.AddWithValue("@Fiyat", urun.Fiyat);
                komut.Parameters.AddWithValue("@UrunId", urun.UrunId);

                // Sorguyu çalıştırma
                komut.ExecuteNonQuery();
            }
        }

        //************************************************************
        // 4) DELETE - Veri Silme
        //************************************************************

        public void Delete(int id)
        {
            // Bağlantı nesnesi oluşturma
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: ID’ye göre ürün silme
                string sorgu = "DELETE FROM URUN WHERE UrunId=@UrunId";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreyi bağlama
                komut.Parameters.AddWithValue("@UrunId", id);

                // Sorguyu çalıştırma
                komut.ExecuteNonQuery();
            }
        }
    }
}
