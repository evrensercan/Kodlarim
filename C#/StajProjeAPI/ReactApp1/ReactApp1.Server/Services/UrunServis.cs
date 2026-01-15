using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ReactApp1.Server.Services
{
    public class UrunServis
    {
        private readonly string _connectionString;

        public UrunServis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }

        // 1) CREATE
        public void Create(Urun urun)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO URUN (Adi, Kodu, Fiyat) VALUES (@Adi, @Kodu, @Fiyat)", baglanti);

                komut.Parameters.AddWithValue("@Adi", urun.Adi);
                komut.Parameters.AddWithValue("@Kodu", urun.Kodu);
                komut.Parameters.AddWithValue("@Fiyat", urun.Fiyat);

                komut.ExecuteNonQuery();
            }
        }

        // 2) READ
        public List<Urun> GetUrunler()
        {
            List<Urun> urunler = new List<Urun>();

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM URUN", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Urun u = new Urun
                    {
                        UrunId = Convert.ToInt32(okuyucu["UrunId"]),
                        Adi = okuyucu["Adi"].ToString(),
                        Kodu = okuyucu["Kodu"].ToString(),
                        Fiyat = Convert.ToDecimal(okuyucu["Fiyat"])
                    };
                    urunler.Add(u);
                }
            }
            return urunler;
        }

        // 3) UPDATE
        public void Update(Urun urun)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE URUN SET Adi=@Adi, Kodu=@Kodu, Fiyat=@Fiyat WHERE UrunId=@UrunId", baglanti);

                komut.Parameters.AddWithValue("@Adi", urun.Adi);
                komut.Parameters.AddWithValue("@Kodu", urun.Kodu);
                komut.Parameters.AddWithValue("@Fiyat", urun.Fiyat);
                komut.Parameters.AddWithValue("@UrunId", urun.UrunId);

                komut.ExecuteNonQuery();
            }
        }

        // 4) DELETE
        public void Delete(int id)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM URUN WHERE UrunId=@UrunId", baglanti);

                komut.Parameters.AddWithValue("@UrunId", id);

                komut.ExecuteNonQuery();
            }
        }
    }
}