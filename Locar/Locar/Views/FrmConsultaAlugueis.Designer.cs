namespace Locar.Views
{
    partial class FrmConsultaAlugueis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaAlugueis));
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.Dgw = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_fim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBCampo = new System.Windows.Forms.ComboBox();
            this.TBValor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(174, 392);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 7;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Location = new System.Drawing.Point(93, 392);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
            this.BtnAlterar.TabIndex = 6;
            this.BtnAlterar.Text = "Alterar";
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(12, 392);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 5;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // Dgw
            // 
            this.Dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.vendedor,
            this.carro,
            this.cliente,
            this.data_inicio,
            this.data_fim});
            this.Dgw.Location = new System.Drawing.Point(12, 52);
            this.Dgw.Name = "Dgw";
            this.Dgw.Size = new System.Drawing.Size(621, 334);
            this.Dgw.TabIndex = 4;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // vendedor
            // 
            this.vendedor.DataPropertyName = "Vendedor";
            this.vendedor.HeaderText = "Vendedor";
            this.vendedor.Name = "vendedor";
            this.vendedor.ReadOnly = true;
            // 
            // carro
            // 
            this.carro.DataPropertyName = "Carro";
            this.carro.HeaderText = "Carro";
            this.carro.Name = "carro";
            this.carro.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "Cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // data_inicio
            // 
            this.data_inicio.DataPropertyName = "data_inicio";
            this.data_inicio.HeaderText = "Data de Início";
            this.data_inicio.Name = "data_inicio";
            this.data_inicio.ReadOnly = true;
            // 
            // data_fim
            // 
            this.data_fim.DataPropertyName = "data_fim";
            this.data_fim.HeaderText = "Data de Fim";
            this.data_fim.Name = "data_fim";
            this.data_fim.ReadOnly = true;
            // 
            // CBTipo
            // 
            this.CBTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "Contém",
            "Começa com",
            "Termina com",
            "Maior que ",
            "Menor que",
            "Igual à",
            "Maior ou igual à",
            "Menor ou igual à"});
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "Contém",
            "Começa com",
            "Termina com",
            "Igual à",
            "Maior que",
            "Maior ou igual à",
            "Menor que ",
            "Menor ou igual à"});
            this.CBTipo.Location = new System.Drawing.Point(174, 25);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(121, 21);
            this.CBTipo.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filtro";
            // 
            // CBCampo
            // 
            this.CBCampo.FormattingEnabled = true;
            this.CBCampo.Location = new System.Drawing.Point(12, 25);
            this.CBCampo.Name = "CBCampo";
            this.CBCampo.Size = new System.Drawing.Size(156, 21);
            this.CBCampo.TabIndex = 13;
            // 
            // TBValor
            // 
            this.TBValor.Location = new System.Drawing.Point(301, 25);
            this.TBValor.Name = "TBValor";
            this.TBValor.Size = new System.Drawing.Size(332, 20);
            this.TBValor.TabIndex = 12;
            this.TBValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBValor_KeyPress);
            // 
            // FrmConsultaAlugueis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 428);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBCampo);
            this.Controls.Add(this.TBValor);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.Dgw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConsultaAlugueis";
            this.Text = "Consulta de Aluguel";
            ((System.ComponentModel.ISupportInitialize)(this.Dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.DataGridView Dgw;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBCampo;
        private System.Windows.Forms.TextBox TBValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn carro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_fim;
    }
}