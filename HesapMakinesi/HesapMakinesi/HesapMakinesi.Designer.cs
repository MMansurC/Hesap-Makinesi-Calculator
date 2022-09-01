namespace HesapMakinesi
{
    partial class HesapMakinesi
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HesapMakinesi));
            this.Girdi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Girdi
            // 
            this.Girdi.Location = new System.Drawing.Point(13, 13);
            this.Girdi.Margin = new System.Windows.Forms.Padding(4);
            this.Girdi.Multiline = true;
            this.Girdi.Name = "Girdi";
            this.Girdi.Size = new System.Drawing.Size(124, 32);
            this.Girdi.TabIndex = 0;
            this.Girdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Girdi_KeyDown);
            this.Girdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Girdi_KeyPress);
            // 
            // HesapMakinesi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.Controls.Add(this.Girdi);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HesapMakinesi";
            this.Text = "Hesap Makinesi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Girdi;
    }
}

