using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ReactApp1.Server.Services
{
    public class SiparisServis
    {
        private readonly string _connectionString;
        private readonly UrunServis _urunServis;
        private readonly MusteriServis _musteriServis;

        public SiparisServis(IConfiguration configuration, UrunServis urunServis, MusteriServis musteriServis)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
            _urunServis = urunServis;
            _musteriServis = musteriServis;
        }

        //************************
        // 1) CREATE - Veri Ekleme
        //************************
        public void Create(Siparis siparis)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                
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

            foreach (var item in siparisler)
            {
                item.Urun = _urunServis.Read(item.UrunId);
                item.Musteri = _musteriServis.Read(item.MusteriId);
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

                string sorgu = "UPDATE Siparis SET MusteriId=@MusteriId, UrunId=@UrunId, Adet=@Adet, ToplamTutar=@ToplamTutar, Durum=@Durum WHERE SiparisId=@SiparisId";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                komut.Parameters.AddWithValue("@UrunId", siparis.UrunId);
                komut.Parameters.AddWithValue("@Adet", siparis.Adet);
                komut.Parameters.AddWithValue("@ToplamTutar", siparis.ToplamTutar);
                komut.Parameters.AddWithValue("@Durum", siparis.Durum);

                komut.Parameters.AddWithValue("@SiparisId", siparis.SiparisId);

                komut.ExecuteNonQuery();
            }
        }
    }
}