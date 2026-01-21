using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KutuphaneYonetimSistemi
{
    public partial class KitapYonetimForm: Form
    {

        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        string secilenKitapID = "0"; //Seçilen kitabın kimlik numarası


        public KitapYonetimForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        
        //Ekle
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sorgu = new SqlCommand("INSERT INTO TBL_KİTAP(KitapAdi,KitapYazari,KitapYayınevi,KitapTürü,KitapSayfaSayisi,KitapFiyati) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);

            sorgu.Parameters.AddWithValue("@p1", textAd.Text);
            sorgu.Parameters.AddWithValue("@p2", textYazar.Text);
            sorgu.Parameters.AddWithValue("@p3", textYayinevi.Text);
            sorgu.Parameters.AddWithValue("@p4", cmbTur.Text);
            sorgu.Parameters.AddWithValue("@p5", int.Parse(textSayfa.Text));
            sorgu.Parameters.AddWithValue("@p6", decimal.Parse(textFiyat.Text));

            sorgu.ExecuteNonQuery(); // Gönder
            baglanti.Close();
            MessageBox.Show("Kitap Veri Tabanına Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }


        //Listele
        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlDataAdapter Listele = new SqlDataAdapter("Select * from TBL_KİTAP", baglanti);

            DataTable sanalTablo = new DataTable();

            Listele.Fill(sanalTablo); //Tüm Listeyi sanalTablo ya boşalt

            dataGridView1.DataSource = sanalTablo;

            dataGridView1.Columns[0].Visible = false; // Kitapİd gizle

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Sütunları Ekrana Sığdır
        }

        //Veritabanı Seçim
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanan satırın numarasını (Index) alıyoruz
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            // O satırdaki 0. hücreyi (yani gizli KitapID'yi) hafızaya atıyoruz
            secilenKitapID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            // Tıklayınca kutulara da bilgiler dolsun
            textAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textYazar.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textYayinevi.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            cmbTur.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textSayfa.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textFiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        //Temizle
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textAd.Clear();
            textYazar.Clear();
            textYayinevi.Clear();
            cmbTur.SelectedIndex = -1;
            textSayfa.Clear();
            textFiyat.Clear();
            textAd.Focus(); //İmleci Yukarı Taşır
        }

        //Sil
        private void btnSil_Click(object sender, EventArgs e)
        {
            if ( secilenKitapID == "0")
            {
                MessageBox.Show("Lütfen Silinecek Kitabı Listeden Seçin!");
                return; //İşlemi Durdur
            }
            DialogResult karar = MessageBox.Show(textAd.Text + " kitabını silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (karar == DialogResult.Yes)
            {
                baglanti.Open();

                SqlCommand sorgu = new SqlCommand("UPDATE TBL_KİTAP SET Durum = 0 WHERE KitapID = @k1", baglanti);
                sorgu.Parameters.AddWithValue("@k1", secilenKitapID);
                sorgu.ExecuteNonQuery(); 

                baglanti.Close();

                MessageBox.Show("Seçtiğin "+textAd.Text +" Kitabı Silindi!");
                secilenKitapID = "0";
                MessageBox.Show("Güncel Tabloyu Görmek İçin Listelemeyi Unutma");

            }
        }

        // Güncelle
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("UPDATE TBL_KİTAP SET KitapAdi=@p1, KitapYazari=@p2, KitapYayınevi=@p3, KitapTürü=@p4, KitapSayfaSayisi=@p5, KitapFiyati=@p6 WHERE KitapID=@k1", baglanti);

            sorgu.Parameters.AddWithValue("@p1", textAd.Text);
            sorgu.Parameters.AddWithValue("@p2", textYazar.Text);
            sorgu.Parameters.AddWithValue("@p3", textYayinevi.Text);
            sorgu.Parameters.AddWithValue("@p4", cmbTur.Text);
            sorgu.Parameters.AddWithValue("@p5", int.Parse(textSayfa.Text));
            sorgu.Parameters.AddWithValue("@p6", decimal.Parse(textFiyat.Text));
            sorgu.Parameters.AddWithValue("@k1", secilenKitapID);

            sorgu.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnListele.PerformClick();
            MessageBox.Show("Güncel Tabloyu Görmek İçin Listelemeyi Unutma");

        }

        private void btnGoHome_Click(object sender, EventArgs e)
        {
            AnaSayfaForm anaSayfa = new AnaSayfaForm();

            this.Hide(); //Mevcut Pencereyi Gizle
            anaSayfa.ShowDialog(); 
            




        }
    }
}
