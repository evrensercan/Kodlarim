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
    public partial class AnaSayfaForm: Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-K7ECI3M9\\SQLEXPRESS;Database=KutuphaneYonetimSistemi_DB;Trusted_Connection=True;TrustServerCertificate=True;");

        public AnaSayfaForm()
        {
            InitializeComponent();
        }

        // Üye İşlemleri Sayfası
        private void btnUye_Click(object sender, EventArgs e)
        {
            UyeYonetimForm uyeSyfası = new UyeYonetimForm();
            this.Hide();
            uyeSyfası.ShowDialog();
            this.Show();
        }

        // Kitap Yönetim Sayfası
        private void btnKitap_Click(object sender, EventArgs e)
        {
            KitapYonetimForm kitap = new KitapYonetimForm();
            this.Hide();
            kitap.ShowDialog();
            this.Show();
        }

        private void AnaSayfaForm_Load(object sender, EventArgs e)
        {
            IstatistikleriGetir();
        }

        // Ödünç Verme Sayfası
        private void btnHareket_Click(object sender, EventArgs e)
        {
            OduncIslemForm odunc = new OduncIslemForm();
            this.Hide();
            odunc.ShowDialog();
            this.Show();
        }

        // Kitabı İade Etme Sayfası
        private void btnIade_Click(object sender, EventArgs e)
        {
            IadeIslemForm iade = new IadeIslemForm();
            this.Hide();
            iade.ShowDialog();
            this.Show(); 
        }

        // İşlem Geçmişi Sayfası
        private void btnGecmis_Click(object sender, EventArgs e)
        {
            IslemGecmisiForm gecmis = new IslemGecmisiForm();
            this.Hide();
            gecmis.ShowDialog();
            this.Show();
        }

        // İstatistikleri Getirme Metodu
        void IstatistikleriGetir()
        {
            baglanti.Open();

            // Toplam Üye Sayısı
            SqlCommand uyeSayisi = new SqlCommand("SELECT COUNT(*) FROM TBL_UYE", baglanti);
            lblUyeSayisi.Text = uyeSayisi.ExecuteScalar().ToString();

            // Toplam Kitap Sayısı
            SqlCommand kitapSayisi = new SqlCommand("SELECT COUNT(*) FROM TBL_KİTAP", baglanti);
            lblKitapSayisi.Text = kitapSayisi.ExecuteScalar().ToString();

            // Emanet Kitap Sayısı
            SqlCommand emanetSayisi = new SqlCommand("SELECT COUNT(*) FROM TBL_KİTAP WHERE Durum = 0", baglanti);
            lblEmanetSayisi.Text = emanetSayisi.ExecuteScalar().ToString();

            // Raftaki Kitap Sayısı
            SqlCommand rafSayisi = new SqlCommand("SELECT COUNT(*) FROM TBL_KİTAP WHERE Durum = 1", baglanti);
            lblRafSayisi.Text = rafSayisi.ExecuteScalar().ToString();

            baglanti.Close();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUyeSayisi_Click(object sender, EventArgs e)
        {

        }

        private void lblRafSayisi_Click(object sender, EventArgs e)
        {

        }

        private void AnaSayfaForm_Activated(object sender, EventArgs e)
        {
            IstatistikleriGetir();
        }
    }
}
