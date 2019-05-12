namespace Locar
{
    partial class FrmConsultaVendedores
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
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.Dgw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(177, 352);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 11;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Location = new System.Drawing.Point(96, 352);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
            this.BtnAlterar.TabIndex = 10;
            this.BtnAlterar.Text = "Alterar";
            this.BtnAlterar.UseVisualStyleBackColor = true;
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(15, 352);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 9;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            // 
            // Dgw
            // 
            this.Dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgw.Location = new System.Drawing.Point(12, 12);
            this.Dgw.Name = "Dgw";
            this.Dgw.Size = new System.Drawing.Size(621, 334);
            this.Dgw.TabIndex = 8;
            // 
            // FrmConsultaVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 385);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.Dgw);
            this.Name = "FrmConsultaVendedores";
            this.Text = "FrmConsultaVendedores";
            this.Load += new System.EventHandler(this.FrmConsultaVendedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.DataGridView Dgw;
    }
}