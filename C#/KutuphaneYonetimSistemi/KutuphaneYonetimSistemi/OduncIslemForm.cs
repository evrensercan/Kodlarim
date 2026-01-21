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
    public partial class OduncIslemForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");

        string secilenUyeID = "0";
        string secilenKitapID = "0";

        public OduncIslemForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void lblSecilenUye_Click(object sender, EventArgs e) { }
        private void lblSecilenKitap_Click(object sender, EventArgs e) { }

        // Üye Listesinden seçim yapınca çalışan kod
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            // 1. ID'yi hafızaya al (Arka plan için)
            secilenUyeID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            // 2. İsmi ekrana yaz (Kullanıcı için)
            string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            lblSecilenUye.Text = ad + " " + soyad;
        }

        // Kitap Listesinden seçim yapınca çalışan kod
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            // 1. ID'yi hafızaya al
            secilenKitapID = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

            // 2. Kitap Adını ekrana yaz
            lblSecilenKitap.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnOdunc_Click(object sender, EventArgs e)
        {
            // GÜVENLİK KONTROLÜ
            if (secilenUyeID == "0" || secilenKitapID == "0")
            {
                MessageBox.Show("Lütfen hem üyeyi hem de kitabı seçiniz!");
                return;
            }

            baglanti.Open();

            // 1. HAREKET EKLEME (Kayıt Oluştur)
            SqlCommand komutHareket = new SqlCommand("INSERT INTO TBL_HAREKET (KitapID, UyeID, AlisTarihi) VALUES (@k1, @u1, @t1)", baglanti);
            komutHareket.Parameters.AddWithValue("@k1", secilenKitapID);
            komutHareket.Parameters.AddWithValue("@u1", secilenUyeID);
            komutHareket.Parameters.AddWithValue("@t1", dtpTarih.Value); // Seçilen tarih
            komutHareket.ExecuteNonQuery();

            // 2. KİTAP DURUMUNU GÜNCELLEME (Raftan İndir)
            SqlCommand komutKitap = new SqlCommand("UPDATE TBL_KİTAP SET Durum = 0 WHERE KitapID = @k2", baglanti);
            komutKitap.Parameters.AddWithValue("@k2", secilenKitapID);
            komutKitap.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kitap başarıyla ödünç verildi!");

            // TEMİZLİK VE YENİLEME
            lblSecilenUye.Text = "...";
            lblSecilenKitap.Text = "...";
            secilenKitapID = "0";
            secilenUyeID = "0";
            KitapListele();
        }

        // 1. Üyeleri Getir
        void UyeListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT UyeID, UyeAd, UyeSoyad, UyeTelNo FROM TBL_UYE", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // 2. SADECE Raftaki (Müsait) Kitapları Getir
        void KitapListele()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT KitapID, KitapAdi, KitapYazari, KitapTürü, KitapSayfaSayisi FROM TBL_KİTAP WHERE Durum = 1", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void OduncIslemForm_Load(object sender, EventArgs e)
        {
            UyeListele();  
            KitapListele(); 
        }

        private void txtUyeAra_TextChanged(object sender, EventArgs e)
        {
            string sorgu = "SELECT UyeID, UyeAd, UyeSoyad, UyeTelNo FROM TBL_UYE WHERE UyeAd LIKE '%" + txtUyeAra.Text + "%' OR UyeSoyad LIKE '%" + txtUyeAra.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtKitapAra_TextChanged(object sender, EventArgs e)
        {
            
            string sorgu = "SELECT KitapID, KitapAdi, KitapYazari, KitapTürü, KitapSayfaSayisi FROM TBL_KİTAP WHERE Durum = 1 AND KitapAdi LIKE '%" + txtKitapAra.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
    }
}