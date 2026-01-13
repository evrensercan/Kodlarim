using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ReactApp1.Server.Services
{
    public class UrunServis
    {
        // Veritabanı bağlantı dizesi
        private readonly string _connectionString;

        // Yapıcı metod
        public UrunServis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }


        public void  Create(Urun urun)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı aç
                baglanti.Open();

                //SQL Sorgusu:
                string sorgu = "INSERT INTO URUN (Adi, Kodu, Fiyat) VALUES (@Adi, @Kodu, @Fiyat)";

                // SqlCommand nesnesi oluştur
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreleri ekle
                komut.Parameters.AddWithValue("@Adi", urun.Adi);
                komut.Parameters.AddWithValue("@Kodu", urun.Kodu);
                komut.Parameters.AddWithValue("@Fiyat", urun.Fiyat);

                // Veritabanına Kaydet
                komut.ExecuteNonQuery(); 
            }
        }
    }
}
