using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
        // 1) CREATE - Veri Ekleme
        //************************
        public void Create(Siparis siparis)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                // Tablo adı 'Siparis' olarak düzeltildi
                SqlCommand komut = new SqlCommand("INSERT INTO Siparis (MusteriId, UrunId, Adet, ToplamTutar, Durum) VALUES(@MusteriId, @UrunId, @Adet, @ToplamTutar, @Durum)", baglanti);

                komut.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                komut.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                komut.Parameters.AddWithValue("@Adet", siparis.Adet);
                komut.Parameters.AddWithValue("@ToplamTutar", siparis.ToplamTutar);
                komut.Parameters.AddWithValue("@Durum", siparis.Durum);

                komut.ExecuteNonQuery();
            }
        }

        //***********************
        // 2) DELETE - Veri Silme
        //***********************
        public void Delete(int id)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                // Tablo adı 'Siparis' olarak düzeltildi
                SqlCommand komut = new SqlCommand("DELETE FROM Siparis WHERE SiparisId=@SiparisId", baglanti);

                komut.Parameters.AddWithValue("@SiparisId", id);

                komut.ExecuteNonQuery();
            }
        }

        //*************************
        // 3) READ - Veri Listeleme
        //*************************
        public List<Siparis> GetSiparisler()
        {
            List<Siparis> siparisler = new List<Siparis>();

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                // Tablo adı 'Siparis' olarak düzeltildi
                SqlCommand komut = new SqlCommand("SELECT * FROM Siparis", baglanti);

                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Siparis s = new Siparis
                    {
                        SiparisId = Convert.ToInt32(okuyucu["SiparisId"]),
                        MusteriId = Convert.ToInt32(okuyucu["MusteriId"]),
                        UrunId = Convert.ToInt32(okuyucu["UrunId"]),
                        Adet = Convert.ToInt32(okuyucu["Adet"]),
                        ToplamTutar = Convert.ToDecimal(okuyucu["ToplamTutar"]),
                        Durum = okuyucu["Durum"].ToString(),
                    };
                    siparisler.Add(s);
                }
            }
            return siparisler;
        }

        //****************************
        // 4) UPDATE - Veri Güncelleme
        //****************************
        public void Update(Siparis siparis)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();

                // KRİTİK DÜZELTME: Tablo adı 'Siparis' yapıldı ve sonuna WHERE şartı eklendi.
                string sorgu = "UPDATE Siparis SET MusteriId=@MusteriId, UrunId=@UrunId, Adet=@Adet, ToplamTutar=@ToplamTutar, Durum=@Durum WHERE SiparisId=@SiparisId";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                komut.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                komut.Parameters.AddWithValue("@Adet", siparis.Adet);
                komut.Parameters.AddWithValue("@ToplamTutar", siparis.ToplamTutar);
                komut.Parameters.AddWithValue("@Durum", siparis.Durum);

                // ID parametresi eklendi (Hangi siparişin güncelleneceğini belirtmek için şart)
                komut.Parameters.AddWithValue("@SiparisId", siparis.SiparisId);

                komut.ExecuteNonQuery();
            }
        }
    }
}