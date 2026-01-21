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
            this.SuspendLayout();
            // 
            // btnKitap
            // 
            this.btnKitap.Location = new System.Drawing.Point(127, 77);
            this.btnKitap.Name = "btnKitap";
            this.btnKitap.Size = new System.Drawing.Size(119, 61);
            this.btnKitap.TabIndex = 0;
            this.btnKitap.Text = "Kitap Sayfası";
            this.btnKitap.UseVisualStyleBackColor = true;
            this.btnKitap.Click += new System.EventHandler(this.btnKitap_Click);
            // 
            // btnUye
            // 
            this.btnUye.Location = new System.Drawing.Point(127, 164);
            this.btnUye.Name = "btnUye";
            this.btnUye.Size = new System.Drawing.Size(119, 61);
            this.btnUye.TabIndex = 1;
            this.btnUye.Text = "Uye Sayfası";
            this.btnUye.UseVisualStyleBackColor = true;
            this.btnUye.Click += new System.EventHandler(this.btnUye_Click);
            // 
            // btnHareket
            // 
            this.btnHareket.Location = new System.Drawing.Point(127, 257);
            this.btnHareket.Name = "btnHareket";
            this.btnHareket.Size = new System.Drawing.Size(119, 61);
            this.btnHareket.TabIndex = 2;
            this.btnHareket.Text = "Hareket Sayfası";
            this.btnHareket.UseVisualStyleBackColor = true;
            this.btnHareket.Click += new System.EventHandler(this.btnHareket_Click);
            // 
            // btnIade
            // 
            this.btnIade.Location = new System.Drawing.Point(127, 349);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(119, 61);
            this.btnIade.TabIndex = 3;
            this.btnIade.Text = "İade İşlemleri";
            this.btnIade.UseVisualStyleBackColor = true;
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click);
            // 
            // btnGecmis
            // 
            this.btnGecmis.Location = new System.Drawing.Point(127, 437);
            this.btnGecmis.Name = "btnGecmis";
            this.btnGecmis.Size = new System.Drawing.Size(119, 61);
            this.btnGecmis.TabIndex = 4;
            this.btnGecmis.Text = "İşlem geçmişi";
            this.btnGecmis.UseVisualStyleBackColor = true;
            this.btnGecmis.Click += new System.EventHandler(this.btnGecmis_Click);
            // 
            // AnaSayfaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.btnGecmis);
            this.Controls.Add(this.btnIade);
            this.Controls.Add(this.btnHareket);
            this.Controls.Add(this.btnUye);
            this.Controls.Add(this.btnKitap);
            this.Name = "AnaSayfaForm";
            this.Text = "AnaaSayfaForm";
            this.Load += new System.EventHandler(this.AnaSayfaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKitap;
        private System.Windows.Forms.Button btnUye;
        private System.Windows.Forms.Button btnHareket;
        private System.Windows.Forms.Button btnIade;
        private System.Windows.Forms.Button btnGecmis;
    }
}