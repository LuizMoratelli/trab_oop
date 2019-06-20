namespace Locar.Views
{
    partial class FrmRelAluguel
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RVAlugueis = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AluguelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AluguelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RVAlugueis
            // 
            this.RVAlugueis.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetAluguel";
            reportDataSource1.Value = this.AluguelBindingSource;
            this.RVAlugueis.LocalReport.DataSources.Add(reportDataSource1);
            this.RVAlugueis.LocalReport.ReportEmbeddedResource = "Locar.Models.RelAluguel .rdlc";
            this.RVAlugueis.Location = new System.Drawing.Point(0, 0);
            this.RVAlugueis.Name = "RVAlugueis";
            this.RVAlugueis.ServerReport.BearerToken = null;
            this.RVAlugueis.Size = new System.Drawing.Size(800, 450);
            this.RVAlugueis.TabIndex = 0;
            // 
            // AluguelBindingSource
            // 
            this.AluguelBindingSource.DataSource = typeof(Locar.Models.Aluguel);
            // 
            // FrmRelAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RVAlugueis);
            this.Name = "FrmRelAluguel";
            this.Text = "Relatório de Aluguéis";
            this.Load += new System.EventHandler(this.FrmRelAluguel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AluguelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVAlugueis;
        private System.Windows.Forms.BindingSource AluguelBindingSource;
    }
}