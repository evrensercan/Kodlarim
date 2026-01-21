using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimSistemi
{
    public partial class AnaSayfaForm: Form
    {
        public AnaSayfaForm()
        {
            InitializeComponent();
        }

        private void btnUye_Click(object sender, EventArgs e)
        {
            UyeYonetimForm uyeSyfası = new UyeYonetimForm();
            this.Hide();
            uyeSyfası.ShowDialog();
            this.Show();
        }

        private void btnKitap_Click(object sender, EventArgs e)
        {
            KitapYonetimForm kitapYonetimSayfası = new KitapYonetimForm();
            this.Hide();
            kitapYonetimSayfası.ShowDialog();
            this.Show();

        }

        private void AnaSayfaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnHareket_Click(object sender, EventArgs e)
        {
            OduncIslemForm OduncVermeSayfası = new OduncIslemForm();
            this.Hide();
            OduncVermeSayfası.ShowDialog();
            this.Show();
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            IadeIslemForm iade = new IadeIslemForm();
            iade.Show();
            // this.Hide(); yapmana gerek yok, ana menü açık kalsın istersen.
        }

        private void btnGecmis_Click(object sender, EventArgs e)
        {
            IslemGecmisiForm gecmis = new IslemGecmisiForm();
            gecmis.Show();
            this.Hide();
        }
    }
}
