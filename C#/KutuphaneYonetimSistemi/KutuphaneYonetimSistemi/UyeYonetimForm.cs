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
using static System.Net.Mime.MediaTypeNames;

namespace KutuphaneYonetimSistemi
{
    public partial class UyeYonetimForm: Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        string secilenUyeID = "0";
        public UyeYonetimForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void Temizle()
        {
            textAd.Clear();
            textSoyad.Clear();
            maskedTextBox1.Clear();
            textMail.Clear();
        }
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_UYE", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false; 
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
        
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_UYE (UyeAd, UyeSoyad, UyeTelNo, UyeMail) VALUES (@p1, @p2, @p3, @p4)", baglanti);

            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4", textMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Üye kaydedildi!");
            Temizle();
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            
            secilenUyeID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            
            textAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); // TelNo
            textMail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenUyeID == "0")
            {
                MessageBox.Show("Lütfen listeden silinecek üyeyi seçin!");
                return;
            }

            DialogResult karar = MessageBox.Show(textAd.Text + " adlı üyeyi silmek istiyor musun?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (karar == DialogResult.Yes)
            {
                try
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("DELETE FROM TBL_UYE WHERE UyeID = @p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", secilenUyeID);
                    komut.ExecuteNonQuery();

                    baglanti.Close();

                    MessageBox.Show("Üye Silindi!");
                    Listele();
                    Temizle();
                    secilenUyeID = "0";
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    // Eğer veritabanı "İlişki Hatası" verirse burası çalışır
                    baglanti.Close();
                    MessageBox.Show("BU ÜYE SİLİNEMEZ!\n\nÇünkü bu üyenin kütüphanede işlem geçmişi (aldığı-verdiği kitaplar) var.\n\nVeri kaybını önlemek için sistem silmeye izin vermiyor.", "Güvenlik Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (secilenUyeID == "0")
            {
                MessageBox.Show("Lütfen güncellenecek üyeyi seçin!");
                return;
            }

            baglanti.Open();

            SqlCommand komut = new SqlCommand("UPDATE TBL_UYE SET UyeAd=@p1, UyeSoyad=@p2, UyeTelNo=@p3, UyeMail=@p4 WHERE UyeID=@p5", baglanti);

            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4", textMail.Text);
            komut.Parameters.AddWithValue("@p5", secilenUyeID);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Üye Bilgileri Güncellendi!");
            Listele();
            Temizle();
            secilenUyeID = "0";
        }

        private void UyeYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
