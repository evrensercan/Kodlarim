namespace KutuphaneYonetimSistemi
{
    partial class AnaSayfaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKitap = new System.Windows.Forms.Button();
            this.btnUye = new System.Windows.Forms.Button();
            this.btnHareket = new System.Windows.Forms.Button();
            this.btnIade = new System.Windows.Forms.Button();
            this.btnGecmis = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUyeSayisi = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblKitapSayisi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRafSayisi = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblEmanetSayisi = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKitap
            // 
            this.btnKitap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnKitap.Location = new System.Drawing.Point(35, 92);
            this.btnKitap.Name = "btnKitap";
            this.btnKitap.Size = new System.Drawing.Size(240, 76);
            this.btnKitap.TabIndex = 0;
            this.btnKitap.Text = "Kitap Sayfası";
            this.btnKitap.UseVisualStyleBackColor = true;
            this.btnKitap.Click += new System.EventHandler(this.btnKitap_Click);
            // 
            // btnUye
            // 
            this.btnUye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUye.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnUye.Location = new System.Drawing.Point(35, 221);
            this.btnUye.Name = "btnUye";
            this.btnUye.Size = new System.Drawing.Size(240, 76);
            this.btnUye.TabIndex = 1;
            this.btnUye.Text = "Uye Sayfası";
            this.btnUye.UseVisualStyleBackColor = true;
            this.btnUye.Click += new System.EventHandler(this.btnUye_Click);
            // 
            // btnHareket
            // 
            this.btnHareket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHareket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHareket.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnHareket.Location = new System.Drawing.Point(35, 363);
            this.btnHareket.Name = "btnHareket";
            this.btnHareket.Size = new System.Drawing.Size(240, 76);
            this.btnHareket.TabIndex = 2;
            this.btnHareket.Text = "Ödünç Verme Sayfası";
            this.btnHareket.UseVisualStyleBackColor = true;
            this.btnHareket.Click += new System.EventHandler(this.btnHareket_Click);
            // 
            // btnIade
            // 
            this.btnIade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIade.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnIade.Location = new System.Drawing.Point(35, 502);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(240, 76);
            this.btnIade.TabIndex = 3;
            this.btnIade.Text = "İade İşlemleri";
            this.btnIade.UseVisualStyleBackColor = true;
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // btnGecmis
            // 
            this.btnGecmis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGecmis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGecmis.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnGecmis.Location = new System.Drawing.Point(35, 631);
            this.btnGecmis.Name = "btnGecmis";
            this.btnGecmis.Size = new System.Drawing.Size(240, 76);
            this.btnGecmis.TabIndex = 4;
            this.btnGecmis.Text = "İşlem geçmişi";
            this.btnGecmis.UseVisualStyleBackColor = true;
            this.btnGecmis.Click += new System.EventHandler(this.btnGecmis_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnKitap);
            this.panel1.Controls.Add(this.btnGecmis);
            this.panel1.Controls.Add(this.btnIade);
            this.panel1.Controls.Add(this.btnHareket);
            this.panel1.Controls.Add(this.btnUye);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 915);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "📚📕📗📘📙📖📖";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.lblUyeSayisi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(421, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 242);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(29, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Toplam Üye";
            // 
            // lblUyeSayisi
            // 
            this.lblUyeSayisi.AutoSize = true;
            this.lblUyeSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyeSayisi.Location = new System.Drawing.Point(64, 91);
            this.lblUyeSayisi.Name = "lblUyeSayisi";
            this.lblUyeSayisi.Size = new System.Drawing.Size(79, 86);
            this.lblUyeSayisi.TabIndex = 1;
            this.lblUyeSayisi.Text = "0";
            this.lblUyeSayisi.Click += new System.EventHandler(this.lblUyeSayisi_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaGreen;
            this.panel3.Controls.Add(this.lblKitapSayisi);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(865, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 230);
            this.panel3.TabIndex = 10;
            // 
            // lblKitapSayisi
            // 
            this.lblKitapSayisi.AutoSize = true;
            this.lblKitapSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapSayisi.Location = new System.Drawing.Point(62, 79);
            this.lblKitapSayisi.Name = "lblKitapSayisi";
            this.lblKitapSayisi.Size = new System.Drawing.Size(63, 69);
            this.lblKitapSayisi.TabIndex = 1;
            this.lblKitapSayisi.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(17, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 53);
            this.label5.TabIndex = 0;
            this.label5.Text = "Toplam Kitap";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.Controls.Add(this.lblRafSayisi);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(421, 382);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 234);
            this.panel4.TabIndex = 12;
            // 
            // lblRafSayisi
            // 
            this.lblRafSayisi.AutoSize = true;
            this.lblRafSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRafSayisi.Location = new System.Drawing.Point(54, 87);
            this.lblRafSayisi.Name = "lblRafSayisi";
            this.lblRafSayisi.Size = new System.Drawing.Size(63, 69);
            this.lblRafSayisi.TabIndex = 1;
            this.lblRafSayisi.Text = "0";
            this.lblRafSayisi.Click += new System.EventHandler(this.lblRafSayisi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(3, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(271, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Raftaki Kitap Sayısı";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Controls.Add(this.lblEmanetSayisi);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(865, 382);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 234);
            this.panel5.TabIndex = 11;
            // 
            // lblEmanetSayisi
            // 
            this.lblEmanetSayisi.AutoSize = true;
            this.lblEmanetSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmanetSayisi.Location = new System.Drawing.Point(62, 87);
            this.lblEmanetSayisi.Name = "lblEmanetSayisi";
            this.lblEmanetSayisi.Size = new System.Drawing.Size(63, 69);
            this.lblEmanetSayisi.TabIndex = 1;
            this.lblEmanetSayisi.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(3, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Emanetteki Kitap Sayısı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 749);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "📚📕📗📘📙📖📖";
            // 
            // AnaSayfaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1309, 915);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AnaSayfaForm";
            this.Text = "AnaaSayfaForm";
            this.Activated += new System.EventHandler(this.AnaSayfaForm_Activated);
            this.Load += new System.EventHandler(this.AnaSayfaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKitap;
        private System.Windows.Forms.Button btnUye;
        private System.Windows.Forms.Button btnHareket;
        private System.Windows.Forms.Button btnIade;
        private System.Windows.Forms.Button btnGecmis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUyeSayisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblKitapSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblRafSayisi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblEmanetSayisi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
    }
}