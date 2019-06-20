namespace Locar.Views
{
    partial class FrmRelVendedor
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
            this.RVVendedor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VendedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VendedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RVVendedor
            // 
            this.RVVendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetVendedor";
            reportDataSource1.Value = this.VendedorBindingSource;
            this.RVVendedor.LocalReport.DataSources.Add(reportDataSource1);
            this.RVVendedor.LocalReport.ReportEmbeddedResource = "Locar.Models.RelVendedor .rdlc";
            this.RVVendedor.Location = new System.Drawing.Point(0, 0);
            this.RVVendedor.Name = "RVVendedor";
            this.RVVendedor.ServerReport.BearerToken = null;
            this.RVVendedor.Size = new System.Drawing.Size(800, 450);
            this.RVVendedor.TabIndex = 0;
            // 
            // VendedorBindingSource
            // 
            this.VendedorBindingSource.DataSource = typeof(Locar.Models.Vendedor);
            // 
            // FrmRelVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RVVendedor);
            this.Name = "FrmRelVendedor";
            this.Text = "Relatório de Vendedores";
            this.Load += new System.EventHandler(this.FrmRelVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVVendedor;
        private System.Windows.Forms.BindingSource VendedorBindingSource;
    }
}