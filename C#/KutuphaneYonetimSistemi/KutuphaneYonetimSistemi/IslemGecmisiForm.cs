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
    public partial class IslemGecmisiForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");

        public IslemGecmisiForm()
        {
            InitializeComponent();
        }

        private void IslemGecmisiForm_Load(object sender, EventArgs e)
        {
            cmbFiltre.Items.Clear();
            cmbFiltre.Items.Add("Tüm İşlemler");
            cmbFiltre.Items.Add("İade Edilenler (Yeşil)");
            cmbFiltre.Items.Add("Teslim Bekleyenler (Kırmızı)");

            cmbFiltre.SelectedIndex = 0;

            FiltreliListele();
        }

        // AKILLI FİLTRELEME MOTORU
        void FiltreliListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                // 1. Temel Sorgu (Her şeyi getiren iskelet)
                // "WHERE 1=1" taktiği: Dinamik olarak "AND" ekleyebilmek için koyuyoruz.
                //* Buradaki "WHERE 1=1" bir yazılımcı hilesidir. 1, 1'e her zaman eşittir.
                //* Bunu koyuyoruz ki aşağıda "AND ..." diye ekleme yaparken "Acaba WHERE yazdım mı?" diye düşünmeyelim.
                //* Bu sayede sorgu "WHERE 1=1 AND UyeAd..." şeklinde düzgünce devam eder.
                string sorgu = "SELECT HareketID, UyeAd + ' ' + UyeSoyad AS 'Üye', KitapAdi AS 'Kitap', AlisTarihi, IadeTarihi " +
                               "FROM TBL_HAREKET " +
                               "INNER JOIN TBL_UYE ON TBL_HAREKET.UyeID = TBL_UYE.UyeID " +
                               "INNER JOIN TBL_KİTAP ON TBL_HAREKET.KitapID = TBL_KİTAP.KitapID " +
                               "WHERE 1=1 ";

                // 2. İsim Filtresi (TextBox doluysa sorguya ekle)
                if (!string.IsNullOrEmpty(txtIslemAra.Text))
                {
                    sorgu += " AND (UyeAd LIKE '%" + txtIslemAra.Text + "%' OR KitapAdi LIKE '%" + txtIslemAra.Text + "%')";
                }

                // 3. Durum Filtresi (ComboBox seçimine göre ekle)
                if (cmbFiltre.SelectedIndex == 1) // "İade Edilenler"
                {
                    sorgu += " AND IadeTarihi IS NOT NULL";
                }
                else if (cmbFiltre.SelectedIndex == 2) // "Teslim Bekleyenler"
                {
                    sorgu += " AND IadeTarihi IS NULL";
                }

                // 4. Sıralama (En yeni işlem en üstte görünsün)
                sorgu += " ORDER BY HareketID DESC";

                // 5. Verileri Çek ve Doldur
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        // TextBox'a her harf yazıldığında çalışır
        private void txtIslemAra_TextChanged(object sender, EventArgs e)
        {
            FiltreliListele();
        }
         
        // ComboBox seçimi değiştiğinde çalışır
        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreliListele();
        }

        // Tablo dolduktan sonra satırları boyayan kod
        //* DataBindingComplete: Tabloya veriler dolduktan hemen sonra çalışan olaydır.
        //* Burada tek tek satırları gezip boyama yapıyoruz.
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                // Eğer İade Tarihi boş değilse (Kitap geri gelmişse)
                if (satir.Cells["IadeTarihi"].Value != DBNull.Value)
                {
                    satir.DefaultCellStyle.BackColor = Color.LightGreen; // Yeşil
                    satir.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else // Kitap gelmemişse
                {
                    satir.DefaultCellStyle.BackColor = Color.Salmon; // Kırmızı
                    satir.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                }
            }
        }
    }
}