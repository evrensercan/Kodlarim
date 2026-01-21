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
    public partial class IadeIslemForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        string secilenHareketID = "0";

        public IadeIslemForm()
        {
            InitializeComponent();
        }

        private void lblBilgi_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void IadeIslemForm_Load(object sender, EventArgs e)
        {
            EmanetListesi();
        }

        void EmanetListesi()
        {
            baglanti.Open();

            
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

            //------------CezaHesaplama------------------
            DateTime alisTarihi = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["AlisTarihi"].Value);

            DateTime bugun = DateTime.Now;

            TimeSpan fark = bugun - alisTarihi;
            int gunSayisi = fark.Days;

            // 15 günü geçtiyse, gün başına 5 TL ceza
            decimal cezaTutari = 0;
            if (gunSayisi > 15)
            {
                int gecikenGun = gunSayisi - 15;
                cezaTutari = gecikenGun * 5.0m;

                DialogResult cezaOnay = MessageBox.Show("Kitap " + gecikenGun + " gün gecikmiş!\n\n"
                    + "Tahsil Edilecek Ceza: " + cezaTutari.ToString("C2")
                    + "\n\nCezayı tahsil ettiniz mi? İşleme devam edilsin mi?",
                    "Gecikme Cezası", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (cezaOnay == DialogResult.No)
                {
                    return; // Tahsil etmediyse işlemi iptal et
                }
            }
            // -------------------------------------------

            baglanti.Open();

            // 1. ADIM: HAREKETİ KAPAT (İade Tarihini Gir)
            SqlCommand komutHareket = new SqlCommand("UPDATE TBL_HAREKET SET IadeTarihi = @p1 WHERE HareketID = @p2", baglanti);
            komutHareket.Parameters.AddWithValue("@p1", DateTime.Now); // Şu anki tarih/saat
            komutHareket.Parameters.AddWithValue("@p2", secilenHareketID);
            komutHareket.ExecuteNonQuery();

            // 2. ADIM: KİTABI RAFA KOY (Durumunu True Yap)
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

        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}