namespace Gra
{
    partial class frmPrzeszkody
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrStoper = new System.Windows.Forms.Timer(this.components);
            this.lblCzas = new System.Windows.Forms.Label();
            this.tmrCzas = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlPanel
            // 
            this.pnlPanel.Location = new System.Drawing.Point(5, 2);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(510, 410);
            this.pnlPanel.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 427);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrStoper
            // 
            this.tmrStoper.Interval = 1000;
            this.tmrStoper.Tick += new System.EventHandler(this.tmrStoper_Tick);
            // 
            // lblCzas
            // 
            this.lblCzas.AutoSize = true;
            this.lblCzas.Location = new System.Drawing.Point(114, 427);
            this.lblCzas.Name = "lblCzas";
            this.lblCzas.Size = new System.Drawing.Size(43, 13);
            this.lblCzas.TabIndex = 1;
            this.lblCzas.Text = "00:00:0";
            // 
            // tmrCzas
            // 
            this.tmrCzas.Tick += new System.EventHandler(this.tmrCzas_Tick);
            // 
            // frmPrzeszkody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 471);
            this.Controls.Add(this.lblCzas);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrzeszkody";
            this.Text = "Przeszkody";
            this.Load += new System.EventHandler(this.frmPrzeszkody_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrzeszkody_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrStoper;
        private System.Windows.Forms.Label lblCzas;
        private System.Windows.Forms.Timer tmrCzas;
    }
}

