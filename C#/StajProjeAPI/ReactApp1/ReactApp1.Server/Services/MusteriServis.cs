using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;
using Microsoft.Extensions.Configuration;

namespace ReactApp1.Server.Services
{
    public class MusteriServis
    {
        private readonly string _connectionString;

        public MusteriServis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }

        // 1) CREATE
        public void Create(Musteri musteri)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                
                SqlCommand komut = new SqlCommand("INSERT INTO MUSTERİ (AdSoyad, Adres, TelNo, Mail) VALUES (@AdSoyad, @Adres, @TelNo, @Mail)", baglanti);

                komut.Parameters.AddWithValue("@AdSoyad", musteri.AdSoyad);
                komut.Parameters.AddWithValue("@Adres", musteri.Adres);
                komut.Parameters.AddWithValue("@TelNo", musteri.TelNo);
                komut.Parameters.AddWithValue("@Mail", musteri.Mail);

                komut.ExecuteNonQuery();
            }
        }

        // 2) READ
        public List<Musteri> GetMusteriler()
        {
            List<Musteri> musteriler = new List<Musteri>();

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM MUSTERİ", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Musteri m = new Musteri
                    {
                        MusteriId = Convert.ToInt32(okuyucu["MusteriId"]),
                        AdSoyad = okuyucu["AdSoyad"].ToString(),
                        Adres = okuyucu["Adres"].ToString(),
                        TelNo = okuyucu["TelNo"].ToString(),
                        Mail = okuyucu["Mail"].ToString(),
                    };
                    musteriler.Add(m);
                }
            }
            return musteriler;
        }

        // 3) UPDATE
        public void Update(Musteri musteri)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE MUSTERİ SET AdSoyad=@AdSoyad, Adres=@Adres, TelNo=@TelNo, Mail=@Mail WHERE MusteriId=@MusteriId", baglanti);

                komut.Parameters.AddWithValue("@AdSoyad", musteri.AdSoyad);
                komut.Parameters.AddWithValue("@Adres", musteri.Adres);
                komut.Parameters.AddWithValue("@TelNo", musteri.TelNo);
                komut.Parameters.AddWithValue("@Mail", musteri.Mail);
                komut.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);

                komut.ExecuteNonQuery();
            }
        }

        // 4) DELETE
        public void Delete(int id)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM MUSTERİ WHERE MusteriId=@MusteriId", baglanti);
                komut.Parameters.AddWithValue("@MusteriId", id);
                komut.ExecuteNonQuery();
            }
        }

        // 5) Id'si girilen Müsterinin Bilgilerini Getirir.
        public Musteri Read(int id)
        {
            Musteri musteri = null; 

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();

               
                string sorgu = "SELECT * FROM Musteri WHERE MusteriId=@id";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", id);

                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.Read()) 
                {
                    musteri = new Musteri();

                    musteri.MusteriId = Convert.ToInt32(okuyucu["MusteriId"]);
                    musteri.AdSoyad = okuyucu["AdSoyad"].ToString();
                    musteri.Adres = okuyucu["Adres"].ToString();
                    musteri.TelNo = okuyucu["TelNo"].ToString();
                    musteri.Mail = okuyucu["Mail"].ToString();


                }
            }
            return musteri;
        }
    }
}