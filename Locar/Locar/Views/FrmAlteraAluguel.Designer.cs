namespace Locar.Views
{
    partial class FrmAlteraAluguel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlteraAluguel));
            this.CBVendedor = new System.Windows.Forms.ComboBox();
            this.CBCliente = new System.Windows.Forms.ComboBox();
            this.CBCarro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBDataInicio = new System.Windows.Forms.DateTimePicker();
            this.TBDataFim = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CBVendedor
            // 
            this.CBVendedor.FormattingEnabled = true;
            this.CBVendedor.Location = new System.Drawing.Point(15, 141);
            this.CBVendedor.Name = "CBVendedor";
            this.CBVendedor.Size = new System.Drawing.Size(494, 21);
            this.CBVendedor.TabIndex = 34;
            // 
            // CBCliente
            // 
            this.CBCliente.FormattingEnabled = true;
            this.CBCliente.Location = new System.Drawing.Point(15, 103);
            this.CBCliente.Name = "CBCliente";
            this.CBCliente.Size = new System.Drawing.Size(494, 21);
            this.CBCliente.TabIndex = 33;
            // 
            // CBCarro
            // 
            this.CBCarro.FormattingEnabled = true;
            this.CBCarro.Location = new System.Drawing.Point(15, 65);
            this.CBCarro.Name = "CBCarro";
            this.CBCarro.Size = new System.Drawing.Size(494, 21);
            this.CBCarro.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Data fim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Data início";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(15, 246);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 27;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(102, 246);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtnSalvar.TabIndex = 26;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Vendedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Carro";
            // 
            // TBId
            // 
            this.TBId.Location = new System.Drawing.Point(15, 25);
            this.TBId.Name = "TBId";
            this.TBId.ReadOnly = true;
            this.TBId.Size = new System.Drawing.Size(494, 20);
            this.TBId.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "ID";
            // 
            // TBDataInicio
            // 
            this.TBDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TBDataInicio.Location = new System.Drawing.Point(15, 181);
            this.TBDataInicio.Name = "TBDataInicio";
            this.TBDataInicio.Size = new System.Drawing.Size(494, 20);
            this.TBDataInicio.TabIndex = 37;
            // 
            // TBDataFim
            // 
            this.TBDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TBDataFim.Location = new System.Drawing.Point(15, 220);
            this.TBDataFim.Name = "TBDataFim";
            this.TBDataFim.Size = new System.Drawing.Size(494, 20);
            this.TBDataFim.TabIndex = 38;
            // 
            // FrmAlteraAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 281);
            this.Controls.Add(this.TBDataFim);
            this.Controls.Add(this.TBDataInicio);
            this.Controls.Add(this.TBId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CBVendedor);
            this.Controls.Add(this.CBCliente);
            this.Controls.Add(this.CBCarro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAlteraAluguel";
            this.Text = "Alteração de Aluguel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBVendedor;
        private System.Windows.Forms.ComboBox CBCliente;
        private System.Windows.Forms.ComboBox CBCarro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TBDataInicio;
        private System.Windows.Forms.DateTimePicker TBDataFim;
    }
}