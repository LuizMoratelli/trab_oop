namespace Locar
{
    partial class FrmPrincipal
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
            this.BtnCarros = new System.Windows.Forms.Button();
            this.BtnClientes = new System.Windows.Forms.Button();
            this.BtnVendedores = new System.Windows.Forms.Button();
            this.BtnAlugueis = new System.Windows.Forms.Button();
            this.BtnRelCarros = new System.Windows.Forms.Button();
            this.BtnRelClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCarros
            // 
            this.BtnCarros.Location = new System.Drawing.Point(12, 12);
            this.BtnCarros.Name = "BtnCarros";
            this.BtnCarros.Size = new System.Drawing.Size(198, 23);
            this.BtnCarros.TabIndex = 0;
            this.BtnCarros.Text = "Carros";
            this.BtnCarros.UseVisualStyleBackColor = true;
            this.BtnCarros.Click += new System.EventHandler(this.BtnCarros_Click);
            // 
            // BtnClientes
            // 
            this.BtnClientes.Location = new System.Drawing.Point(232, 12);
            this.BtnClientes.Name = "BtnClientes";
            this.BtnClientes.Size = new System.Drawing.Size(198, 23);
            this.BtnClientes.TabIndex = 1;
            this.BtnClientes.Text = "Clientes";
            this.BtnClientes.UseVisualStyleBackColor = true;
            this.BtnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // BtnVendedores
            // 
            this.BtnVendedores.Location = new System.Drawing.Point(12, 41);
            this.BtnVendedores.Name = "BtnVendedores";
            this.BtnVendedores.Size = new System.Drawing.Size(198, 23);
            this.BtnVendedores.TabIndex = 2;
            this.BtnVendedores.Text = "Vendedores";
            this.BtnVendedores.UseVisualStyleBackColor = true;
            this.BtnVendedores.Click += new System.EventHandler(this.BtnVendedores_Click);
            // 
            // BtnAlugueis
            // 
            this.BtnAlugueis.Location = new System.Drawing.Point(232, 41);
            this.BtnAlugueis.Name = "BtnAlugueis";
            this.BtnAlugueis.Size = new System.Drawing.Size(198, 23);
            this.BtnAlugueis.TabIndex = 3;
            this.BtnAlugueis.Text = "Alugueis";
            this.BtnAlugueis.UseVisualStyleBackColor = true;
            this.BtnAlugueis.Click += new System.EventHandler(this.BtnAlugueis_Click);
            // 
            // BtnRelCarros
            // 
            this.BtnRelCarros.Location = new System.Drawing.Point(12, 70);
            this.BtnRelCarros.Name = "BtnRelCarros";
            this.BtnRelCarros.Size = new System.Drawing.Size(198, 23);
            this.BtnRelCarros.TabIndex = 4;
            this.BtnRelCarros.Text = "Relatório de Carros";
            this.BtnRelCarros.UseVisualStyleBackColor = true;
            this.BtnRelCarros.Click += new System.EventHandler(this.BtnRelCarros_Click);
            // 
            // BtnRelClientes
            // 
            this.BtnRelClientes.Location = new System.Drawing.Point(232, 70);
            this.BtnRelClientes.Name = "BtnRelClientes";
            this.BtnRelClientes.Size = new System.Drawing.Size(198, 23);
            this.BtnRelClientes.TabIndex = 5;
            this.BtnRelClientes.Text = "Relatório de Clientes";
            this.BtnRelClientes.UseVisualStyleBackColor = true;
            this.BtnRelClientes.Click += new System.EventHandler(this.BtnRelClientes_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 113);
            this.Controls.Add(this.BtnRelClientes);
            this.Controls.Add(this.BtnRelCarros);
            this.Controls.Add(this.BtnAlugueis);
            this.Controls.Add(this.BtnVendedores);
            this.Controls.Add(this.BtnClientes);
            this.Controls.Add(this.BtnCarros);
            this.Name = "FrmPrincipal";
            this.Text = "Locar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCarros;
        private System.Windows.Forms.Button BtnClientes;
        private System.Windows.Forms.Button BtnVendedores;
        private System.Windows.Forms.Button BtnAlugueis;
        private System.Windows.Forms.Button BtnRelCarros;
        private System.Windows.Forms.Button BtnRelClientes;
    }
}