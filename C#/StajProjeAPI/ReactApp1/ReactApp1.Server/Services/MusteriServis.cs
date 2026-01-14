using Microsoft.Data.SqlClient;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services
{
    public class MusteriServis
    {
        // 1. Bağlantı Cümlesi Değişkeni (UrunServis ile aynısı)
        private readonly string _connectionString;


        // 2. Constructor (Yapıcı Metot) - (UrunServis ile aynısı)
        public MusteriServis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaglantiCumlesi");
        }


        //***********************************************************************************
        // CREATE - Veri Ekleme
        //***********************************************************************************

        public void Create(Musteri musteri)
        {
            
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Baglantıyı Aç:
                baglanti.Open();

                // SQL Sorgusu:
                string sorgu = "INSERT INTO MUSTERİ (ADSoyad, Adres, TelNo, Mail) VALUES (@ADSoyad, @Adres, @TelNo, @Mail)";

                // SQLCommad Nesnesi Oluştur
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                
                komut.Parameters.AddWithValue("@AdSoyad", musteri.AdSoyad);
                komut.Parameters.AddWithValue("@Adres", musteri.Adres);
                komut.Parameters.AddWithValue("@TelNo", musteri.TelNo); 
                komut.Parameters.AddWithValue("@Mail", musteri.Mail); 

                // Çalıştırma komutu (Aynı)
                komut.ExecuteNonQuery();
            }
        }

        //***********************************************************************************
        // READ - Get - Veri Listeleme
        //***********************************************************************************

        public List<Musteri> GetMusteriler()
        {
            List<Musteri> musteriler = new List<Musteri>();

            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM MUSTERİ";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    Musteri u = new Musteri
                    {
                        MusteriId = Convert.ToInt32(okuyucu["MusteriId"]),
                        AdSoyad = okuyucu["AdSoyad"].ToString(),
                        Adres = okuyucu["Adres"].ToString(),
                        TelNo = okuyucu["TelNo"].ToString(),
                        Mail = okuyucu["Mail"].ToString(),
                    };

                    musteriler.Add(u);
                }
            };

            return musteriler;
        }

        //************************************************************
        // 3) UPDATE - Veri Güncelleme 
        //************************************************************

        public void Update(Musteri musteri)
        {
            using (SqlConnection baglanti = new SqlConnection(_connectionString))
            {
                // Bağlantıyı açma
                baglanti.Open();

                // SQL Sorgusu: Seçilen ürünü güncelleme
                string sorgu = "UPDATE Musteri SET AdSoyad=@AdSoyad, Adres=@Adres, TelNo=@TelNo, Mail=@Mail WHERE MusteriId=@MusteriId";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreleri bağlama
                komut.Parameters.AddWithValue("@AdSoyad", musteri.AdSoyad);
                komut.Parameters.AddWithValue("@Adres", musteri.Adres);
                komut.Parameters.AddWithValue("@TelNo", musteri.TelNo);
                komut.Parameters.AddWithValue("@Mail", musteri.Mail);
                komut.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);


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
                string sorgu = "DELETE FROM MUSTERİ WHERE MusteriId=@MusteriId";

                // SqlCommand nesnesi oluşturma
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Parametreyi bağlama
                komut.Parameters.AddWithValue("@MusteriId", id);

                // Sorguyu çalıştırma
                komut.ExecuteNonQuery();
            }
        }

    }
}
