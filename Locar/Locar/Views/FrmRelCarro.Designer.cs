namespace Locar.Views
{
    partial class FrmRelCarro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelCarro));
            this.CarroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RVCarro = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CarroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CarroBindingSource
            // 
            this.CarroBindingSource.DataSource = typeof(Locar.Models.Carro);
            // 
            // RVCarro
            // 
            this.RVCarro.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCarro";
            reportDataSource1.Value = this.CarroBindingSource;
            this.RVCarro.LocalReport.DataSources.Add(reportDataSource1);
            this.RVCarro.LocalReport.ReportEmbeddedResource = "Locar.Models.RelCarro.rdlc";
            this.RVCarro.Location = new System.Drawing.Point(0, 0);
            this.RVCarro.Name = "RVCarro";
            this.RVCarro.ServerReport.BearerToken = null;
            this.RVCarro.Size = new System.Drawing.Size(800, 450);
            this.RVCarro.TabIndex = 0;
            // 
            // FrmRelCarro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RVCarro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRelCarro";
            this.Text = "Relatório de Carros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRelCarro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVCarro;
        private System.Windows.Forms.BindingSource CarroBindingSource;
    }
}