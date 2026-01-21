namespace KutuphaneYonetimSistemi
{
    partial class IslemGecmisiForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIslemAra = new System.Windows.Forms.TextBox();
            this.cmbFiltre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(769, 335);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtreler";
            // 
            // txtIslemAra
            // 
            this.txtIslemAra.Location = new System.Drawing.Point(127, 87);
            this.txtIslemAra.Name = "txtIslemAra";
            this.txtIslemAra.Size = new System.Drawing.Size(250, 22);
            this.txtIslemAra.TabIndex = 2;
            this.txtIslemAra.TextChanged += new System.EventHandler(this.txtIslemAra_TextChanged);
            // 
            // cmbFiltre
            // 
            this.cmbFiltre.FormattingEnabled = true;
            this.cmbFiltre.Items.AddRange(new object[] {
            "Tüm İşlemle",
            "r",
            "",
            "İade Edilenler",
            "",
            "",
            "Teslim Bekleyenler"});
            this.cmbFiltre.Location = new System.Drawing.Point(455, 85);
            this.cmbFiltre.Name = "cmbFiltre";
            this.cmbFiltre.Size = new System.Drawing.Size(257, 24);
            this.cmbFiltre.TabIndex = 3;
            this.cmbFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
            // 
            // IslemGecmisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.cmbFiltre);
            this.Controls.Add(this.txtIslemAra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "IslemGecmisiForm";
            this.Text = "IslemGecmisiForm";
            this.Load += new System.EventHandler(this.IslemGecmisiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIslemAra;
        private System.Windows.Forms.ComboBox cmbFiltre;
    }
}