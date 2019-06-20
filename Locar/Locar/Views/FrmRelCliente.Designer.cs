namespace Locar.Views
{
    partial class FrmRelCliente
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
            this.RVCliente = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RVCliente
            // 
            this.RVCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCliente";
            reportDataSource1.Value = this.ClienteBindingSource;
            this.RVCliente.LocalReport.DataSources.Add(reportDataSource1);
            this.RVCliente.LocalReport.ReportEmbeddedResource = "Locar.Models.RelCliente .rdlc";
            this.RVCliente.Location = new System.Drawing.Point(0, 0);
            this.RVCliente.Name = "RVCliente";
            this.RVCliente.ServerReport.BearerToken = null;
            this.RVCliente.Size = new System.Drawing.Size(800, 450);
            this.RVCliente.TabIndex = 0;
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataSource = typeof(Locar.Models.Cliente);
            // 
            // FrmRelCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RVCliente);
            this.Name = "FrmRelCliente";
            this.Text = "Relatório de Clientes";
            this.Load += new System.EventHandler(this.FrmRelCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVCliente;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
    }
}