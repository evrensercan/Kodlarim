using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimSistemi
{
    public partial class IadeIslemForm: Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        string secilenHareketID = "0";
        public IadeIslemForm()
        {
            InitializeComponent();
        }

        private void lblBilgi_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IadeIslemForm_Load(object sender, EventArgs e)
        {
            EmanetListesi();
        }
        void EmanetListesi()
        {
            baglanti.Open();

            // İşte o meşhur JOIN sorgusu.
            // Türkçesi: Hareket tablosunu al, Üye ve Kitap tablolarıyla birleştir.
            // Şart: IadeTarihi NULL olanları (yani henüz geri gelmeyenleri) getir.
            string sorgu = "SELECT HareketID, UyeAd + ' ' + UyeSoyad AS 'Üye', KitapAdi AS 'Kitap', AlisTarihi " +
                           "FROM TBL_HAREKET " +
                           "INNER JOIN TBL_UYE ON TBL_HAREKET.UyeID = TBL_UYE.UyeID " +
                           "INNER JOIN TBL_KİTAP ON TBL_HAREKET.KitapID = TBL_KİTAP.KitapID " +
                           "WHERE IadeTarihi IS NULL";

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan satırı bul
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            // 1. Hareket ID'sini (İşlem Numarasını) hafızaya al
            secilenHareketID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            // 2. lblBilgi'ye "Üye Adı - Kitap Adı" yazdır
            // SQL sorgumuzda 1. sütun 'Üye', 2. sütun 'Kitap' idi.
            string uyeAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string kitapAd = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            lblBilgi.Text = uyeAd + " - " + kitapAd;
        }

        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            if (secilenHareketID == "0")
            {
                MessageBox.Show("Lütfen listeden iade edilecek işlemi seçin!");
                return;
            }

            baglanti.Open();

            // 1. ADIM: HAREKETİ KAPAT (İade Tarihini Gir)
            SqlCommand komutHareket = new SqlCommand("UPDATE TBL_HAREKET SET IadeTarihi = @p1 WHERE HareketID = @p2", baglanti);
            komutHareket.Parameters.AddWithValue("@p1", DateTime.Now); // Şu anki tarih/saat
            komutHareket.Parameters.AddWithValue("@p2", secilenHareketID);
            komutHareket.ExecuteNonQuery();

            // 2. ADIM: KİTABI RAFA KOY (Durumunu True Yap)
            // Burası biraz pratik zeka: HareketID'den KitapID'yi bulup güncelliyoruz.
            // "Bu hareketin içindeki kitabı bul ve durumunu 1 yap" diyoruz.
            SqlCommand komutKitap = new SqlCommand("UPDATE TBL_KİTAP SET Durum = 1 WHERE KitapID = (SELECT KitapID FROM TBL_HAREKET WHERE HareketID = @p3)", baglanti);
            komutKitap.Parameters.AddWithValue("@p3", secilenHareketID);
            komutKitap.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kitap iade alındı ve rafa kaldırıldı!");

            // TEMİZLİK
            EmanetListesi(); // Listeyi yenile (İade edilen listeden düşmeli!)
            lblBilgi.Text = "...";
            secilenHareketID = "0";
        }
    }
}
